using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;

namespace MarioKartRankings.PlayGround
{
    public static class MasseysMethod
    {
        public static void Calculate()
        {
            var M = Matrix<double>.Build.Dense(5, 5, new[]
            {
                4D, -1, -1, -1, -1,
                -1, 4, -1, -1, -1,
                -1, -1, 4, -1, -1,
                -1, -1, -1, 4, -1,
                1, 1, 1, 1, 1
            });

            var p = Vector<double>.Build.Dense(new double[] { -124.0, 91.0, -40.0, -17.0, 0.0 });


            var r = MultipleRegression.NormalEquations(M, p);

        }
    }
}
