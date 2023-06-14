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
using System.Reflection.Metadata.Ecma335;

namespace hackerRank
{
    class Program
    {
        
        /*
         * Complete the 'timeInWords' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. INTEGER h
         *  2. INTEGER m
         */
        public static string timeInWords(int h, int m)
        {
            Dictionary<int, string> hours = new Dictionary<int, string>();
            hours.Add(1, "one");
            hours.Add(2, "two");
            hours.Add(3, "three");
            hours.Add(4, "four");
            hours.Add(5, "five");
            hours.Add(6, "six");
            hours.Add(7, "seven");
            hours.Add(8, "eight");
            hours.Add(9, "nice");
            hours.Add(10, "ten");
            hours.Add(11, "eleven");
            hours.Add(12, "twelve");

            Dictionary<int, string> minutes = new Dictionary<int, string>();
            minutes.Add(0, "o'clock");
            minutes.Add(1, "one");
            minutes.Add(2, "two");
            minutes.Add(3, "three");
            minutes.Add(4, "four");
            minutes.Add(5, "five");
            minutes.Add(6, "six");
            minutes.Add(7, "seven");
            minutes.Add(8, "eight");
            minutes.Add(9, "nine");
            minutes.Add(10, "ten");
            minutes.Add(11, "eleven");
            minutes.Add(12, "twelve");
            minutes.Add(13, "thirteen");
            minutes.Add(14, "fourteen");
            minutes.Add(15, "quarter");
            minutes.Add(16, "sixteen");
            minutes.Add(17, "seventeen");
            minutes.Add(18, "eighteen");
            minutes.Add(19, "nineteen");
            minutes.Add(20, "twenty");
            minutes.Add(21, "twenty one");
            minutes.Add(22, "twenty two");
            minutes.Add(23, "twenty three");
            minutes.Add(24, "twenty four");
            minutes.Add(25, "twenty five");
            minutes.Add(26, "twenty six");
            minutes.Add(27, "twenty seven");
            minutes.Add(28, "twenty eight");
            minutes.Add(29, "twenty nine");
            minutes.Add(30, "thirty");
            minutes.Add(31, "thirty one");
            minutes.Add(32, "thirty two");
            minutes.Add(33, "thirty three");
            minutes.Add(34, "thirty four");
            minutes.Add(35, "thirty five");
            minutes.Add(36, "thirty six");
            minutes.Add(37, "thirty seven");
            minutes.Add(38, "thirty eight");
            minutes.Add(39, "thirty nine");
            minutes.Add(40, "forty");
            minutes.Add(41, "forty one");
            minutes.Add(42, "forty two");
            minutes.Add(43, "forty three");
            minutes.Add(44, "forty four");
            minutes.Add(45, "forty five");
            minutes.Add(46, "forty six");
            minutes.Add(47, "forty seven");
            minutes.Add(48, "forty eight");
            minutes.Add(49, "forty nine");
            minutes.Add(50, "fifty");
            minutes.Add(51, "fifty one");
            minutes.Add(52, "fifty two");
            minutes.Add(53, "fifty three");
            minutes.Add(54, "fifty four");
            minutes.Add(55, "fifty five");
            minutes.Add(56, "fifty six");
            minutes.Add(57, "fifty seven");
            minutes.Add(58, "fifty eight");
            minutes.Add(59, "fifty nine");

            string currentHour = hours[h].ToString();

            string returnValue = string.Empty;
            // This could be done much better
            switch (m)
            {
                case 1:
                    returnValue = "one minute past " + currentHour;
                    break;
                case 15:
                    returnValue = minutes[m] + " past " + hours[h];
                    break;
                case > 1:
                    if (m < 30)
                    {
                        returnValue = minutes[m] + " minutes past " + hours[h];    
                    }
                    else
                    {
                        if (m == 30)
                        {
                            returnValue = "half past " + currentHour;
                        }
                        else
                        {
                            int difference = 60 - m;
                            if (difference == 15)
                            {
                                returnValue = minutes[difference] + " to " + (hours[h+1]);
                            }
                            else
                            {
                                returnValue = minutes[difference] + " minutes to " + (hours[h+1]); 
                            }
                        }
                    }
                    break;
               
                case 0:
                    returnValue = currentHour + " o' clock";
                    break;
            }
            return returnValue;
        }
        
        /*
         * Complete the 'gradingStudents' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY grades as parameter.
         */
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> output = new List<int>();
            
            foreach (int i in grades)
            {
                // If the value of  is less than , no rounding occurs as the result will still be a failing grade.
                if (i < 38)
                {
                    output.Add(i);
                }
                else
                {
                    int tempScore = i;
                    int counter = 0;
                    int maxCounter = 2;

                    if (i % 5 == 0)
                    {
                        output.Add(i);
                    }
                    else
                    {
                        while (tempScore % 5 != 0)
                        {
                            tempScore++;
                            counter++;
                        }

                        if (counter <= maxCounter && tempScore % 5 == 0)
                        {
                            output.Add(tempScore);
                        }
                        else
                        {
                            output.Add(i);
                        }
                    }
     
                }
            }
            return output;
        }
        
        
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> finalResponse = new List<int>();
            var uniqueRanked = ranked.Distinct().ToList();
            int n = uniqueRanked.Count;
            int j = n - 1;

            foreach (int score in player)
            {
                while (j >= 0 && score >= uniqueRanked[j])
                {
                    j--;
                }

                finalResponse.Add(j + 2);
            }
            return finalResponse;
        }

        public static int birthdayCakeCandles(List<int> candles)
        {
            var maxHeight = candles.Max();
            var counter = candles.Count(x => x == maxHeight);
            return counter;
        }
        
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
            Console.WriteLine(timeInWords(4, 15));
            



        }
    }
}