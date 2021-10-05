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

            //List<(int, double)> rankAndRealList = RankAndRealList;

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
            data = data.Replace("X^", " ");
            data = data.Replace('+', ' ');
            data = data.Replace(".", ",");
            data = data.Replace("-", " -");

            string[] dates = data.Split();

            List<(int, double)> rankAndRealList = new List<(int, double)>();

            if (dates.Length % 2 != 0)
                throw new ArgumentException();


            int index = 0;

            (int, double) temp = (0, 0);

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

        public static Polynom operator +(Polynom first, Polynom second)
        {
            List<(int, double)> RankAndRealList = new List<(int, double)>();

            (int, double) temp = (0, 0);

            bool res = true;

            foreach (var item in first.RankAndRealList)
            {
                res = true;
                foreach (var item2 in second.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        temp.Item1 = item.Item1;

                        temp.Item2 = item.Item2 + item2.Item2;

                        RankAndRealList.Add(temp);
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            foreach (var item in second.RankAndRealList)
            {
                res = true;
                foreach (var item2 in first.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            return new Polynom(RankAndRealList);
        }

        public static Polynom operator -(Polynom first, Polynom second) 
        {
            List<(int, double)> RankAndRealList = new List<(int, double)>();

            (int, double) temp = (0, 0);

            bool res = true;
            foreach (var item in first.RankAndRealList)
            {
                res = true;
                foreach (var item2 in second.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        temp.Item1 = item.Item1;

                        temp.Item2 = item.Item2 - item2.Item2;

                        RankAndRealList.Add(temp);
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            foreach (var item in second.RankAndRealList)
            {
                res = true;
                foreach (var item2 in first.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            return new Polynom(RankAndRealList);
        }
        public Polynom(string data)
        {

            RankAndRealList = new List<(int, double)>(Polynom.Parse(data).RankAndRealList);
        }

        public double this[int Rank]
        {
            get
            {
                foreach (var item in RankAndRealList)
                {
                    if (item.Item1 == Rank)
                    {
                        return item.Item2;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                int index = -1;
                for (int i = 0; i < RankAndRealList.Count; i++)
                {
                    if (RankAndRealList[i].Item1 == Rank)
                    {
                        index = i;
                        break;
                    }
                }
                (int, double) temp;
                if (value == 0 && index == -1)
                {

                }
                else if (index == -1 && value != 0)
                {
                    temp.Item1 = Rank;

                    temp.Item2 = value;

                    RankAndRealList.Add(temp);
                }
                else if (index != -1 && value == 0)
                {
                    RankAndRealList.RemoveAt(index);
                }
                else if (index != -1 && value != 0)
                {
                    RankAndRealList[index] = (Rank, value);
                }
            }
        }

        public string PrintMenu()
        {
            return "\n[1]Print Polynom 1\t[2]Print Polynom 2\n[3]Add\t\t\t[4]Subtraction\n[5]Change coefficient\t[0] Exit\n";
        }
    }
}
