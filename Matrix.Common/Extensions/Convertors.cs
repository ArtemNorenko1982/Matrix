using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix.Common.Extensions
{
    public static class Converters
    {
        public static int[,] ConvertToArray(this List<List<int>> listData)
        {
            try
            {
                var rawResult = listData.ToArray();
                int[,] result = new int[rawResult.Length, rawResult.GetLength(0)];

                for (int i = 0; i < rawResult.Length; i++)
                {
                    for (int j = 0; j < rawResult.GetLength(0); j++)
                    {
                        result[i, j] = rawResult[i].ElementAt(j);
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static List<List<int>> ConvertToList(this int[,] arrayData)
        {
            try
            {
                List<List<int>> result = new List<List<int>>();
                for (int i = 0; i < arrayData.GetLength(0); i++)
                {
                    if (i < arrayData.Length)
                    {
                        result.Add(new List<int>());
                    }

                    for (int j = 0; j < arrayData.GetLength(0); j++)
                    {
                        result[i].Add(arrayData[i, j]);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
