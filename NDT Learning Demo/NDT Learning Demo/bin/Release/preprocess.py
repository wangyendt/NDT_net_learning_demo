# coding: utf-8
from numpy.matlib import repmat
import numpy as np
import os

if __name__ == '__main__':
    path = ".\\data\\"
    parents = os.listdir(path)
    new_data = np.zeros([1, 10], dtype=int)
    # print(new_data.shape)
    for p in parents:
        child = os.path.join(path, p)
        data = np.genfromtxt(child, dtype=int)
        if data.shape[0] == 0:
            continue
        label = int(child[-5])
        ones_col = np.ones([data.shape[0], 1])
        data = np.column_stack((data, label * ones_col))
        # print(data.shape)
        new_data = np.vstack((new_data, data))
    # print(new_data.dtype)
    new_data = new_data.astype(int)
    new_data = np.round(new_data)

    np.savetxt("final_data.txt", new_data)
