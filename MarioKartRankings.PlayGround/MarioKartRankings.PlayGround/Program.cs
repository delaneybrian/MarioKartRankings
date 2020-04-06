using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace MarioKartRankings.PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var odm = new OffenceDefenceMethod();

            odm.Calculate();

            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
    }
}
