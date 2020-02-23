using System;
using System.Collections.Generic;


namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            // Write your code to print range r here

            Console.WriteLine("[" + string.Join(",", r) + "]");

            Console.WriteLine("Question 2");
            string s = "University of South Florida   ";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);
            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);
            Console.WriteLine("Question 5-Part 1");
            //int[] nums1 = { 1, 2, 2, 1 };
            //int[] nums2 = { 2, 2 };

            int[] nums1 = { 3, 6, 2 };
            int[] nums2 = { 6, 3, 6, 7, 3 };


            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");
            Console.WriteLine("Question 6");
            //char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            //char[] arr = new char[] { 'k', 'y', 'k', 'k' };
            char[] arr = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            //int k = 3;
            //int k = 1;
            int k = 2;
            Console.WriteLine(ContainsDuplicate(arr, k));
            Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            //string keyword = "hhllo";
            string keyword = "ucf";
            Console.WriteLine(DictSearch(userDict, keyword));
            Console.WriteLine("Question 9");
            SolvePuzzle();
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {

            int init_idx = -1;
            int final_idx = -1;
            try
            {

                for (int i = 0; i < l1.Length; i++)
                {
                    if (l1[i] == t && init_idx == -1)
                    {
                        init_idx = i;
                    }
                    else if (l1[i] == t)
                    {
                        final_idx = i;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            return new int[] { init_idx, final_idx };
        }

        public static string StringReverse(string s)
        {

            List<string> reverse_str = new List<string>();

            try
            {
                List<string> Split(string s)
                {
                    List<string> split_str = new List<string>();
                    while (s.Length > 0)
                    {
                        if (s.IndexOf(" ") != -1)
                        {
                            string first_part = s.Substring(0, s.IndexOf(" "));
                            //Console.WriteLine(first_part);
                            s = s.Substring(s.IndexOf(" ") + 1);
                            //Console.WriteLine(s

                            if (first_part.Length > 0)
                            {
                                split_str.Add(first_part);
                            }

                        }
                        else
                        {
                            split_str.Add(s);
                            s = "";
                        }

                    }

                    return split_str;
                }




                foreach (string str in Split(s))
                {
                    string new_str = "";
                    for (int i = str.Length - 1; i >= 0; i--)
                    {
                        new_str += str[i];
                    }
                    reverse_str.Add(new_str);
                }



            }
            catch (Exception)
            {
                throw;
            }
            return string.Join(" ", reverse_str);

        }

        public static int MinimumSum(int[] l2)
        {
            int sum = 0;
            try
            {

                for (int i = 0; i < l2.Length - 1; i++)
                {
                    if (l2[i] == l2[i + 1])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                    }

                    sum += l2[i];
                }

                sum += l2[l2.Length - 1];
            }
            catch (Exception)
            {
                throw;
            }
            return sum;
        }

        public static string FreqSort(string s2)
        {
            string result = "";
            try
            {
                Dictionary<char, int> freq = new Dictionary<char, int>();
                for (int i = 0; i < s2.Length; i++)
                {
                    if (freq.ContainsKey(s2[i]))
                    {
                        freq[s2[i]] += 1;
                    }
                    else
                    {
                        freq[s2[i]] = 1;
                    }
                }

                SortedDictionary<int, List<char>> sortedfreq = new SortedDictionary<int, List<char>>();

                foreach (KeyValuePair<char, int> kvp in freq)
                {
                    if (sortedfreq.ContainsKey(kvp.Value))
                    {
                        sortedfreq[kvp.Value].Add(kvp.Key);
                    }
                    else
                    {
                        sortedfreq[kvp.Value] = new List<char> { kvp.Key };
                    }

                }

                foreach (KeyValuePair<int, List<char>> kvp in sortedfreq)
                {
                    Console.WriteLine("Key: {0}, Value : {1}", kvp.Key, string.Join(",", kvp.Value));

                    foreach (char c in kvp.Value)
                    {
                        for (int i = 0; i < kvp.Key; i++)
                        {
                            result = c + result;
                        }
                    }
                }

                //Console.WriteLine(result);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static int[] Intersect1(int[] nums1, int[] nums2)
        {

            int[] result = new int[] { };
            try
            {

                int[] nums1_int1 = new int[nums1.Length];
                int[] nums2_int1 = new int[nums2.Length];

                for (int n1 = 0; n1 < nums1.Length; n1++)
                {
                    nums1_int1[n1] = nums1[n1];
                }

                for (int n2 = 0; n2 < nums2.Length; n2++)
                {
                    nums2_int1[n2] = nums2[n2];
                }

                Array.Sort(nums1_int1);
                Array.Sort(nums2_int1);

                //implement merge sort


                int i = 0; int j = 0; int k = 0;
                while (i < nums1_int1.Length && j < nums2_int1.Length)
                {
                    if (nums1_int1[i] == nums2_int1[j])
                    {
                        nums1_int1[k] = nums1_int1[i];
                        i += 1; j += 1; k += 1;
                    }
                    else if (nums1_int1[i] < nums2_int1[j])
                    {
                        i += 1;
                    }
                    else
                    {
                        j += 1;
                    }
                }

                result = new int[k];

                for (int r = 0; r < k; r++)
                {
                    result[r] = nums1_int1[r];
                }

            }
            catch
            {
                throw;
            }
            return result;
        }

        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            Console.WriteLine(string.Join(",", nums1));
            int[] result = new int[] { };
            try
            {
                Dictionary<int, int> nums1_dict = new Dictionary<int, int>();
                foreach (int num in nums1)
                {
                    Console.WriteLine(num);
                    if (nums1_dict.ContainsKey(num))
                    {
                        nums1_dict[num] += 1;
                    }
                    else
                    {
                        nums1_dict[num] = 1;
                    }
                }

                foreach (KeyValuePair<int, int> kvp in nums1_dict)
                {
                    Console.WriteLine("Key:{0}, Value:{1}", kvp.Key, kvp.Value);
                }


                int k = 0;

                int[] nums1_int2 = new int[nums1.Length];

                foreach (int num in nums2)
                {
                    if (nums1_dict.ContainsKey(num) && nums1_dict[num] > 0)
                    {
                        nums1_int2[k] = num;
                        k++;
                        nums1_dict[num] -= 1;
                    }
                }

                result = new int[k];

                for (int i = 0; i < k; i++)
                {
                    result[i] = nums1_int2[i];
                }


                Console.WriteLine(string.Join(",", nums1));

            }
            catch
            {
                throw;
            }
            return result;
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {

            bool result = true;
            try
            {
                Dictionary<char, List<int>> cd = new Dictionary<char, List<int>>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (cd.ContainsKey(arr[i]))
                    {
                        cd[arr[i]].Add(i);
                    }
                    else
                    {
                        cd[arr[i]] = new List<int> { i };
                    }

                }



                foreach (KeyValuePair<char, List<int>> kvp in cd)
                {

                    if (kvp.Value.Count > 1)
                    {
                        int diff = kvp.Value[1] - kvp.Value[0];
                        for (int i = 0; i < kvp.Value.Count - 1; i++)
                        {
                            if (diff > (kvp.Value[i + 1] - kvp.Value[i]))
                            {
                                diff = kvp.Value[i + 1] - kvp.Value[i];
                            }

                        }

                        if (diff > k)
                        {
                            result = false;
                            break;
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static int GoldRod(int rodLength)
        {

            if (rodLength == 0)
            {
                return 0;
            }

            List<List<int>> comb = new List<List<int>>();
            int prod = 1;

            try
            {

                int[] temp_result = new int[rodLength];
                combinations(temp_result, 0, rodLength, rodLength);

                void combinations(int[] temp_result, int index, int rodLength, int num)
                {

                    if (num == 0)
                    {
                        List<int> temp_comb = new List<int>();

                        for (int i = 0; i < index; i++)
                            temp_comb.Add(temp_result[i]);
                        comb.Add(temp_comb);
                        return;
                    }

                    if (num < 0)
                    {
                        return;
                    }


                    int prev = (index == 0) ? 1 : temp_result[index - 1];

                    for (int i = prev; i <= num; i++)
                    {
                        temp_result[index] = i;
                        combinations(temp_result, index + 1, rodLength, num - i);
                    }


                }

                foreach (List<int> i in comb)
                {
                    int temp_prod = 1;
                    foreach (int j in i)
                    {
                        temp_prod *= j;
                    }

                    if (temp_prod > prod)
                    {
                        prod = temp_prod;
                    }

                }

            }

            catch (Exception)
            {
                throw;
            }
            return prod;
        }
        public static bool DictSearch(string[] userDict, string keyword)
        {
            bool result = false;
            try
            {
                foreach (string str in userDict)
                {
                    if (str.Length != keyword.Length)
                    {
                        continue;
                    }
                    else
                    {
                        int count = 0;
                        string keyword1 = keyword;
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] == keyword[i])
                            {
                                continue;
                            }
                            else if (str[i] != keyword[i])
                            {
                                keyword1 = str.Substring(0, i) + keyword.Substring(i);
                                count += 1;
                            }
                        }

                        if (count == 1)
                        {
                            result = true;
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static void SolvePuzzle()
        {
            List<List<int>> perm = new List<List<int>>();
            List<char> uniqlist = new List<char>();
            Dictionary<char, int> uniq_dict = new Dictionary<char, int>();
            string input1 = "";
            string input2 = "";
            string output = "";
            try
            {
                Console.WriteLine("Enter input1");
                input1 = Console.ReadLine();
                Console.WriteLine("Enter input2");
                input2 = Console.ReadLine();
                Console.WriteLine("Enter output");
                output = Console.ReadLine();


                UniqueChar(input1);
                UniqueChar(input2);
                UniqueChar(output);

                void UniqueChar(string input)
                {
                    foreach (char c in input)
                    {
                        if (uniqlist.Contains(c))
                        {
                            continue;
                        }
                        else
                        {
                            uniqlist.Add(c);
                        }
                    }
                }

                Console.WriteLine(string.Join(",", uniqlist));



                int[] opt = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                Permutation(opt, 0, opt.Length - 1, perm);

                static void Swap(ref int a, ref int b)
                {
                    var temp = a;
                    a = b;
                    b = temp;
                }


                static List<List<int>> Permutation(int[] opt, int start, int end, List<List<int>> perm)
                {
                    if (start == end)
                    {
                        perm.Add(new List<int>(opt));
                    }
                    else
                    {
                        for (int i = start; i <= end; i++)
                        {
                            Swap(ref opt[start], ref opt[i]);
                            Permutation(opt, start + 1, end, perm);
                            Swap(ref opt[start], ref opt[i]);
                        }
                    }

                    return perm;
                }


                double compute_length(string input)
                {
                    int x = input.Length - 1;
                    double input_double = 0;
                    for (int i = input.Length - 1; i >= 0; i--)
                    {

                        if (uniq_dict[input[i]] == 0)
                        {
                            input_double += 0;
                            continue;
                        }
                        input_double += Math.Pow(10, (x - i)) * uniq_dict[input[i]];
                    }

                    return input_double;
                }

                foreach (List<int> result in perm)
                {

                    if (result[0] == 0 || result[1] == 0)
                    {
                        continue;
                    }

                    for (int i = 0; i < uniqlist.Count; i++)
                    {
                        uniq_dict[uniqlist[i]] = result[i];
                    }

                    double input1_int = compute_length(input1);
                    double input2_int = compute_length(input2);
                    double output_int = compute_length(output);

                    if ((input1_int + input2_int) == output_int)
                    {
                        Console.WriteLine(input1_int);
                        Console.WriteLine(input2_int);
                        Console.WriteLine(output_int);
                        foreach (KeyValuePair<char, int> kvp in uniq_dict)
                        {
                            Console.WriteLine("Char: {0}, Integer:{1}", kvp.Key, kvp.Value);
                        }
                        break;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}