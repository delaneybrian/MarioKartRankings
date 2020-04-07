using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Complex = System.Numerics.Complex;

namespace MarioKartRankings.PlayGround
{
    public static class MarkovMethod
    {
        public static void Calculate()
        {
            var directory = Directory.GetCurrentDirectory();

            var fileLocation = Path.Combine(directory, "markov.csv");

            var fileTextContents = File.ReadAllLines(fileLocation);

            var teams = fileTextContents[0].Split(',');

            var resultsMatrix = DelimitedReader.Read<double>(fileLocation, false, ",", true);

            var rowCount = resultsMatrix.RowCount;

            var values = new List<double>();

            for (var i = 0; i < rowCount; i++)
            {
                var row = resultsMatrix.Row(i);

                var sum = row.Sum();

                if (sum == 0)
                {
                    Console.WriteLine("Row is 0");
                }

                foreach (var value in row.AsArray())
                {
                    if (sum == 0)
                        values.Add( 1 / (double) row.Count);
                    else
                        values.Add(value / sum);
                }
            }

            var markovMatrix = Matrix<double>
                .Build
                .Dense(
                resultsMatrix.RowCount, 
                resultsMatrix.ColumnCount, 
                values.ToArray());

            //var markovMatrix = Matrix<double>.Build.Dense(5, 5, new []
            //    {     0.00, 0.25, 0.25, 0.25, 0.25, 
            //          0.20, 0.20, 0.20, 0.20, 0.20, 
            //          0.00, 0.50, 0.00, 0.00, 0.50, 
            //          0.00, 0.33, 0.33, 0.00, 0.33, 
            //          0.00, 1.00, 0.00, 0.00, 0.00});

            //var markovMatrixTranspose = markovMatrix
            //    .Transpose();

            var markovMatrixTransposeEigen = markovMatrix
                .Evd();

            var markovMatrixTransposeEigenTranspose = markovMatrixTransposeEigen
                .EigenVectors
                .Transpose()
                .Row(0);

            var stationaryVector = markovMatrixTransposeEigenTranspose / markovMatrixTransposeEigenTranspose.Sum();

            var a = 1;
        }
    }
}
