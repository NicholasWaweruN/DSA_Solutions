namespace Practice;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;     

        while (true)
        {
            ShowMenuMain();
            Console.Write("\nEnter choice: ");
            var choice = Console.ReadLine()?.Trim();

            if (string.Equals(choice, "Q", StringComparison.OrdinalIgnoreCase))
                break;

            try
            {
                switch (choice)
                {
                    case "1":
                        RunString("Enter text:", input => $"Reversed: {StringAlgorithms.ReverseString(input)}");
                        break;
                    case "2":
                        RunString("Enter text:", input => StringAlgorithms.IsPalindrome(input) ? "Palindrome" : "Not palindrome");
                        break;
                    case "3":
                        RunString("Enter text:", input => StringAlgorithms.HasAllUniqueCharacters(input) ? "All characters are unique" : "Contains duplicates");
                        break;
                    case "4":
                        RunString("Enter sentence:", input => $"Words reversed: {StringAlgorithms.ReverseWordsSimpleMethod(input)}");
                        break;
                    case "5":
                        RunString("Enter sentence:", input => $"Title case: {StringAlgorithms.TitleCase(input)}");
                        break;
                    case "6":
                        RunString("Enter text:", input => $"Vowels: {StringAlgorithms.CountVowels(input)}");
                        break;
                    case "7":
                        RunNumbers("Enter comma-separated numbers:", numbers =>
                        {
                            Console.Write("Enter target: ");
                            if (!int.TryParse(Console.ReadLine(), out var target))
                                return "Invalid target";

                            var result = ArrayAlgorithms.TwoSumIndices(numbers, target);
                            return result.Length == 0 ? "No pair found" : $"Indices: [{result[0]}, {result[1]}]";
                        });
                        break;
                    case "8":
                        RunNumbers("Enter comma-separated numbers:", numbers => $"Maximum: {ArrayAlgorithms.MaximumElement(numbers)}");
                        break;
                    case "9":
                        RunNumbers("Enter comma-separated numbers:", numbers => $"Second largest: {ArrayAlgorithms.SecondLargestNumber(numbers)}");
                        break;
                    case "10":
                        RunNumbers("Enter comma-separated numbers:", numbers =>
                        {
                            var result = ArrayAlgorithms.MaximumAndMinimumElements(numbers);
                            return $"Max: {result["max"]}, Min: {result["min"]}";
                        });
                        break;
                    case "11":
                        RunNumbers("Enter comma-separated numbers:", numbers =>
                        {
                            Console.Write("Enter window size k: ");
                            if (!int.TryParse(Console.ReadLine(), out var k))
                                return "Invalid k";

                            return $"Maximum window sum: {SlidingWindowAlgorithms.MaximumSubArraySizeK(numbers, k)}";
                        });
                        break;
                    case "12":
                        RunNumbers("Enter comma-separated numbers:", numbers =>
                        {
                            Console.Write("Enter window size k: ");
                            if (!int.TryParse(Console.ReadLine(), out var k))
                                return "Invalid k";
                            Console.Write("Enter target: ");
                            if (!int.TryParse(Console.ReadLine(), out var target))
                                return "Invalid target";

                            return $"Count: {SlidingWindowAlgorithms.CountSubarraysSizeKWithSumAtLeastTarget(numbers, k, target)}";
                        });
                        break;
                    case "13":
                        RunString("Enter text:", input =>
                        {
                            Console.Write("Enter window size k: ");
                            if (!int.TryParse(Console.ReadLine(), out var k))
                                return "Invalid k";

                            return $"Maximum vowels in window: {SlidingWindowAlgorithms.MaximumNumberOfVowels(input, k)}";
                        });
                        break;
                    case "14":
                        RunString("Enter brackets string:", input => StackQueueAlgorithms.ValidateParenthesisStack(input) ? "Valid" : "Invalid");
                        break;
                    case "15":
                        DemoLinqProblems();
                        break;
                    case "16":
                        RunNumbers("Enter comma-separated numbers:", numbers =>
                        {
                            Console.Write("Enter target K: ");
                            if (!int.TryParse(Console.ReadLine(), out var k))
                                return "Invalid K";

                            return $"Subarray count: {PrefixSumAlgorithms.SubarraySumEqualsK(numbers, k)}";
                        });
                        break;
                    case "17":
                        RunStringPair("Enter first string:", "Enter second string:", (a, b) => StringAlgorithms.IsStringsAnagrams(a, b) ? "Anagrams" : "Not anagrams");
                        break;
                    case "18":
                        RunString("Enter sentence:", input =>
                        {
                            var result = StringAlgorithms.LengthLongestWordInASentence(input);
                            return result.Value == 0 ? "No word found" : $"Longest word: {result.Key}, Length: {result.Value}";
                        });
                        break;
                    case "19":
                        RunString("Enter sentence:", input =>
                        {
                            var result = StringAlgorithms.CharacterOccurrence(input);
                            return result.Count == 0 ? "No characters found" : string.Join(", ", result.Select(x => $"{x.Key}:{x.Value}"));
                        });
                        break;
                    case "20":
                        RunString("Enter encoded string e.g. 3[a2[b]]:", input => $"Decoded: {StringAlgorithms.DecodeString(input)}");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void ShowMenuMain()
    {
        Console.WriteLine();
        Console.WriteLine("================ PRACTICE SUITE ================");
        Console.WriteLine("1  - Reverse string");
        Console.WriteLine("2  - Check palindrome");
        Console.WriteLine("3  - Check unique characters");
        Console.WriteLine("4  - Reverse words in sentence");
        Console.WriteLine("5  - Convert to title case");
        Console.WriteLine("6  - Count vowels");
        Console.WriteLine("7  - Two Sum (indices)");
        Console.WriteLine("8  - Maximum element");
        Console.WriteLine("9  - Second largest number");
        Console.WriteLine("10 - Maximum and minimum elements");
        Console.WriteLine("11 - Maximum subarray sum of size K");
        Console.WriteLine("12 - Count subarrays of size K with sum >= target");
        Console.WriteLine("13 - Maximum vowels in substring of size K");
        Console.WriteLine("14 - Validate parentheses using stack");
        Console.WriteLine("15 - LINQ demo");
        Console.WriteLine("16 - Subarray sum equals K");
        Console.WriteLine("17 - Check anagrams");
        Console.WriteLine("18 - Longest word in sentence");
        Console.WriteLine("19 - Character occurrence count");
        Console.WriteLine("20 - Decode string");
        Console.WriteLine("Q  - Quit");
    }

    private static void RunString(string prompt, Func<string, string> operation)
    {
        Console.Write(prompt + " ");
        var input = Console.ReadLine() ?? string.Empty;
        Console.WriteLine(operation(input));
    }

    private static void RunStringPair(string prompt1, string prompt2, Func<string, string, string> operation)
    {
        Console.Write(prompt1 + " ");
        var input1 = Console.ReadLine() ?? string.Empty;
        Console.Write(prompt2 + " ");
        var input2 = Console.ReadLine() ?? string.Empty;
        Console.WriteLine(operation(input1, input2));
    }

    private static void RunNumbers(string prompt, Func<int[], string> operation)
    {
        Console.Write(prompt + " ");
        var input = Console.ReadLine() ?? string.Empty;
        var numbers = ParseNumbers(input);
        Console.WriteLine(operation(numbers));
    }

    private static int[] ParseNumbers(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Array.Empty<int>();

        return input.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x.Trim()))
            .ToArray();
    }

    private static void DemoLinqProblems()
    {
        var nums = new List<int> { 1, 2, 3, 4, 5, 6, 10, 20 };
        var words = new List<string> { "apple", "go", "banana", "ant", "azure" };

        Console.WriteLine("Even numbers: " + string.Join(", ", LinqProblems.EvenNumbers(nums)));
        Console.WriteLine("Squares: " + string.Join(", ", LinqProblems.TransformIntToSquares(nums)));
        Console.WriteLine("Strings length > 3: " + string.Join(", ", LinqProblems.StringLengthGreaterThan3(words)));
        Console.WriteLine("Start with A: " + string.Join(", ", LinqProblems.StartWithLetterA(words)));
    }
}
