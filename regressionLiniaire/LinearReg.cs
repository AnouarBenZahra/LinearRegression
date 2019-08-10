using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace regressionLiniaire
{
    public class LinearReg
    {
        public Informations LinearRegression(List<Point> points)
        {
            Informations info = new Informations();        
            info.A = points.vari(k=> k.X, k => k.Y) / points.vari(p => p.X, p => p.X);
            info.B = points.Average(k => k.Y) - info.A * points.Average(k => k.X);
            info.X = points.Select(p => p.X).Average();
            info.Y = points.Select(p => p.Y).Average();
            return info;
            // ax+b
        }
    }    

    public static class Extension
    {
        public static double vari<T>(this IEnumerable<T> array, Func<T, double> A, Func<T, double> B)
        {
            var res= array.Average(p => A(p) * B(p)) - (array.Average(p => A(p)) * array.Average(p => B(p)));
            if (res != 0)
            {
                return res;
            }
            return 0;

        }
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public struct Informations
    {
        public double A { get; set; }
        public double B { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
    }

}
