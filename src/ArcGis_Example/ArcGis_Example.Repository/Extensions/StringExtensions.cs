using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGis_Example.Repository.Extensions
{
    static class StringExtensions
    {
        public static string RemoveQuotes(this string input)
        {
            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                return input.Substring(1, input.Length - 2);
            }

            return input;
        }
    }
}
