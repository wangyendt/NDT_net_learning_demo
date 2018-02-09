# coding: utf-8


if __name__ == '__main__':
    VK_CODE = {}
    fileobj = open(".\\key.txt", "r")
    for line in fileobj:
        [key, value] = line.strip().split(',')
        VK_CODE[key] = value
    fileobj.close()
    KEY = []
    fileobj = open(".\\settings\\key.config", "r")
    for line in fileobj:
        KEY.append(line.replace("\n", ""))
    fileobj.close()
    fileobj = open(".\\settings\\Value.config", "w")
    for k in KEY:
        fileobj.writelines(VK_CODE[k])
    fileobj.close()
