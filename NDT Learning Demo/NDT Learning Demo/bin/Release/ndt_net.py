# coding: utf-8
from __future__ import print_function
import numpy as np
import os
import tensorflow as tf
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelBinarizer


def add_layer(inputs, in_size, out_size, layer_name, activation_function=None, ):
    # add one more layer and return the output of this layer
    Weights = tf.Variable(tf.random_normal([in_size, out_size]))
    tf.summary.histogram(layer_name + '/weights', Weights)
    biases = tf.Variable(tf.zeros([1, out_size]) + 0.1, )
    tf.summary.histogram(layer_name + '/biases', biases)
    # print(Weights.shape)
    # print(inputs.shape)
    # print(biases.shape)
    Wx_plus_b = tf.matmul(inputs, Weights) + biases
    # here to dropout
    Wx_plus_b = tf.nn.dropout(Wx_plus_b, keep_prob)
    if activation_function is None:
        outputs = Wx_plus_b
    else:
        outputs = activation_function(Wx_plus_b, )
    tf.summary.histogram(layer_name + '/outputs', outputs)
    return outputs, Weights, biases


if __name__ == '__main__':

    try:
        os.system("del_log.bat")
    except:
        pass
    raw_data = np.genfromtxt("final_data.txt")
    # print(raw_data.shape)
    raw_data = raw_data[np.apply_along_axis(lambda x: np.max(x) >= 30, 1, raw_data), :]
    # print(raw_data.shape)
    X = raw_data[:, 0:9]
    X = np.apply_along_axis(lambda x: x / np.max(x), 1, X)
    y = raw_data[:, 9]
    y = LabelBinarizer().fit_transform(y)
    # y[y < 0] = -1
    print("X shape: ", X.shape)
    print("y shape: ", y.shape)
    # print(y)
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.3)

    # define placeholder for inputs to network
    keep_prob = tf.placeholder(tf.float32)
    xs = tf.placeholder(tf.float32, [None, 9])
    ys = tf.placeholder(tf.float32, [None, 8])

    # add output layer 隐藏层节点个数为50
    l1, Weights_l1, biases_l1 = add_layer(xs, 9, 50, 'l1', activation_function=tf.nn.tanh)
    prediction, Weights_output, biases_output = add_layer(l1, 50, 8, 'l2', activation_function=tf.nn.softmax)

    # the loss between prediction and real data
    # cross_entropy = tf.reduce_mean(-tf.reduce_sum(ys * tf.log(prediction),
    #                                               reduction_indices=[1]))  # loss
    cross_entropy = tf.reduce_mean(tf.square(ys - prediction))
    tf.summary.scalar('loss', cross_entropy)
    train_step = tf.train.AdamOptimizer(0.05).minimize(cross_entropy)

    sess = tf.Session()
    merged = tf.summary.merge_all()
    # summary writer goes in here
    train_writer = tf.summary.FileWriter("logs/train", sess.graph)
    test_writer = tf.summary.FileWriter("logs/test", sess.graph)

    init = tf.global_variables_initializer()
    sess.run(init)
    for i in range(3000):
        # here to determine the keeping probability
        sess.run(train_step, feed_dict={xs: X_train, ys: y_train, keep_prob: 0.6})
        if i % 100 == 0:
            # record loss
            train_result = sess.run(merged, feed_dict={xs: X_train, ys: y_train, keep_prob: 1})
            test_result = sess.run(merged, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
            train_writer.add_summary(train_result, i)
            test_writer.add_summary(test_result, i)
            print("iteration: ", i, "loss: ", sess.run(cross_entropy, feed_dict={xs: X_test, ys: y_test, keep_prob: 1}))

    pred = sess.run(prediction, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
    # print(pred)
    pred[pred > 0.5] = 1
    pred[pred < 0.5] = 0
    np.set_printoptions(threshold=np.inf)
    # print(np.column_stack((y_test, pred)))
    print('正确率:', np.sum(np.sum(np.square(y_test - pred), axis=1) < 0.1) / y_test.shape[0])

    Weights_l1 = sess.run(Weights_l1, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
    biases_l1 = sess.run(biases_l1, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
    Weights_output = sess.run(Weights_output, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
    biases_output = sess.run(biases_output, feed_dict={xs: X_test, ys: y_test, keep_prob: 1})
    np.savetxt(".\\learned_params\\W1", Weights_l1, delimiter="\t")
    np.savetxt(".\\learned_params\\B1", biases_l1, delimiter="\t")
    np.savetxt(".\\learned_params\\W2", Weights_output, delimiter="\t")
    np.savetxt(".\\learned_params\\B2", biases_output, delimiter="\t")

    a1 = np.tanh(np.matmul(X_test, Weights_l1) + biases_l1)
    a2 = np.exp(np.matmul(a1, Weights_output) + biases_output)
    a2m = np.apply_along_axis(lambda x: x / np.max(x), 1, a2)
    a2m[a2m > 0.5] = 1
    a2m[a2m < 0.5] = 0
    print('正确率:', np.sum(np.sum(np.square(y_test - a2m), axis=1) < 0.1) / y_test.shape[0])

    # 用 saver 将所有的 variable 保存到定义的路径
    saver = tf.train.Saver()
    save_path = saver.save(sess, "my_net/save_net.ckpt")
    print("Save to path: ", save_path)
    sess.close()
    os.system("create_tensor_board.bat")
