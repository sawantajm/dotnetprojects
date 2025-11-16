using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractis
{
    public static class Extentions
    {
        public static List<T> Filter<T>(this List<T> recored, Func<T, bool> func)
        {
            List<T> filteredList = new List<T>();
            foreach (T item in recored)
            {
                if (func(item))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }
}
