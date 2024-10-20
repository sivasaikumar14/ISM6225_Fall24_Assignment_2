using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> MissinG = new List<int>(); // To store missing numbers
                bool[] Present = new bool[nums.Length + 1]; // Boolean array to mark numbers

            foreach (int number in nums) // Mark the numbers that are present
            {
            if (number <= nums.Length)
            {
                Present[number] = true;
            }
            }    
            for (int i = 1; i <= nums.Length; i++) // Check which numbers are missing
            {
            if (!Present[i])
            {
                MissinG.Add(i);
            }
            }
            return MissinG; // Return the missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
        try
            {
            int left = 0; // Pointer starting from the beginning
            int right = nums.Length - 1; // Pointer starting from the end

            while (left < right)
            {
            if (nums[left] % 2 != 0 && nums[right] % 2 == 0) // If left is odd and right is even, swap them
            {
                int temporary = nums[left];
                nums[left] = nums[right];
                nums[right] = temporary;
            }
            if (nums[left] % 2 == 0) // Move the left pointer if it's pointing to an even number
            {
                left++;
            }
            if (nums[right] % 2 != 0)// Move the right pointer if it's pointing to an odd number
            {
                right--;
            }
            }
            return nums; // Return the sorted array by parity
            }

        catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
            Dictionary<int, int> map = new Dictionary<int, int>(); // Store number and its index

            for (int i = 0; i < nums.Length; i++)
            {
            int cmplmnt = target - nums[i]; // The number needed to reach the target

            // If the complement is already in the map, return its index and the current index
            if (map.ContainsKey(cmplmnt))
            {
                return new int[] { map[cmplmnt], i };
            }
            if (!map.ContainsKey(nums[i])) // Otherwise, add the current number and its index to the map
            {
                map.Add(nums[i], i);
            }
            }
            throw new Exception("No two sum solution found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            { 
            Array.Sort(nums); // Sort the array to easily find the required numbers
            int n = nums.Length; 
            int pd1 = nums[n - 1] * nums[n - 2] * nums[n - 3];// Calculate the product of the three largest numbers
            int pd2 = nums[0] * nums[1] * nums[n - 1]; // Calculate the product of the two smallest numbers and the largest number
            return Math.Max(pd1, pd2); // Return the maximum of the two products
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
             if (decimalNumber == 0)
            {
            return "0"; // Edge case: if the number is 0, return "0"
            }
            string binary = ""; // Initialize an empty string to store the binary result
            while (decimalNumber > 0) // Continue until the decimal number is greater than 0
            {
            int remainder = decimalNumber % 2; // Get the remainder (either 0 or 1)
            binary = remainder + binary; // Prepend the remainder to the binary string
            decimalNumber /= 2; // Divide the number by 2 to get the next quotient
            }
            return binary; // Return the final binary string
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

            if (nums[left] <= nums[right]) // If the array is already sorted (no rotation)
            {
            return nums[left];
            }
            while (left < right) // Binary search for the minimum element
            {
            int middle = (left + right) / 2;
            if (nums[middle] > nums[right]) // If middle element is greater than the rightmost element, min is in the right part
            {
                left = middle + 1;
            }
            else
            {
                right = middle; // Otherwise, the min is in the left part
            }
            }
            return nums[left]; // When left == right, we found the smallest element
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindrome
            if (x < 0)
            {
            return false;
            }
            int OG = x; // Store the original number
            int reversed = 0;
            while (x != 0) // Reverse the number
            {
            int digit = x % 10; // Get the last digit
            reversed = reversed * 10 + digit; // Add the digit to the reversed number
            x /= 10; // Remove the last digit from the number
            }
            return reversed == OG; // Compare the reversed number with the original
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
        try
        {
            if (n == 0) return 0; // F(0) = 0
            if (n == 1) return 1; // F(1) = 1
            int a = 0; // F(0)
            int b = 1; // F(1)
            int res = 0;
            for (int i = 2; i <= n; i++) // Compute Fibonacci iteratively
            {
            res = a + b; // F(n) = F(n-1) + F(n-2)
            a = b;          // Shift the values for the next iteration
            b = res;
            }
            return res; // Return F(n)
        }
        catch (Exception)
            {
                throw;
            }
        }
    }
}
