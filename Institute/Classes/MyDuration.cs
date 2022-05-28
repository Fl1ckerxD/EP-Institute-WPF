using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.Classes
{
    class MyDuration
    {
        private static readonly int[] num = { 2, 3, 4 };
        internal static string ConnectDate(string y, string m)
        {
            return String.Format("{0} {1}", SelectYear(y), SelectMonth(m));
        }
        private static string SelectMonth(string m)
        {
            if (m != null)
            {
                for (int i = 0; i < num.Length; i++)
                {
                    if (Convert.ToInt32(m) == num[i])
                        return m + " месяца";
                    else if (Convert.ToInt32(m) >= 5)
                        return m + " месяцев";
                }
                return m + " месяц";
            }
            return null;
        }
        private static string SelectYear(string y)
        {
            if (y != null)
            {
                for (int i = 0; i < num.Length; i++)
                {
                    if (Convert.ToInt32(y) == num[i])
                        return y + " года";
                    else if (Convert.ToInt32(y) >= 5)
                        return y + " лет";
                }
                return y + " год";
            }
            return null;
        }
        static internal string OutputYear(string y)
        {
            string[] split = y.Split(' '); // 1_year_2_month
            return split[0];
        }
        static internal string OutputMonth(string m)
        {
            string[] split = m.Split(' '); // 1_year_2_month
            if (split.Length >= 3)
                return split[2];
            return null;
        }
    }
}
