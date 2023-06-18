using System.Text;

namespace hackerRank
{
    class Program
    {
        /// <summary>
        /// Tests
        /// </summary>
        public static void Main()
        {

        }
        
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int applesFallsInHouse = 0;
            int orangesFallsInHouse = 0;

            int houseStartingPoint = s;
            int houseEndingLocation = t;
            int appleTreeLocation = a;
            int orangeTreeLocation = b;

            for (int appleLocation = 0; appleLocation < apples.Count; appleLocation++)
            {
                if ((apples[appleLocation]+appleTreeLocation >= houseStartingPoint && (apples[appleLocation]+appleTreeLocation <= houseEndingLocation)))
                {
                    applesFallsInHouse++;
                }
            }
            
            for (int orangeLocation = 0; orangeLocation < oranges.Count; orangeLocation++)
            {
                if (oranges[orangeLocation]+orangeTreeLocation >= houseStartingPoint && 
                    (oranges[orangeLocation]+orangeTreeLocation <= houseEndingLocation))
                {
                    orangesFallsInHouse++;
                }
            }
            Console.WriteLine(applesFallsInHouse.ToString());
            Console.WriteLine(orangesFallsInHouse.ToString());
        }
        
        public static int binaryZeroGapCounter(int N) {
        
            int counter = 0;
            int maxSequence = 0;
            bool previousZero = false;

            // find binary representation of 
            string NToBinary = Convert.ToString(N, 2);
            
            // convert it to an array
            char[] NArray = NToBinary.ToCharArray();
            // loop array and count the consecutive 0
            for (int i = 0; i < NArray.Length; i++)
            {
                int tempConvert = int.Parse(NArray[i].ToString());
                if (tempConvert == 0)
                {
                    counter++;
                    previousZero = true;
                }
                
                if (tempConvert == 1 && previousZero)
                {
                    if (counter > maxSequence)
                    {
                        maxSequence = counter;    
                    }
                    previousZero = false;
                    counter = 0;
                }
            }
            return maxSequence;
        }

        public static List<int> breakingRecords(List<int> scores)
        {
            int counterImproved = 0;
            int counterWorst = 0;
            int currentRecord = 0;
            int currentWorst = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                if (i == 0)
                {
                    currentRecord = scores[i];
                    currentWorst = scores[i];
                }
                
                if (scores[i] > currentRecord)
                {
                    currentRecord = scores[i];
                    counterImproved++;
                }
                
                if (scores[i] < currentRecord)
                {
                    if (scores[i] < currentWorst)
                    {
                        counterWorst++;
                        currentWorst = scores[i];
                    }
                }
            }
            
