using System;
using System.IO;

namespace NDT_Learning_Demo
{
    public static class ReadDoubleFromFile
    {
        public static double[,] Read(string strFile, string strDelimiter)
        {
            int nrow = 0;
            int ncol = 0;
            double[,] dRet= new double[nrow,ncol];

            if (File.Exists(strFile))
            {
                string[] lines = File.ReadAllLines(strFile);
                if (lines.Length > 0)
                {
                    string strFirstLine = lines[0];
                    string[] strValues = strFirstLine.Split(new[] { strDelimiter },
                        StringSplitOptions.RemoveEmptyEntries);
                    if (strValues.Length > 0)
                    {
                        nrow = lines.Length;
                        ncol = strValues.Length;
                        dRet = new double[nrow, ncol];
                        for (int r = 0; r < nrow; r++)
                        {
                            string[] strValuesEachLine = lines[r]
                                .Split(new[] {strDelimiter}, StringSplitOptions.RemoveEmptyEntries);
                            for (int c = 0; c < ncol; c++)
                            {
                                dRet[r, c] = Convert.ToDouble(strValuesEachLine[c]);
                            }
                        }
                    }
                }
            }

            return dRet;
        }
    }
}