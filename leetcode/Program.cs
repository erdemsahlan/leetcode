using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Threading.Channels;
using System.Xml;

//namespace mergeSortedArray // Note: actual namespace depends on the project name.
//{
//    //    You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
//    //    Merge nums1 and nums2 into a single array sorted in non-decreasing order.
//    //The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
//    //Example 1:
//    //Input: nums1 = [1, 2, 3, 0, 0, 0], m = 3, nums2 = [2, 5, 6], n = 3
//    //Output: [1, 2, 2, 3, 5, 6]
//    //    Explanation: The arrays we are merging are [1, 2, 3] and [2, 5, 6].
//    //The result of the merge is [1, 2, 2, 3, 5, 6] with the underlined elements coming from nums1.
//    //Example 2:
//    //Input: nums1 = [1], m = 1, nums2 = [], n = 0
//    //Output: [1]
//    //    Explanation: The arrays we are merging are [1] and [].
//    //The result of the merge is [1].
//    //Example 3:
//    //Input: nums1 = [0], m = 0, nums2 = [1], n = 1
//    //Output: [1]
//    //    Explanation: The arrays we are merging are [] and[1].
//    //The result of the merge is [1].
//    //Note that because m = 0, there are no elements in nums1.The 0 is only there to ensure the merge result can fit in nums1.
//    //    Constraints:
//    //nums1.length == m + n
//    //    nums2.length == n
//    //0 <= m, n <= 200
//    //1 <= m + n <= 200
//    //-109 <= nums1[i], nums2[j] <= 109
//    //Follow up: Can you come up with an algorithm that runs in O(m + n) time?
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//            int[] nums1 = [1, 2, 3, 0, 0, 0];
//            int[] nums2 = [2, 5, 6];
//            int m = 3;
//            int n = 3;
//            leetCode(nums1, m, nums2, n);
//            bestpractice(nums1, m, nums2, n);
//        }
//        static void leetCode(int[] nums1, int m, int[] nums2, int n)
//        {
//            nums1 = nums1.Where(x => x != 0).Take(m).ToArray();
//            nums2 = nums2.Where(x => x != 0).Take(n).ToArray();
//            nums1 = nums1.Concat(nums2).ToArray();
//            Array.Sort(nums1);
//            foreach (int i in nums1)
//            {
//                Console.WriteLine(i + " ");
//            }
//        }
//        static void bestpractice(int[] nums1, int m, int[] nums2, int n)
//        {
//            for (int i = nums1.Length - 1; i >= 0; i--)
//            {
//                nums1[i] =
//                    (m > 0 && (n < 1 || nums1[m - 1] >= nums2[n - 1]))
//                    ? nums1[--m] : nums2[--n];
//                Console.WriteLine(nums1[i] + " ");
//            }
//        }
//    }
//}
//namespace removeElement
//{
////    Given an integer array nums and an integer val, remove all occurrences of val in nums in-place.The order of the elements may be changed.Then return the number of elements in nums which are not equal to val.

////Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:

////Change the array nums such that the first k elements of nums contain the elements which are not equal to val.The remaining elements of nums are not important as well as the size of nums.
////Return k.
////Custom Judge:

////The judge will test your solution with the following code:

////int[] nums = [...]; // Input array
////    int val = ...; // Value to remove
////int[] expectedNums = [...]; // The expected answer with correct length.
////                            // It is sorted with no values equaling val.

////    int k = removeElement(nums, val); // Calls your implementation

////    assert k == expectedNums.length;
////sort(nums, 0, k); // Sort the first k elements of nums
////for (int i = 0; i<actualLength; i++) {
////    assert nums[i] == expectedNums[i];
////}
////If all assertions pass, then your solution will be accepted.



////Example 1:

////Input: nums = [3, 2, 2, 3], val = 3
////Output: 2, nums = [2, 2, _, _]
////Explanation: Your function should return k = 2, with the first two elements of nums being 2.
////It does not matter what you leave beyond the returned k (hence they are underscores).
////Example 2:

////Input: nums = [0, 1, 2, 2, 3, 0, 4, 2], val = 2
////Output: 5, nums = [0, 1, 4, 0, 3, _, _, _]
////Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
////Note that the five elements can be returned in any order.
////It does not matter what you leave beyond the returned k (hence they are underscores).


////Constraints:

////0 <= nums.length <= 100
////0 <= nums[i] <= 50
////0 <= val <= 100
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            removeElements([3, 2, 2, 3], 3);
//        }
//        static void removeElements(int[] nums, int val)
//        {
//            int count = 0;
//            for (int i = 0; i < nums.Length; i++)
//            {
//                if (nums[i] == val)
//                {
//                    for (int l = val; l < nums.Length; l++)
//                    {
//                        if (l == nums.Length - 1) { nums[l] = -1; break; }
//                        nums[l] = nums[l + 1];
//                    }
//                    count++;
//                }
//            }
//            int k = nums.Length - count;
//        }
//    }
//}
//namespace removeDuplicatesSortedArray
//{
////    Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once.The relative order of the elements should be kept the same.Then return the number of unique elements in nums.

////Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

////Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially.The remaining elements of nums are not important as well as the size of nums.
////Return k.
////Custom Judge:

////The judge will test your solution with the following code:

////int[] nums = [...]; // Input array
////    int[] expectedNums = [...]; // The expected answer with correct length

////    int k = removeDuplicates(nums); // Calls your implementation

////    assert k == expectedNums.length;
////for (int i = 0; i<k; i++) {
////    assert nums[i] == expectedNums[i];
////}
////If all assertions pass, then your solution will be accepted.

 

////Example 1:

////Input: nums = [1, 1, 2]
////Output: 2, nums = [1, 2, _]
////Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
////It does not matter what you leave beyond the returned k (hence they are underscores).
////Example 2:

////Input: nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4]
////Output: 5, nums = [0, 1, 2, 3, 4, _, _, _, _, _]
////Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
////It does not matter what you leave beyond the returned k (hence they are underscores).
 

////Constraints:

////1 <= nums.length <= 3 * 104
////- 100 <= nums[i] <= 100
////nums is sorted in non - decreasing order.
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
//            solutions(nums);
//        }

//        static int solutions(int[] nums)
//        {
//            if (nums.Length == 0)
//            {
//                return 0;
//            }
//            int count = 1;
//            if (nums.Length == 0) return 0;
//            for (int i = 1; i < nums.Length; i++)
//            {
//                if (nums[i] != nums[i - 1])
//                {
//                    nums[count++] = nums[i];
//                }
//            }
//            return count;
//        }
//    }
//}