            List<int> returnResult = new List<int>(){counterImproved, counterWorst};
            return returnResult;
        }
        
        public static string dayOfProgrammer(int year)
        {
            string returnValue = string.Empty;
            bool leapYear = false;
            switch (year)
            {
                case <= 1917: // julian
                    if (year % 4 == 0) // leap year
                    {
                        leapYear = true;
                    }
                    break;
                
                case 1918:
                    return "26.09.1918";
                    break;
                
                case >=1919: // gregorian
                    if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) // leap year
                    {
                        leapYear = true;
                    }
                    break;
            }

            if (leapYear)
            {
                returnValue = "12.09." + year.ToString();
            }
            else
            {
                returnValue = "13.09." + year.ToString();
            }
            return returnValue;
        }

        private static bool isAlreadySorted(List<int> arr)
        {
            var sortedArray = arr.OrderBy(x => x);
            return arr.SequenceEqual(sortedArray);
        }
        
        public static string larrysArray(List<int> A)
        {
            int lenArrayA = A.Count;
            int timesValueIsNotInorder = 0;
            for (int i = 0; i < lenArrayA; i++)
            {
                for (int ii = i + 1; ii < lenArrayA; ii++)
                {
                    if (A[i] > A[ii])
                    {
                        timesValueIsNotInorder++;
                    }
                }
            }
            
            if (timesValueIsNotInorder % 2 == 0)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }

        }

        public static int getTotalX(List<int> a, List<int> b)
        {
            HashSet<int> firstArray = new HashSet<int>(a);
            HashSet<int> secondArray = new HashSet<int>(b);

            int trackerOfOccurrences = 0;

            int maximumOfArrayA = firstArray.Max();
            int minimumOfArrayB = secondArray.Min();

            for (int i = maximumOfArrayA; i <= minimumOfArrayB; i++)
            {
                bool conditionForArrayA = true;
                bool conditionForArrayB = true;
                
                // loop array A and see if each value is a factor of i
                foreach (int currentNumberInArrayA in firstArray)
                {
                    if (i % currentNumberInArrayA != 0)
                    {
                        conditionForArrayA = false;
                        break;
                    }
                }
                
                // The integer being considered is a factor of all elements of the second array
                foreach (int currentNumberInArrayB in secondArray)
                {
                    if (currentNumberInArrayB % i != 0)
                    {
                        conditionForArrayB = false;
                        break;
                    }
                }
                
                // they should both be true
                if (conditionForArrayA && conditionForArrayB)
                {
                    trackerOfOccurrences++;
                }
            }
            return trackerOfOccurrences;
        }
        
        public static string gridSearch(List<string> G, List<string> P)
        {
            int rows = G.Count;
            int cols = G[0].Length;
            int patternRows = P.Count;
            int patternCols = P[0].Length;

            for (int i = 0; i <= rows - patternRows; i++) {
                for (int j = 0; j <= cols - patternCols; j++) {
                    if (G[i][j] == P[0][0]) {
                        bool patternMatch = true;
                        for (int k = 0; k < patternRows; k++) {
                            for (int l = 0; l < patternCols; l++) {
                                if (G[i + k][j + l] != P[k][l]) {
                                    patternMatch = false;
                                    break;
                                }
                            }
                            if (!patternMatch) {
                                break;
                            }
                        }
                        // If pattern matches, return "YES"
                        if (patternMatch) {
                            return "YES";
                        }
                    }
                }
            }

            // If pattern is not found, return "NO"
            return "NO";
        }
        
        public static int solution(int[] A)
        {
            int returnValue = 1;
            HashSet<int> arrayOfPositives = new HashSet<int>();
            
            // create array of positives from input A
            foreach (int numberInArrayA in A)
            {
                // only add positives to the Hashset
                if (numberInArrayA > 0)
                {
                    arrayOfPositives.Add(numberInArrayA);
                }
            }

            if (arrayOfPositives.Count == 0)  { return returnValue; }
            else
            {
                int maxValue = arrayOfPositives.Max();
                for (int testSmallValue = 1; testSmallValue <= maxValue+1; testSmallValue++)
                {
                    if (!arrayOfPositives.Contains(testSmallValue))
                    {
                        return testSmallValue;
                    }
                } 
            }

            return returnValue;
        }
       
        public static string encryption(string s)
        {
            var inputString = s.Replace(" ", "");
            int stringLength = inputString.Length;

            int rows = (int)Math.Sqrt(stringLength);
            int columns = (int)Math.Ceiling(Math.Sqrt(stringLength));

            List<string> grid = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                int startIndex = i * columns;
                int length = Math.Min(columns, stringLength - startIndex);
                string lineToAddToGrid = inputString.Substring(startIndex, length);
                grid.Add(lineToAddToGrid);
            }

            StringBuilder output = new StringBuilder();

            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (column < grid[row].Length)
                    {
                        output.Append(grid[row][column]);
                    }
                }

                output.Append(" ");
            }

            return output.ToString().Trim();
        }
        
        public static string organizingContainers(List<List<int>> container)
        {
            int n = container.Count;
            int[] containerCapacity = new int[n];
            int[] ballCount = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    containerCapacity[i] += container[i][j];
                    ballCount[j] += container[i][j];
                }
            }

            Array.Sort(containerCapacity);
            Array.Sort(ballCount);

            if (containerCapacity.SequenceEqual(ballCount))
            {
                return "Possible";
            }
            else
            {
                return "Impossible";
            }
        }
        
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
    }
}