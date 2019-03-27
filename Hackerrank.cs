using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    class Hackerrank
    {

        #region Warm-up Challenges

        //Sock Merchant
        static int sockMerchant(int n, int[] ar) {
            HashSet<int> cores = new HashSet<int>();
            int pares = 0;

            for (int i = 0; i < n; i++) {
                if (!cores.Add(ar[i])) {
                    pares++;
                    cores.Remove(ar[i]);
                }
            }
            return pares;
        }

        static int sockMerchant2(int n, int[] ar) {
            bool[] cores = new bool[100];
            int pares = 0;

            for (int i = 0; i < n; i++) {
                if (cores[ar[i]]) {
                    pares++;
                    cores[ar[i]] = false;
                } else {
                    cores[ar[i]] = true;
                }
            }
            return pares;
        }

        //Counting Valleys
        static int countingValleys(int n, string s) {
            int level = 0;
            int valleyCount = 0;
            foreach (char c in s) {
                if (c.Equals('U')) {
                    level = level + 1; //if an UP resulted in level 0, Gary just finished a valley
                    if (level == 0) {
                        valleyCount = valleyCount + 1;
                    } 
                } else {
                    level = level - 1;
            } 
        }


        return valleyCount;

    }
        
        //Jumping on the Clouds
        static int jumpingOnClouds(int[] c) {
            int numJumps = 0;
            int i = 0; //she starts at index 0, always a safe spot
            while (i<c.Length)
            {
                if(i+2 < c.Length && c[i+2] == 0) //try to jump 2 spaces, otherwhise, jumps 1
                {
                    i = i + 2;
                } else
                {
                    i = i + 1;
                }
                numJumps = numJumps + 1;
            }
            return numJumps; //because we always count one more jump at while exit
        }

        //Repeated String
        static long repeatedString(string s, long n) {
            long count = 0;

            if (n >= s.Length) //there's repetition 
            {
                //calculate repetitions in base string
                foreach (char c in s)
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }

                //multiply occurencies by factor
                long multiplyfactor = n / s.Length;
                count =  count * multiplyfactor;

                //deal with remaining substring, if it exists
                long remainder = n % s.Length;
                foreach (char c in s.Substring(0,(int)remainder))
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }
            } else //we just count on the substring
            {
                foreach (char c in s.Substring(0,(int)n))
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }
            } 
            return count;
        }
        #endregion

        #region Arrays
        //2D Array - DS
        static int hourglassSum(int[][] arr) {
            int currentHourglass = 0;
            int maxHourglass = -9 * 7; //We start maximum as the minimum hourglass possible

            for (int i = 0; i < 4; i++) //To mount and hourglass we go just to the 4th pos of i
            {
                for (int j = 0; j < 4; j++) //The same above applies to j
                {
                    //Mount Hourglass
                    currentHourglass = 
                        arr[i][j]   + arr[i][j+1]   + arr[i][j+2] + 
                                      arr[i+1][j+1] +
                        arr[i+2][j] + arr[i+2][j+1] + arr[i+2][j+2];
                    //update max if current is bigger
                    if(currentHourglass > maxHourglass)
                    {
                        maxHourglass = currentHourglass;
                    }
                }
            }

            return maxHourglass;
        }

        // Left Rotation
        static int[] rotLeft(int[] a, int d) {
            int[] rotatedArray = new int[a.Length]; //array that will receive rotated ints
            
            for (int i = 0; i < a.Length ; i++) { //foreach item in array, execute d left rotations and put in right position
                int currentItem = a[i];
                int position = 0;

                if (i - d >= 0) //if result position after rotation is >0 we know where to put it on array
                {
                    position = i - d;
                    
                } else //however, if the above result is negative, we should go |i-d| ==> d-i spaces back from last position (size)
                {
                    position = a.Length - (d - i);
                }

                rotatedArray[position] = currentItem;
            }

            return rotatedArray;
        }

        //New Year Chaos
        static void minimumBribes(int[] q) {
        //idea: no person can be more than 2 pos in front of its value/sticker
        //if a person is more than 2 pos in front, stop and print "too chaotic"
        //if a person is in fronf of it's value/sticker count the # of bribes: 1 or 2
        //if a person is behind value pos, ignore. This person has been bribed

            int swaps = 0;
            bool chaotic = false;

            for (int i = 0; i < q.Length; i++)
            {
                //person value/sticker = q[i]
                //person position = i+1 (arrays have 0 index)
                if (i + 1 < q[i]) { //a bribe has occured!
                    if (q[i] - i + 1 > 2) //if more than 2 pos ahead... cheater!
                    {
                        chaotic = true;
                        break;
                    }
                    
                }
            }

            if (!chaotic)
            {
                //bublesort and count # of swaps
                int temp;
                for (int j = 0; j <= q.Length - 2; j++) {
                    for (int i = 0; i <= q.Length - 2; i++) {
                       if (q[i] > q[i + 1]) {
                          temp= q[i + 1];
                          q[i + 1] = q[i];
                          q[i] = temp;
                          swaps += 1;
                    
                       }
                    }
                }
            }
            

            if (chaotic)
            {
                Console.WriteLine("Too chaotic");
            } else
            {
                Console.WriteLine(swaps);
            }

        }

        #endregion

    }
}
