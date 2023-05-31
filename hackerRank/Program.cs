using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace hackerRank
{
    class Program
    {

        /*
         * Complete the 'birthdayCakeCandles' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY candles as parameter.
         */
        public static int birthdayCakeCandles(List<int> candles)
        {
            var maxHeight = candles.Max();
            var counter = candles.Count(x => x == maxHeight);
            return counter;
        }
        
        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static void miniMaxSum(List<int> arr)
        {
            arr.Sort();
            var totalLowest =  long.Parse(arr[0].ToString()) 
                               + long.Parse(arr[1].ToString()) 
                               + long.Parse(arr[2].ToString()) 
                               + long.Parse(arr[3].ToString());
            arr.Reverse();
            var totalHighest = long.Parse(arr[0].ToString())  + long.Parse(arr[1].ToString()) 
                                                              + long.Parse(arr[2].ToString()) 
                                                              + long.Parse(arr[3].ToString());
            Console.WriteLine(totalLowest+ " " + totalHighest);
        }
        
        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */
        public static string timeConversion(string s)
        {
            var splitSArray = s.Split(":");
            if (splitSArray[2].Contains("PM"))
            {
                splitSArray[0] = (int.Parse(splitSArray[0]) + 12).ToString();
                splitSArray[2] = splitSArray[2].ToString().Replace("PM", "");

                if (splitSArray[0].Contains("24"))
                {
                    splitSArray[0] = "12";
                }
            }

            if (splitSArray[2].Contains("AM"))
            {
                if (splitSArray[0] == "12")
                {
                    splitSArray[0] = "00";
                }
                splitSArray[2] = splitSArray[2].ToString().Replace("AM", "");
            }

            var test = splitSArray[0] + ":" + splitSArray[1] + ":" + splitSArray[2];
            return test;
        }
        
        /*
        * Complete the 'staircase' function below.
        *
        * The function accepts INTEGER n as parameter.
        */
        public static void staircase(int n)
        {

            List<List<string>> staircase = new List<List<string>>();
            for (int i= 1; i <= n; i++)
            {
                staircase.Add(new List<string>());
            }

            var lettersPerRow = 1;

            
            for (int i = 0; i <= n-1; i++)
            {
                while(staircase[i].Count < lettersPerRow)
                {
                    staircase[i].Add("#");
                }
                lettersPerRow++;
            }
            
            // I know how many rows I have (staircase.count)
            for (int i = 0; i < staircase.Count; i++)
            {
                while(staircase[i].Count < n)
                {
                    staircase[i].Add(" ");
                }
            }
            
            for (int i = 0; i < staircase.Count; i++)
            {
                staircase[i].Reverse();
            }

            foreach (List<string> singleStair in staircase)
            {
                foreach (string s in singleStair)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
                    
            }
        }
        
        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */
        public static int diagonalDifference(List<List<int>> arr)
        {
            int rowsColumns = arr.Count;
            List<int> absDiffLeftToRight = new List<int>();
            List<int> absDiffRightToLeft = new List<int>();

            int firstLastvalue = 0;
            
            // get value of rowsColums
            // get lastValue of array 0 value rowsColumns
            // get lastValue-1 of array 1 value rowsColumns
            int counter = rowsColumns;

            foreach (List<int> singleArray in arr)
            {
                while (counter >= 0)
                {
                    absDiffLeftToRight.Add(singleArray[counter-1]);
                    counter--;
                    break;
                }
            }

            counter = 0;
            
            foreach (List<int> singleArray in arr)
            {
                while (counter <= rowsColumns)
                {
                    absDiffRightToLeft.Add(singleArray[counter]);
                    counter++;
                    break;
                }
            }

            var test = absDiffLeftToRight.AsQueryable().Sum() - absDiffRightToLeft.AsQueryable().Sum();
            if (test < 0)
            {
                
            }
            return Math.Abs(test);
        }
        
        /*
         * Complete the 'aVeryBigSum' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER_ARRAY ar as parameter.
         */
        public static long aVeryBigSum(List<long> ar)
        {
            int ArCount = ar.Count;
            long total = 0;
            foreach (long b in ar)
            {
                total += b;
            }

            return total;

        }
        
        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static void plusMinus(List<int> arr)
        {
            int positives = 0;
            int negatives = 0;
            int zeroes = 0;


            for (int i = 0; i < arr.Count; i++)
            {
                switch (arr[i])
                {
                    case 0:
                        zeroes++;
                        break;
                
                    case >=1:
                        positives++;
                        break;
                
                    case <0:
                        negatives++;
                        break;
                }
            }
            double posRatio = double.Parse(positives.ToString()) / double.Parse(arr.Count.ToString());
            double negRatio = double.Parse(negatives.ToString()) / double.Parse(arr.Count.ToString());
            double zeroRatio = double.Parse(zeroes.ToString()) / double.Parse(arr.Count.ToString());

            Console.WriteLine(posRatio.ToString("0.000000"));
            Console.WriteLine(negRatio.ToString("0.000000"));
            Console.WriteLine(zeroRatio.ToString("0.000000"));
        }
        
        public static void Main()
        {
            /*
            List<int> arr = new List<int>();
            arr.Add(-4);
            arr.Add(3);
            arr.Add(-9);
            arr.Add(0);
            arr.Add(4);
            arr.Add(1);
            plusMinus(arr);
            */
        }
    }
}