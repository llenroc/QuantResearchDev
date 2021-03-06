﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon.Data.Extender
{
    public static class List
    {
        public static double Mean(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.Mean(0, values.Count);
        }

        public static double Mean(this List<double> values, int start, int end)
        {
            double s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }


        public static ObservableCollection<T> Purge<T>(this ObservableCollection<T> list)
        {
            var temp = list;
            try
            {
                if (temp.Count() > Moon.Global.Shared.MaxLiveListTick)
                {
                    for (int i = Global.Shared.MaxLiveListTick; i < temp.Count(); i++)
                    {
                        temp.RemoveAt(0);
                    }
                }

            }
            catch (Exception ex) { }


            return temp;
        }

        public static List<T> Purge<T>(this List<T> list)
        {
            if (list.Count() > Moon.Global.Shared.MaxLiveListTick)
            {
                for (int i = Global.Shared.MaxLiveListTick; i < list.Count(); i++)
                {
                    list.RemoveAt(0);
                }
            }

            return list;

            return list;
        }

        public static decimal Mean(this List<decimal> values)
        {
            return values.Count == 0 ? 0 : values.Mean(0, values.Count);
        }

        public static decimal Mean(this List<decimal> values, int start, int end)
        {
            decimal s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }

    }
}
