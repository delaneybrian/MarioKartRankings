using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace MarioKartRankings.PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<double> v = Matrix<double>.Build.Dense(3, 3, 1.0);

            Matrix<double> g = Matrix<double>.Build.Dense(3, 3, 2.0);

            var a = g + v;



            MarkovMethod.Calculate();

            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
    }
}
