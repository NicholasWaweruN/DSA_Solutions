using Practice.StringAndArrays;
using System;
using System.Linq;

namespace Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IStringsAndArrays stringsAndArrays = new StringsAndArrays();
            IArraies arraies = new Arraies();
            string choice = string.Empty;

            Console.WriteLine("Welcome to the Strings and Arrays Practice Suite!");

            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- STRING OPERATIONS ---");
                    Console.WriteLine("1: Reverse a String");
                    Console.WriteLine("2: Check for Palindrome");
                    Console.WriteLine("3: Check for Unique Characters");
                    Console.WriteLine("4: Reverse a String (Two Pointer)");
                    Console.WriteLine("5: Reverse Words (Simple Method)");
                    Console.WriteLine("6: Reverse Words (Two Pointer)");
                    Console.WriteLine("9: Count Vowels");
                    Console.WriteLine("10: Each Vowel Count");
                    Console.WriteLine("12: Count Vowels and Consonants");
                    Console.WriteLine("13: Reverse a String (Manual)");
                    Console.WriteLine("14: First Non-Repeating Character");
                    Console.WriteLine("15: Remove All Whitespaces");
                    Console.WriteLine("16: Replace Vowels with *");
                    Console.WriteLine("17: Check if Two Strings are Anagrams");
                    Console.WriteLine("18: Find the Longest Word in a Sentence");
                    Console.WriteLine("19: Convert String to Title Case");
                    Console.WriteLine("20: Character Occurrence Count");
                    Console.WriteLine("25: Reverse Each Word (Keep Same Order)");
                    Console.WriteLine("26: Decode a string");
                    Console.WriteLine("\n--- ARRAY / NUMBER OPERATIONS ---");
                    Console.WriteLine("7: Two-Sum");
                    Console.WriteLine("8: Remove Duplicates from Words");
                    Console.WriteLine("11: Find Maximum Number");
                    Console.WriteLine("21: Maximum and Minimum Elements");
                    Console.WriteLine("22: Average of All Elements");
                    Console.WriteLine("23: Count Odd and Even Numbers");
                    Console.WriteLine("24: Second Largest Number");
          
                    Console.WriteLine("Q: Quit");
                    Console.Write("\nEnter your choice: ");

                    choice = (Console.ReadLine() ?? string.Empty).Trim();

                    if (choice.Equals("q", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nExiting the program. Goodbye! 👋");
                        break;
                    }

                    if (string.IsNullOrEmpty(choice))
                    {
                        Console.WriteLine("⚠️ Please enter a valid choice.");
                        continue;
                    }

                    switch (choice)
                    {
                        case "1":
                            RunWithString("Enter a string to reverse:", s =>
                                $"Reversed: {stringsAndArrays.ReverseString(s)}");
                            break;

                        case "2":
                            RunWithString("Enter a string to check palindrome:", s =>
                                stringsAndArrays.IsPalindrome(s)
                                    ? "✅ It’s a palindrome!" : "❌ Not a palindrome.");
                            break;

                        case "3":
                            RunWithString("Enter a string to check for unique characters:", s =>
                                stringsAndArrays.HasAllUniqueCharacters(s)
                                    ? "✅ All characters are unique." : "❌ There are duplicates.");
                            break;

                        case "4":
                            RunWithString("Enter a string to reverse (Two Pointer):", s =>
                                $"Reversed: {stringsAndArrays.ReverseString2(s)}");
                            break;

                        case "5":
                            RunWithString("Enter a sentence to reverse words:", s =>
                                $"Reversed: {stringsAndArrays.ReverseWordsSimpleMethod(s)}");
                            break;

                        case "6":
                            RunWithString("Enter a sentence to reverse words (Two Pointer):", s =>
                                $"Reversed: {stringsAndArrays.ReverseWordsTwoPointer(s)}");
                            break;

                        case "7":
                            Console.Write("Enter target sum: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal target))
                            {
                                Console.WriteLine("⚠️ Invalid input. Please enter a valid number.");
                                break;
                            }

                            int[] nums = { 1, 2, 3, 4, 5, 6, 8, 9, 10 };
                            var res = stringsAndArrays.Twosum(nums, target);
                            if (res.Length == 0)
                                Console.WriteLine("No pair found that sums to the target.");
                            else
                                Console.WriteLine($"Pair found: [{res[0]}, {res[1]}]");
                            break;

                        case "8":
                            RunWithString("Enter words separated by spaces:", s =>
                            {
                                var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                return $"After removing duplicates: {string.Join(' ', stringsAndArrays.RemoveDuplicates(words))}";
                            });
                            break;

                        case "9":
                            RunWithString("Enter a string to count vowels:", s =>
                                $"Vowel count: {stringsAndArrays.CountVowels(s)}");
                            break;

                        case "10":
                            RunWithString("Enter a string to count each vowel:", s =>
                            {
                                var dict = stringsAndArrays.EachCountVowels(s);
                                return dict.Count == 0 ? "No vowels found." :
                                    string.Join(", ", dict.Select(kv => $"{kv.Key}: {kv.Value}"));
                            });
                            break;

                        case "11":
                            RunWithNumbers("Enter numbers separated by commas:", numbers =>
                                $"Maximum number: {stringsAndArrays.MaximumNumberInAnArray(numbers)}");
                            break;

                        case "12":
                            RunWithString("Enter a sentence:", s =>
                            {
                                var counts = stringsAndArrays.CounntVowelConstants(s);
                                return $"Vowels: {counts["vowels"]}, Consonants: {counts["consonants"]}";
                            });
                            break;

                        case "13":
                            RunWithString("Enter a string to reverse manually:", s =>
                                $"Reversed: {stringsAndArrays.ReverseString2(s)}");
                            break;

                        case "14":
                            RunWithString("Enter a string to find first non-repeating character:", s =>
                                $"First non-repeating character: {stringsAndArrays.FirstNonRepeatingChars(s)}");
                            break;

                        case "15":
                            RunWithString("Enter a string to remove all whitespaces:", s =>
                                $"Cleaned string: \"{stringsAndArrays.RemoveAllWhiteSpaces(s)}\"");
                            break;

                        case "16":
                            RunWithString("Enter a sentence to replace vowels with '*':", s =>
                                $"Result: {stringsAndArrays.ReplaceVowelsWithStar(s)}");
                            break;

                        case "17":
                            RunWithString("Enter first string:", "Enter second string:", (s1, s2) =>
                                stringsAndArrays.IsStringsAnagrams(s1, s2)
                                    ? "✅ They are anagrams!" : "❌ Not anagrams.");
                            break;

                        case "18":
                            RunWithString("Enter a sentence:", s =>
                            {
                                var longest = stringsAndArrays.LengthLongestWordInASentence(s);
                                return longest.Value == 0
                                    ? "No words found."
                                    : $"Longest word: {longest.Key}, Length: {longest.Value}";
                            });
                            break;

                        case "19":
                            RunWithString("Enter a sentence to convert to Title Case:", s =>
                                $"Result: {stringsAndArrays.TitleCase(s)}");
                            break;

                        case "20":
                            RunWithString("Enter a sentence to count character occurrences:", s =>
                            {
                                var occurrences = stringsAndArrays.CharacterOccurrence(s);
                                return occurrences.Count == 0
                                    ? "No characters found."
                                    : string.Join(", ", occurrences.Select(kv => $"{kv.Key}: {kv.Value}"));
                            });
                            break;

                        case "21":
                            RunWithNumbers("Enter numbers separated by commas:", numbers =>
                            {
                                var result = stringsAndArrays.MaximumAndMinimumElements(numbers);
                                return $"Max: {result["max"]}, Min: {result["min"]}";
                            });
                            break;

                        case "22":
                            RunWithNumbers("Enter numbers separated by commas:", numbers =>
                                $"Average: {stringsAndArrays.AverageOfAllElements(numbers)}");
                            break;

                        case "23":
                            RunWithNumbers("Enter numbers separated by commas:", numbers =>
                            {
                                var counts = stringsAndArrays.CountOddAndEvenNumbers(numbers);
                                return $"Odd: {counts["odd"]}, Even: {counts["even"]}";
                            });
                            break;

                        case "24":
                            RunWithNumbers("Enter numbers separated by commas:", numbers =>
                                $"Second Largest Number: {stringsAndArrays.SecondLargestNumber(numbers)}");
                            break;

                        case "25":
                            RunWithString("Enter a sentence to reverse each word while keeping order:", s =>
                                stringsAndArrays.ReverseWordsKeepSameOrder(s));
                            break;

                        case "26":
                            RunWithString("Decode string like “3[a2[b]]” → “abbabbabb”:", s =>
                                stringsAndArrays.DecodeString(s));
                            break;
                        //case "27":
                        //    RunWithString("Decode string like “3[a2[b]]” → “abbabbabb”:", s =>
                        //        arraies.TwoSum (nums,target ));
                        //    break;

                        default:
                            Console.WriteLine("⚠️ Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Unexpected error: {ex.Message}");
                }
            }
        }

        // --- Helpers ---

        private static void RunWithString(string prompt, Func<string, string> operation)
        {
            Console.Write(prompt + " ");
            var input = (Console.ReadLine() ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("⚠️ Input cannot be empty.");
                return;
            }

            try
            {
                Console.WriteLine(operation(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        private static void RunWithString(string prompt1, string prompt2, Func<string, string, string> operation)
        {
            Console.Write(prompt1 + " ");
            var input1 = (Console.ReadLine() ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("⚠️ Input cannot be empty.");
                return;
            }

            Console.Write(prompt2 + " ");
            var input2 = (Console.ReadLine() ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(input2))
            {
                Console.WriteLine("⚠️ Input cannot be empty.");
                return;
            }

            try
            {
                Console.WriteLine(operation(input1, input2));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        private static void RunWithNumbers(string prompt, Func<int[], string> operation)
        {
            Console.Write(prompt + " ");
            var input = (Console.ReadLine() ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("⚠️ Input cannot be empty.");
                return;
            }

            try
            {
                var numbers = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse).ToArray();
                Console.WriteLine(operation(numbers));
            }
            catch
            {
                Console.WriteLine("⚠️ Invalid number format.");
            }
        }
        //10. Implement a custom string compression (“aaabb” → “a3b2”)
    
    }
}
