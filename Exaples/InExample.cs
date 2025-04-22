using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class AreaCalculator
    {
        public decimal CalculateCircleArea(in decimal radius)
        {
            decimal i = (decimal)Math.PI * (radius * radius);
            return i;
        }
    }

    /// <summary>
    /// in Keyword(Read-Only Parameter)
    /// Used to pass arguments as read-only.
    /// The method cannot modify the parameter value.
    /// </summary>
    public class InExample
    {
        public void Run()
        {
            AreaCalculator calc = new AreaCalculator();
            decimal radius = 5;
            decimal area = calc.CalculateCircleArea(in radius);
            Console.WriteLine($"Area of Circle: {area}");
        }
    }
}
