using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetWorkConsoleApp
{
    //Class Taken from Joseph Collins M.Sc thesis.
    class Matrix
    {
        private int rows;

        public int Rows
        {
            get { return rows; }
        }
        private int cols;

        public int Cols
        {
            get { return cols; }
        }
        private double[,] data;

        public Matrix(int rows, int cols)
        {
            if (rows > 0)
                this.rows = rows;
            else
                this.rows = 1;
            if (cols > 0)
                this.cols = cols;
            else
                this.cols = 1;
            data = new double[rows, cols];

        }
        public Matrix(double[,] x)
        {
            if (x.GetLength(0) > 0)
                this.rows = x.GetLength(0);
            else
                this.rows = 1;
            if (x.GetLength(1) > 0)
                this.cols = x.GetLength(1);
            else
                this.cols = 1;
            data = new double[this.rows, this.cols];
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    data[i, j] = x[i, j];
        }

        public Matrix(int rows, int cols, double dval)
        {
            if (rows > 0)
                this.rows = rows;
            else
                this.rows = 1;
            if (cols > 0)
                this.cols = cols;
            else
                this.cols = 1;
            data = new double[rows, cols];
            int i, j;
            for (i = 0; i < rows; i++)
                for (j = 0; j < cols; j++)
                    if (i == j)
                        data[i, j] = dval;
        }
        public Matrix(Matrix val)
        {
            rows = val.rows;
            cols = val.cols;
            data = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    data[i, j] = val.data[i, j];
        }
        public Matrix getLDiagonal()
        {//the equivalent lower diagonal matrix
            int i, j;
            Matrix tmp = new Matrix(rows, cols);
            for (i = 0; i < rows; i++)
                for (j = 0; j < cols; j++)
                    if (i > j)
                        tmp[i, j] = this[i, j];
            return tmp;
        }
        public Matrix getUDiagonal()
        {//the equivalent lower diagonal matrix
            int i, j;
            Matrix tmp = new Matrix(rows, cols);
            for (i = 0; i < rows; i++)
                for (j = 0; j < cols; j++)
                    if (j > i)
                        tmp[i, j] = this[i, j];
            return tmp;
        }
        public Matrix getDiagonal()
        {//the equivalent lower diagonal matrix
            int i, j;
            Matrix tmp = new Matrix(rows, cols);
            for (i = 0; i < rows; i++)
                for (j = 0; j < cols; j++)
                    if (i == j)
                        tmp[i, j] = this[i, j];
            return tmp;
        }
        public Matrix getInverseDiagonal()
        {//the equivalent lower diagonal matrix
            int i, j;
            Matrix tmp = new Matrix(rows, cols);
            for (i = 0; i < rows; i++)
                for (j = 0; j < cols; j++)
                    if (i == j && this[i, j] != 0)
                        tmp[i, j] = 1 / this[i, j];
            return tmp;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.rows != b.rows || a.cols != b.cols)
                return null;
            Matrix tmp = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.cols; j++)
                    tmp.data[i, j] = a.data[i, j] + b.data[i, j];
            return tmp;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.rows != b.rows || a.cols != b.cols)
                return null;
            Matrix tmp = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.cols; j++)
                    tmp.data[i, j] = a.data[i, j] - b.data[i, j];
            return tmp;
        }
        public static Matrix operator +(Matrix a)
        {
            Matrix tmp = new Matrix(a);
            return tmp;
        }
        public static Matrix operator -(Matrix a)
        {
            Matrix tmp = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.cols; j++)
                    tmp.data[i, j] = -a.data[i, j];
            return tmp;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix tmp = new Matrix(a.rows, b.cols);
            double sum = 0;
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < b.cols; j++)
                {
                    sum = 0;
                    for (int k = 0; k < b.rows; k++)
                        sum += a[i, k] * b[k, j];
                    tmp.data[i, j] = sum;
                }
            return tmp;
        }
        public static Matrix operator *(double a, Matrix b)
        {
            Matrix tmp = new Matrix(b.rows, b.cols);
            for (int i = 0; i < b.rows; i++)
                for (int j = 0; j < b.cols; j++)
                {
                    tmp.data[i, j] = a * b[i, j];
                }
            return tmp;
        }

        public void Output()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write("{0,4:F2}\t", data[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public void setValue(int row, int col, double val)
        {
            if (!(row >= 0 && row < rows && col >= 0 && col < cols))
                return;
            data[row, col] = val;
        }

        //matrix to double array
        public static explicit operator double[,](Matrix m)
        {
            double[,] tmp = new double[m.rows, m.cols];

            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                    tmp[i, j] = m.data[i, j];
            return tmp;
        }

        //indexer function
        public double this[int rowindex, int colindex]
        {
            get
            {
                if (rowindex < rows && rowindex >= 0 && colindex < cols && colindex >= 0)
                    return data[rowindex, colindex];
                else
                    return 0;
            }
            set
            {
                if (rowindex < rows && rowindex >= 0 && colindex < cols && colindex >= 0)
                    data[rowindex, colindex] = value;
                //else do nothing
            }
        }

        
    }
}
