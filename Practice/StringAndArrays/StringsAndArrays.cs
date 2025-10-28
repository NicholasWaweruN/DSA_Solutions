using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.StringAndArrays
{
    public class StringsAndArrays : IStringsAndArrays
    {
        public StringsAndArrays()
        {
        }

        // ============================================================
        // 🟢 EASY LEVEL PROBLEMS
        // ============================================================

        // ✅ Reverse a string using LINQ
        public string ReverseString(string str)
        {
            var str1 = str.ToArray().Reverse();
            return string.Join("", str1);
        }

        // ✅ Reverse a string manually using StringBuilder
        public string ReverseString2(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            int right = str.Length - 1;
            var strings = new StringBuilder();
            while (right >= 0)
            {
                strings.Append(str[right]);
                right--;
            }
            return strings.ToString();
        }

        // ✅ Palindrome using reverse method
        public bool IsPalindrome(string palindromeInput)
        {
            if (string.IsNullOrEmpty(palindromeInput))
                return true;

            var reversed = ReverseString(palindromeInput);
            return palindromeInput.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        // ✅ Palindrome using two pointers
        public bool IsPalindrome2(string palindromeInput)
        {
            if (palindromeInput is null)
                return false;

            int left = 0;
            int right = palindromeInput.Length - 1;

            while (left < right)
            {
                if (char.ToLower(palindromeInput[left]) != char.ToLower(palindromeInput[right]))
                    return false;

                left++;
                right--;
            }
            return true;
        }

        // ✅ Remove all white spaces
        public string RemoveAllWhiteSpaces(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return new string(str.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        // ✅ Replace all vowels with '*'
        public string ReplaceVowelsWithStar(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return string.Empty;

            var sb = new StringBuilder();
            var vowels = "aeiouAEIOU";

            foreach (var ch in sentence)
                sb.Append(vowels.Contains(ch) ? '*' : ch);

            return sb.ToString();
        }

        // ✅ Convert a string to Title Case
        public string TitleCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            var words = str.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
                sb.Append(char.ToUpper(word[0])).Append(word.Substring(1)).Append(' ');

            return sb.ToString().TrimEnd();
        }

        // ✅ Convert to Title Case using two pointers
        public string TitleCaseTwoPointer(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            var words = str.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int left = 0;

            while (left < words.Length)
            {
                var word = words[left];
                sb.Append(char.ToUpper(word[0]) + word.Substring(1)).Append(' ');
                left++;
            }

            return sb.ToString().TrimEnd();
        }

        // ✅ Count total vowels in a string
        public int CountVowels(string str)
        {
            string vowel = "aeiou";
            int vowels = 0;

            foreach (var ch in str.ToLower())
                if (vowel.Contains(ch))
                    vowels++;

            return vowels;
        }

        // ✅ Count each vowel in a string
        public Dictionary<char, int> EachCountVowels(string str)
        {
            var vowels = "aeiou";
            var dict = new Dictionary<char, int>();

            if (string.IsNullOrEmpty(str))
                return dict;

            foreach (var ch in str.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    if (dict.ContainsKey(ch))
                        dict[ch]++;
                    else
                        dict[ch] = 1;
                }
            }
            return dict;
        }

        // ✅ Count vowels and consonants
        public Dictionary<string, int> CounntVowelConstants(string sentence)
        {
            var dict = new Dictionary<string, int>();
            var vowels = "aeiou";
            int countVowel = 0, consonants = 0;

            foreach (var ch in sentence.ToLower())
            {
                if (vowels.Contains(ch))
                    countVowel++;
                else if (char.IsLetter(ch))
                    consonants++;
            }

            dict["vowels"] = countVowel;
            dict["consonants"] = consonants;
            return dict;
        }

        // ✅ Find maximum number in an array
        public int MaximumNumberInAnArray(int[] numbers)
        {
            return numbers.Max();
        }

        // ✅ Remove duplicates from an array
        public string[] RemoveDuplicates(string[] str)
        {
            return new HashSet<string>(str).ToArray();
        }

        // ✅ Count occurrence of each character
        public Dictionary<char, int> CharacterOccurrence(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return new Dictionary<char, int>();

            var dict = new Dictionary<char, int>();
            foreach (var c in sentence.ToLower())
            {
                if (char.IsWhiteSpace(c)) continue;
                dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            }
            return dict;
        }

        // ============================================================
        // 🟡 INTERMEDIATE LEVEL PROBLEMS
        // ============================================================

        // 🔁 Reverse words in a sentence (simple split and join)
        public string ReverseWordsSimpleMethod(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            var words = str.Trim().Split(' ');
            Array.Reverse(words);
            return string.Join(' ', words);
        }

        // 🔁 Reverse words using two-pointer technique
        public string ReverseWordsTwoPointer(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            int right = str.Length - 1;

            while (right >= 0)
            {
                while (right >= 0 && str[right] == ' ')
                    right--;
                if (right < 0)
                    break;

                int left = right;
                while (left >= 0 && str[left] != ' ')
                    left--;

                sb.Append(str.Substring(left + 1, right - left)).Append(' ');
                right = left - 1;
            }

            return sb.ToString().TrimEnd();
        }

        // 🔍 Find first non-repeating character (to refine later)
        public string FirstNonRepeatingChars(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            var charCount = new Dictionary<char, int>();
            foreach (var c in str)
                charCount[c] = charCount.ContainsKey(c) ? charCount[c] + 1 : 1;

            foreach (var c in str)
                if (charCount[c] == 1)
                    return c.ToString();

            return string.Empty;
        }

        // 🔠 Check if two strings are anagrams
        public bool IsStringsAnagrams(string one, string two)
        {
            if (string.IsNullOrWhiteSpace(one) || string.IsNullOrWhiteSpace(two))
                return false;

            if (one.Length != two.Length)
                return false;

            var sortedOne = new string(one.ToLower().OrderBy(c => c).ToArray());
            var sortedTwo = new string(two.ToLower().OrderBy(c => c).ToArray());
            return sortedOne == sortedTwo;
        }

        // 🔢 Find length of the longest word in a sentence
        public KeyValuePair<string, int> LengthLongestWordInASentence(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return new KeyValuePair<string, int>("", 0);

            var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string? longest = words.OrderByDescending(w => w.Length).FirstOrDefault();
            if (longest != null)
            {
                return new KeyValuePair<string, int>(longest ?? string.Empty, longest.Length);
            }
            return new KeyValuePair<string, int>(sentence, 0);

        }

        // 🔢 Maximum number in array using two pointers
        public int MaximumNumberInAnArrayTwoPointer(int[] numbers)
        {
            int max = int.MinValue;
            int left = 0, right = numbers.Length - 1;

            while (left <= right)
            {
                max = Math.Max(max, Math.Max(numbers[left], numbers[right]));
                left++;
                right--;
            }
            return max;
        }

        // 🎯 Two Sum (two-pointer version)
        public int[] Twosum(int[] nums, decimal target)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                    return new int[] { nums[left], nums[right] };
                if (sum > target)
                    right--;
                else
                    left++;
            }
            return Array.Empty<int>();
        }

        // 🧩 Check if a string has all unique characters
        public bool HasAllUniqueCharacters(string uniqueInput)
        {
            if (string.IsNullOrEmpty(uniqueInput))
                return false;

            var set = new HashSet<char>();
            foreach (var c in uniqueInput)
            {
                if (!set.Add(c))
                    return false;
            }
            return true;
        }

        // ============================================================
        // Find the maximum and minimum elements in an array

        public Dictionary<string, int> MaximumAndMinimumElements(int[] numbers)
        {
            var result = new Dictionary<string, int>();

            if (numbers == null || numbers.Length == 0)
            {
                // Return default values if input is null or empty
                result.Add("max", 0);
                result.Add("min", 0);
                return result;
            }

            int min = numbers[0];
            int max = numbers[0];

            foreach (var num in numbers)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }

            result.Add("max", max);
            result.Add("min", min);

            return result;
        }

        //2. Calculate the average of all elements

        public double AverageOfAllElements(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;

            double sum = 0;
            foreach (var no in numbers)
                sum += no;

            return sum / numbers.Length;
        }
       // 5. Count even and odd numbers

        public Dictionary<string,int> CountOddAndEvenNumbers(int[] numbers)
        {
            int odds= 0;
            int even = 0;
            var dict = new Dictionary<string, int>();
            foreach (var no in numbers)
            {
                if (no % 2 == 0)
                {
                    even++;
                }
                else 
                {
                    odds++;
                }
            }

            dict.Add("odd", odds);
            dict.Add("even", even);
            return dict;


        }
        //6. Find the second largest number

        public int SecondLargestNumber(int [] numbers)
        {
            if(numbers == null || numbers.Length < 2) return 0;

            var nth = numbers.OrderByDescending(x => x).ToList().Skip(1);
            return nth.FirstOrDefault();
           
        }

        //   // Reverse each word in a sentence(but keep word order)
        public string ReverseWordsKeepSameOrder(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                return string.Empty;

            var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var word in words)
            {
                var reversedWord = new string(word.Reverse().ToArray());
                sb.Append(reversedWord).Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
        //91.	Decode string like “3[a2[b]]” → “abbabbabb”

        public string DecodeString(string input)
        {
            var arrayresult = input.ToCharArray();
            int left = 0;
            int right = arrayresult.Length-1;
            var sb = new StringBuilder();

            while (left < right) 
            {
                if (char.IsDigit(arrayresult[left]))
                {
                    var digit1 = arrayresult[left];
                    var digit = int.Parse(digit1.ToString());
                    left++;
                    var letter = arrayresult[left];
                    var x = new string(letter, digit);

                    sb.Append(x);
                }
                else
                {
                    left++;
                }
            }
            return sb.ToString();

        }

        //1.	Find maximum element in an array
        public int MaximumElement(int[] numbers)
        {
           var max = numbers.Max();
            return max;

        }


    }
}
