using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4
{
    class Polynom
    {
        public List<(int, double)> RankAndRealList { get; set; }

        public Polynom(List<(int, double)> rankAndRealList)
        {
            RankAndRealList = rankAndRealList;
        }

        public override string ToString()
        {
            string res = "";

            RankAndRealList.Sort();
            foreach (var item in RankAndRealList)
            {
                if (res == "")
                {
                    if (item.Item1 == 0 && item.Item2 > 0)
                        res += $"+{item.Item2}X";
                    else if (item.Item1 == 0 && item.Item2 > 0)
                        res += $"{item.Item2}X";
                    else res += $"{item.Item2}X^{item.Item1}";
                }
                else if (item.Item2 == 0)
                    continue;
                else if (item.Item1 == 0 && item.Item2 > 0)
                    res += $"+{item.Item2}";
                else if (item.Item1 == 0 && item.Item2 > 0)
                    res += $"{item.Item2}";
                else if (item.Item2 > 0)
                {
                    res += $"+{item.Item2}X^{item.Item1}";
                }
                else res += $"{item.Item2}X^{item.Item1}";
            }



            return res;
        }

        public static Polynom Parse(string data)
        {
            data = data.Replace("X^"," ");
            data = data.Replace('+', ' ');
            data = data.Replace(".", ",");
            data = data.Replace("-", " -");
            string[] dates = data.Split();
            List<(int, double)> rankAndRealList = new List<(int, double)>();

            int index = 0;
            (int, double) temp=(0,0);

            foreach (var item in dates)
            {
                if (index % 2 == 0)
                    temp.Item2 = double.Parse(item);
                if (index % 2 == 1)
                {
                    temp.Item1 = int.Parse(item);
                    rankAndRealList.Add(temp);
                }
                index++;
            }
            return new Polynom(rankAndRealList);
        }

        public Polynom()
        {
            RankAndRealList = new List<(int, double)>();
        }

    }
}
