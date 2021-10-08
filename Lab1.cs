using System;
using System.Threading;

namespace MMC1
{
    class SplitIntMethod : ILabs
    {
        private const double _EPSILON = 0.0001;

        public delegate double Func(double X);

        private double _Func1(double X)
        {
            return (X * X) - Math.Log(X + 1);
        }

        private double _Func2(double X)
        {
            return (X * X * X) + (12 * X) + 4;
        }

        private void _SplitInterval(double A, double B, Func func)
        {

            double C;

            if (func(A) * func(B) < 0)
            {

                do
                {
                    C = (A + B) / 2;

                    Console.WriteLine($"In punctele a = {A} si b = {B} , C = {C} , f(C) = {func(C)}");
               
                    if (func(C) < 0)
                        A = C;

                    else
                        B = C;

                    Thread.Sleep(400);

                } while (func(C) > _EPSILON || func(C) < -_EPSILON);

                Console.WriteLine($"Radacina functiei este C = {C} cu valoarea functiei f(C) = {func(C)}\n");
            }

            else
            {
                Console.WriteLine("Invalid Interval !!\n");
            }
            
        }


        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            _SplitInterval(0.5, 2, _Func1);
            _SplitInterval(-5, 5, _Func2);

            Console.WriteLine(" ------------------------------ \n");
        }
    }


    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    class AproxMethod : ILabs
    {
        private const double _EPSILON = 0.0001;

        public delegate double Func(double X);

        private double _Func1(double X)
        {
            return Math.Sqrt(Math.Log(X + 1));
        }

        private double _Func2(double X)
        {
            return Math.Cbrt((12 * X) + 4);
        }

        private void _SuccAproximations(double X, Func func)
        { 
            double Y = 0, Y0;

            do
            {

                Y0 = Y;
                Y = func(X);                          
                X = Y;

                Console.WriteLine("X(k + 1) =  " + Y + ", X(k) " + X);

                Thread.Sleep(200);
                 
            } while (Math.Abs(Y - Y0) > _EPSILON) ;

            Console.WriteLine("Radacina cautata prin aproximarea succesiva este " + Y + "\n");
        }


        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;


            _SuccAproximations(2, _Func1);
            _SuccAproximations(5, _Func2);

            Console.WriteLine(" ------------------------------ \n");
        }
    }


    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    class NewtonMethod : ILabs
    {
        private const double _EPSILON = 0.0001;

        public delegate double Func(double X);

        private double _Func1(double X)
        {
            return (X * X) - Math.Log(X + 1);
        }

        private double _Func2(double X)
        {
            return (X * X * X) + (12 * X) + 4;
        }

        private double _DerivedFunc1(double X)
        {
            return (2 * X - 1) / (1 + X);
        }

        private double _DerivedFunc2(double X)
        {
            return (2 * X * X) + 12;
        }

        private void _NewtonMethod(double X, Func func, Func derFunc)
        {

            double Y = 0, Y0;

            do
            {
                Y0 = Y;
                Y = X - (func(X) / derFunc(X));
                X = Y;

                Console.WriteLine("X(k + 1) =  " + Y + ", X(k) " + X);

            } while (Math.Abs(Y - Y0) > _EPSILON);

            Console.WriteLine("Radacina cautata dupa metoda Newton este " + Y + "\n");
        }


        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            _NewtonMethod(2, _Func1, _DerivedFunc1);
            _NewtonMethod(5, _Func2, _DerivedFunc2);

            Console.WriteLine(" ------------------------------ \n");
        }
    }

    


}
