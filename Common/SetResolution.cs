using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public static class ResolutionService
    {
        public static decimal SetResolution(decimal value, decimal precision)
        {
            var longPrecision = (long)precision;
            var tmpPrecision = precision;
            var pCounter = 0;
            //while (longPrecision != tmpPrecision)
            //{
            //    pCounter++;
            //    tmpPrecision *= 10;
            //    longPrecision = (long)tmpPrecision;
            //}
            var str = precision.ToString().Split('.');
            pCounter = str.Length > 1 ? str[1].Length : 0;

            var longValue = (long)value;
            var vCounter = 0;
            var tmpValue = value;
            //while (longValue != tmpValue)
            //{
            //    vCounter++;
            //    tmpValue *= 10;
            //    longValue = (long)tmpValue;
            //}
            str = value.ToString().Split('.');
            vCounter = str.Length > 1 ? str[1].Length : 0;

            if (vCounter < pCounter)
            {
                return value;
            }
            var mul = 10.Pow(Math.Max(pCounter, vCounter));
            var result = ((value * mul) - ((value * mul) % (precision * mul))) / mul;
            var strs = precision.ToString().Split('.');
            if (strs.Length>1)
            {
                result = Math.Round(result, strs[1].Length, MidpointRounding.AwayFromZero);
            }

            if (pCounter == 0)
            {
                result = Math.Round(result, 0);
            }
            
            return result;
        }
    }
}
