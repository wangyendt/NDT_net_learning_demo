using System;

namespace NDT_Learning_Demo
{
	/// <summary>
	 /// 矩阵   异常 512索引 1024无解 2046矩阵行列 
	 /// </summary>
    public class Matrix
    {
        private int m_row;//行
        private int m_col;//列
        private double[,] m_data;//数据
        /// <summary>元素
        /// </summary>
        /// <param name="ro"></param>
        /// <param name="co"></param>
        /// <returns></returns>
        public double this[int ro, int co]
        {
            get
            {
                if (ro >= m_row || co >= m_col || ro < 0 || co < 0) throw new Exception("512");
                return m_data[ro, co];
            }
            set
            {
                if (ro >= m_row || co >= m_col || ro < 0 || co < 0) throw new Exception("512");
                m_data[ro, co] = value;
            }
        }
        /// <summary>行数
        /// </summary>
        public int Row
        { get { return m_row; } }
        /// <summary>列数
        /// </summary>
        public int Column
        { get { return m_col; } }
        public Matrix()
        { m_row = 0; m_col = 0; m_data = new double[0, 0]; }
        public Matrix(double[,] matrix)
        {
            m_row = matrix.GetLength(0);
            m_col = matrix.GetLength(1);
            m_data = matrix;
        }
        public Matrix(int ro, int co)
        {
            if (ro < 0 || co < 0) throw new Exception("512");
            m_row = ro;
            m_col = co;
            m_data = new double[ro, co];
        }

        public double[] SpecRow(int row)
        {
            double[] re = new double[Column];
            for (int i = 0; i < re.Length; i++)
            {
                re[i] = m_data[row, i];
            }
            return re;
        }

        public double[] SpecCol(int col)
        {
            double[] re = new double[Row];
            for (int i = 0; i < re.Length; i++)
            {
                re[i] = m_data[i, col];
            }
            return re;
        }

        public static Matrix tanh(Matrix mat)
        {
            Matrix re = new Matrix(mat.Row, mat.Column);
            for (int i = 0; i < mat.Row; i++)
            {
                for (int j = 0; j < mat.Column; j++)
                {
                    re[i, j] = Math.Tanh(mat[i, j]);
                }
            }
            return re;
        }

        public static Matrix exp(Matrix mat)
        {
            Matrix re = new Matrix(mat.Row, mat.Column);
            for (int i = 0; i < mat.Row; i++)
            {
                for (int j = 0; j < mat.Column; j++)
                {
                    re[i, j] = Math.Exp(mat[i, j]);
                }
            }
            return re;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Column != right.Row) throw new Exception("2046");
            Matrix re = new Matrix(left.Row, right.Column);
            for (int i = 0; i < left.Row; i++)
            {
                for (int j = 0; j < right.Column; j++)
                {
                    for (int k = 0; k < left.Column; k++)
                    {
                        re[i, j] += left[i, k] * right[k, j];
                    }
                }
            }
            return re;

        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.Row != right.Row || left.Column != right.Column)
                throw new Exception("2046");
            Matrix re = new Matrix(left.Row, left.Column);
            for (int i = 0; i < left.Row; i++)
            {
                for (int j = 0; j < left.Column; j++)
                {
                    re[i, j] = left[i, j] + right[i, j];
                }
            }
            return re;
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.Row != right.Row || left.Column != right.Column)
                throw new Exception("2046");
            Matrix re = new Matrix(left.Row, left.Column);
            for (int i = 0; i < left.Row; i++)
            {
                for (int j = 0; j < left.Column; j++)
                {
                    re[i, j] = left[i, j] - right[i, j];
                }
            }
            return re;
        }
        public static Matrix operator *(double factor, Matrix right)
        {
            Matrix re = new Matrix(right.Row, right.Column);
            for (int i = 0; i < right.Row; i++)
            {
                for (int j = 0; j < right.Column; j++)
                {
                    re[i, j] = right[i, j] * factor;
                }
            }
            return re;
        }
        public static Matrix operator *(Matrix left, double factor)
        {
            return factor * left;
        }
        /// <summary>转置
        /// </summary>
        /// <returns></returns>
        public Matrix Matrixtran()
        {
            Matrix re = new Matrix(this.m_col, this.m_row);
            for (int i = 0; i < this.m_row; i++)
            {
                for (int j = 0; j < this.m_col; j++)
                {
                    re[j, i] = this[i, j];
                }
            }
            return re;
        }
        /// <summary>行列式        //加边法
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        public double Matrixvalue()
        {
            if (this.m_row != this.m_col)
            { throw new Exception("2046"); }
            int n = this.m_row;
            if (n == 2) return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            double dsum = 0, dSign = 1;
            for (int i = 0; i < n; i++)
            {
                Matrix tempa = new Matrix(n - 1, n - 1);
                for (int j = 0; j < n - 1; j++)
                {
                    for (int k = 0; k < n - 1; k++)
                    {
                        tempa[j, k] = this[j + 1, k >= i ? k + 1 : k];
                    }
                }
                dsum += this[0, i] * dSign * tempa.Matrixvalue();
                dSign = dSign * -1;
            }
            return dsum;
        }
        /// <summary>求逆
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        public Matrix InverseMatrix()
        {
            int row = this.m_row; int col = this.m_col;
            if (row != col) throw new Exception("2046");
            Matrix re = new Matrix(row, col);
            double val = this.Matrixvalue();
            if (Math.Abs(val) <= 1E-6) { throw new Exception("1024"); }
            re = this.AdjointMatrix();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    re[i, j] = re[i, j] / val;
                }
            }
            return re;

        }
        /// <summary>求伴随矩阵
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        public Matrix AdjointMatrix()
        {
            int row = this.m_row;
            Matrix re = new Matrix(row, row);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Matrix temp = new Matrix(row - 1, row - 1);
                    for (int x = 0; x < row - 1; x++)
                    {
                        for (int y = 0; y < row - 1; y++)
                        {
                            temp[x, y] = this[x < i ? x : x + 1, y < j ? y : y + 1];
                        }
                    }
                    re[j, i] = ((i + j) % 2 == 0 ? 1 : -1) * temp.Matrixvalue();
                }
            }
            return re;
        }
    }
}