using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_L4_EventsDelegates
{
    internal class Calculator
    {
        public int FirstSum = 0;
        public int SecSum = 0;

        public delegate void SumHandler(int first, int second);
        public event SumHandler Handler;

        public void Start()
        {
            Console.WriteLine("Here we add two numbers");

            int firstNum = new Random().Next(100);
            Console.WriteLine("First number is " + firstNum);

            int secondNum = new Random().Next(100);
            Console.WriteLine("Second number is " + secondNum);

            Handler += Adding;
            Handler += Adding;

            if (Handler != null)
            {
                Handler(firstNum, secondNum);
                Console.WriteLine(FirstSum + " " + SecSum);
            }

            SpecMethod();
        }

        private void Adding(int first, int second)
        {
            var result = first + second;

            if (FirstSum == 0)
            {
                FirstSum = result;
            }
            else
            {
                SecSum = result;
            }
        }

        public int SumMethod(int one, int two)
        {
            var result = one + two;
            return result;
        }

        public void SpecMethod()
        {
            try
            {
                int sumResult = SumMethod(FirstSum, SecSum);
                Console.WriteLine("Result sum is" + sumResult);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.TargetSite);
            }
        }

    }
}
