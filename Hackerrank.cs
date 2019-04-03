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
        //Received timeout on hackerhank
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
        static void minimumBribes2(int[] q) {

            int bribes = 0 ; 

            //we compare always 3 values since no one can go more than 2 steps further/ahead
            int mid = int.MaxValue;
            int max =  int.MaxValue;
            int min =  int.MaxValue;

            for(int i=q.Length-1 ; i >= 0 ; i--){ //we start backwards
                if((q[i]-i) > 3 ) { //if ((value - (pos-1)) > 3) more than 2 positions ahead. Cheater!
                    Console.WriteLine("Too chaotic");
                    return;
                }
                else{
                    if(q[i] > max){ //if value > max, not possible!
                         Console.WriteLine("Too chaotic");
                         return;
                    }
                    else if(q[i] > mid){  //if value > mid, moved 2 pos
                        bribes=bribes+2;
                    }
                    else if(q[i] > min){
                        bribes=bribes+1; //if value > min, moved just 1 pos
                    }

                    if(q[i]<min){ //if value < min, update max, mid and min
                        max=mid;
                        mid=min;
                        min = q[i];
                    }
                    else if(q[i]<mid){ //if value < mid, update max and mid (we know it's > min, so it stays the min)
                        max=mid;
                        mid = q[i];
                    }
                    else if(q[i]<max){ //if value < max, update only max (we know it's > min and mid)
                        max = q[i];
                    }
                }
            }
            Console.WriteLine(bribes);
        }

        //Minimum Swaps 2
        static int minimumSwaps(int[] arr) {       
            int n = arr.Length - 1;
            int minSwaps = 0;
            for (int i = 0; i < n; i++) {
                if (i < arr[i] - 1) {
                    swap(arr, i, Math.Min(n, arr[i] - 1));
                    minSwaps++;
                    i--;
                }
            }
            return minSwaps;
        }
        private static void swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        //Array Manipulation
        static long arrayManipulation(int n, int[][] queries) {
        //idea: go adding values to the array and updating max if necessary. Return max
            long max = long.MinValue;
            int a, b;
            long k; 
            long[] arr = new long[n];

            for (int i = 0; i < queries.GetLength(0); i++)  //Dimension 0 contains number of lines
            {
                    //each queries[i] contains three integers, a, b, and k.
                    a = queries[i][0];
                    b = queries[i][1];
                    k = queries[i][2];

                    while (a<=b)
                    {
                        //we always update at index a-1 because this arrays are 1-indexed.
                        arr[a-1] = arr[a-1] + k;
                        if (arr[a-1] > max) //if a new max found
                        {
                            max = arr[a-1]; //update max
                        }
                        a++;
                    }
            }
            return max;
        }

        static long arrayManipulationSlopeSolution(int n, int[][] queries) {
        //idea: instead of adding value to array, we control where it started do climb (a) and where it stopped (b+1). A.K.A Slope increase
            long max = 0;
            long tempMax = 0;
            int a, b;
            long k; 
            long[] arr = new long[n+1]; //to make 1-indexed array possible

            for (int i = 0; i < queries.GetLength(0); i++)  //Dimension 0 contains number of lines
            {
                    //each queries[i] contains a, b, and k.
                    a = queries[i][0];
                    b = queries[i][1];
                    k = queries[i][2];

                    arr[a] = arr[a] + k; //slope starts at A pos, so we ADD there
                    if (b+1 <= n) //if in next position after the slope stops B+1 we do not go out of bounds...
                    {
                        //we mark that the slope stopped by SUBTRACTING at b+1 
                        arr[b+1] = arr[b+1] - k; 
                    }
            }
            
            //To find the max value we just add the POSITIVE slopes that contributed to max
            for(int i=1; i<=n; i++)
            {
                tempMax += arr[i]; 
                if(tempMax > max) max = tempMax;
            }
            return max;
        }

        #endregion

        #region Dictionaries and Hashmaps

        //HashTables: Ransom Note
        static void checkMagazine(string[] magazine, string[] note) {
            Dictionary<string, int> dMagazine = new Dictionary<string, int>();
            Dictionary<string, int> dNote = new Dictionary<string, int>();
            string canReplicate = "Yes";

            foreach (string s in magazine)
            {
                //we fill magazine dict with words and count number of times it appears
                if(dMagazine.ContainsKey(s))
                {
                    dMagazine[s] = dMagazine[s] + 1;
                } else
                {
                    dMagazine.Add(s, 1);
                }
                
            }

            foreach (string s in note)
            {
                //we do the same for note dict.
                if(dNote.ContainsKey(s))
                {
                    dNote[s] = dNote[s] + 1;
                } else
                {
                    dNote.Add(s, 1);
                }
            }

            //if the magazine doesn't have as many words as the note needs... no!
            if (dNote.Count > dMagazine.Count)
            {
                canReplicate = "No";
            }
            else
            {
                foreach (var key in dNote.Keys)
                {
                    if(dMagazine.ContainsKey(key))
                    {
                        //if dNote need more occurencies of a particular word than magazine has, no!
                        if (dNote[key] > dMagazine[key])
                        {
                            canReplicate = "No";
                            break;
                        }    

                    }
                    else
                    {
                        //if one of the words are not found, print no and stops
                        canReplicate = "No";
                        break;
                    }
                }
            }

            Console.WriteLine(canReplicate);

        }
        
        //Two Strings
        static string twoStrings(string s1, string s2) {
            
            Dictionary<char,int> dict1 = new Dictionary<char, int>();
            Dictionary<char,int> dict2 = new Dictionary<char, int>();

            String containsSub = "NO";

            //THe problem points that a single char counts as a substring. So we can divide strings in dicts of chars and see of at least
            //one of them is present on the other one
            foreach (char c in s1.Trim())
            {
                if(!dict1.ContainsKey(c))
                {
                    dict1.Add(c,1);
                }
            }

            foreach (char c in s2.Trim())
            {
                if(!dict2.ContainsKey(c))
                {
                    dict2.Add(c,1);
                }
            }

            foreach (var key in dict2.Keys)
            {
                if (dict1.ContainsKey(key))
                {
                    containsSub = "YES";
                    break;
                }
            }

            return containsSub;

        }
        
        //Sherlock and Anagrams
        static int sherlockAndAnagrams(string s) {
            int numberOfAnagrams = 0;
            string subStr;
                     
            Dictionary<string,int> dict = new Dictionary<string, int>();

            for(int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j < s.Length - i + 1; j++)
                {
                    subStr = s.Substring(i,j);
                    char[] chars = subStr.ToCharArray();
                    Array.Sort(chars);
                    subStr = new string (chars);

                    if(dict.ContainsKey(subStr))
                    {
                        numberOfAnagrams = numberOfAnagrams + dict[subStr];
                        dict[subStr] = dict[subStr] + 1;
                    } else
                    {
                        dict.Add(subStr,1);
                    }
                }
            }

            return numberOfAnagrams;

        }

        //Count Triplets
        static long countTriplets(List<long> arr, long r) {
            long xi; //expected i
            long xj; //Xpected j
            long xk; //Xpected k
            long count = 0;

            arr.Sort();

            for (int i = 0; i < arr.Count; i++)
            {
                xi = arr[i];
                xj = xi * r;
                xk = xj * r;

                for (int j = i+1; j < arr.Count; j++)
                {
                    //if we found the expected j, we try to get k
                    if(arr[j] == xj)
                    {
                        for (int k = j+1; k < arr.Count; k++)
                        {
                            if (arr[k] == xk) //we found xi, xj and xk. Gotcha! Count!
                            {
                                count++;
                            }
                        }
                    }
                }

            }

            return count;

        }

        static long countTripletsOptimized(List<long> arr, long r) {
            long xi; //expected i
            long xj; //Xpected j
            long xk; //Xpected k
            long count = 0;

            Dictionary<long,long> dict = new Dictionary<long, long>();

            foreach (long l in arr)
            {
                if(dict.ContainsKey(l))
                {
                    dict[l] = dict[l] + 1; //Sum new occurency
                } else
                {
                    dict.Add(l,1); //add 1st occurency
                }
            }

            foreach (var key in dict.Keys)
            {
                xi = key;
                xj = xi * r;
                xk = xj * r;

                //if we find a progression triplet
                if (dict.ContainsKey(xj) && dict.ContainsKey(xk)) 
                {
                    //we count and multiply recurrent occurencies
                    count = count + (dict[xi] * dict[xj] * dict[xk]); 
                }
            }           

            return count;

        }

        static long countTripletsOptimized2(List<long> arr, long r) {
            Dictionary<long,long> xj = new Dictionary<long, long>(); //Xpected js
            Dictionary<long,long> xk = new Dictionary<long, long>(); //Xpected ks
            long count = 0;
            //1st triplet indice "i"
            foreach (long key in arr)
            {
                //3rd triplet indice "k"
                if (xk.ContainsKey(key))
                    count += xk[key];
                if (xj.ContainsKey(key))
                    if (xk.ContainsKey(key*r))
                        xk[key*r] += xj[key];
                    else
                        xk[key*r] = xj[key];
                //2nd triplet indice "j" 
                if (xj.ContainsKey(key*r))
                    xj[key*r]++;
                else
                    xj[key*r] = 1;
            }
            return count; 

        }
        #endregion



    }
}
