using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Complex = System.Numerics.Complex;

namespace MarioKartRankings.PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<int, string>()
            {
                {0, "Brian"},
                {1, "John"},
                {2, "Dave"},
                {3, "Chris"},
                {4, "Carl"},
            };

            var scores = DenseMatrix.OfArray(new double[,]
            {
                {0, 40, 40, 40, 40},
                {30, 0, 30, 30, 30},
                {20, 20, 0, 20, 20},
                {10, 10, 10, 0, 10},
                {5, 5, 5, 5, 0}
            });

            //var test = DenseMatrix.OfArray(new double[,]
            //{
            //    {1, 2, 3, 4, 5},
            //    {5, 7, 8, 9, 10},
            //    {11, 12, 13, 14, 15},
            //    {16, 17, 18, 19, 20},
            //    {21, 22, 23, 24, 25}
            //});

            var M = Matrix<double>.Build;
            var skewedm = M.Dense(5, 5);

            for (var i = 0; i < scores.RowCount; i++)
            {
                for (int j = 0; j < scores.ColumnCount; j++)
                {
                    var Sij = scores[i, j];
                    var Sji = scores[j, i];

                    var value = (Sij + 1) / (Sij + Sji + 2);
                    var skewedValue = Skew(value);
                    skewedm[i, j] = skewedValue;
                }
            }

            Evd<double> eigen = skewedm.Evd();
            Vector<Complex> eigenvector = eigen.EigenValues;
        }

        private static double Skew(double value)
        {
            return 0.5 + (Math.Sign(value - 0.5) * Math.Sqrt(Math.Abs((2 * value) - 1)) / 2);
        }
    }
}
