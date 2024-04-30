using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public static class Extensions
    {
        public static int Pow(this int bas, int exp)
        {
            return Enumerable.Repeat(bas, exp).Aggregate(1, (a, b) => a * b);
        }
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
   
}
