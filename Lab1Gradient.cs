using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MMCLabs
{
    class Lab1 : ILabs   
    {
        private const double _EPSILON = 0.000001;

        private double _Function(double x, double y)
        { 
            return (4 * x * x) + (x * y) + (2 * y * y) - x - (2 * y); 
        }

        private double _XGradient(double x, double y)
        {
            return (8 * x) + y - 1;
        }

        private double _YGradient(double x, double y)
        {
            return x + (4 * y) - 2;
        }

       private double _FunctionMagnitude(double x, double y)
        {
            return Math.Sqrt((_XGradient(x, y) * _XGradient(x, y)) + (_YGradient(x, y) * _YGradient(x, y)));
        }

        private void _PrintLocalMinimum(double x, double y)
        {

            double Lambda = 1;
            int k = 0;
            double X0 = _Function(x, y);

            double Zx ;
            double Zy ;

            double Z ;

            Console.WriteLine($"Pentru k = {k} in care || X = {x} || -- || Y = {y} || => F(x) = {X0}\n -------------");

            while (_FunctionMagnitude(x, y) > _EPSILON) 
            {                  
                
                    Zx = x - (Lambda * _XGradient(x, y));
                    Zy = y - (Lambda * _YGradient(x, y));

                    Z = _Function(Zx, Zy);
                    
                        if (Z - X0 <= -0.06 * Lambda * _FunctionMagnitude(x, y) * _FunctionMagnitude(x, y))
                        {
                            x = Zx;
                            y = Zy;
                            X0 = _Function(x, y);
                            k++;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Pentru k = {k} in care || X = {x} || -- || Y = {y} || => F(x) = {Z}");
                            Thread.Sleep(550);
                            continue;
                        }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Punctele pretendente || X = {Zx} || -- || Y = {Zy} || F(x) = {Z} ||   nu satisfac conditia !");

                    Lambda /= 2;                  
            } 

        }

        public void LabInterface()
        {
            _PrintLocalMinimum(1, 1);
        }
    }
}
