using System;

namespace MMC1
{
    class Program
    {
        void PrintResults(ILabs myLab)
        {
            myLab.Display();
        }   

        public static void Main(string[] args)
        {
            Program program = new Program();


            program.PrintResults(new SplitIntMethod());
            program.PrintResults(new AproxMethod());
            program.PrintResults(new NewtonMethod());
        }
    }
}
