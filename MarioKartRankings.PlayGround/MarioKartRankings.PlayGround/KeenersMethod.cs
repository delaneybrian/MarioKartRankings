using System;
using System.IO;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Complex = System.Numerics.Complex;

namespace MarioKartRankings.PlayGround
{
    public static class KeenersMethod
    {
        public static void Calculate()
        {
            var directory = Directory.GetCurrentDirectory();

            var fileLocation = Path.Combine(directory, "nflnoheadings.csv");

            var fileTextContents = File.ReadAllLines(fileLocation);

            var teams = fileTextContents[0].Split(',');

            var resultsMatrix = DelimitedReader.Read<double>(fileLocation, false, ",", true);

            var M = Matrix<double>.Build;
            var skewedm = M.Dense(resultsMatrix.RowCount, resultsMatrix.ColumnCount);

            for (var i = 0; i < resultsMatrix.RowCount; i++)
            {
                for (int j = 0; j < resultsMatrix.ColumnCount; j++)
                {
                    var Sij = resultsMatrix[i, j];
                    var Sji = resultsMatrix[j, i];

                    var value = (Sij + 1) / (Sij + Sji + 2);
                    var skewedValue = Skew(value);
                    skewedm[i, j] = skewedValue;
                }
            }

            var eigen = skewedm.Evd();
            var eigenValues = eigen.EigenValues;
            var eigenValue = eigen.EigenVectors.Column(0);

            //forceToSumToOne
            var sum = eigenValue.Sum();

            for (var i = 0; i < eigenValue.Count; i++)
            {
                var actualRating = eigenValue[i] / sum;
                Console.Write($"{teams[i]} - {actualRating}\n");
            }
        }

        private static double Skew(double value)
        {
            return 0.5 + (Math.Sign(value - 0.5) * Math.Sqrt(Math.Abs((2 * value) - 1)) / 2);
        }
    }
}
