using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;

namespace MarioKartRankings.PlayGround
{
    public class ColleysMethod
    {
        public static void Calculate()
        {
            var C = Matrix<double>.Build.Dense(5, 5, new[]
            {
               6D, -1, -1, -1, -1,
                -1, 6, -1, -1, -1,
                -1, -1, 6, -1, -1,
                -1, -1, -1, 6, -1,
                -1, -1, -1, -1, 6
            });

            var b = Vector<double>.Build.Dense(new double[] {-1, 3, 1, 0, 2});

            var r = MultipleRegression.NormalEquations(C, b);
        }
    }
}
