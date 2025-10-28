
namespace Practice.StringAndArrays
{
    public interface IStringsAndArrays
    {
        Dictionary<char, int> CharacterOccurrence(string sentence);
        Dictionary<string, int> CounntVowelConstants(string sentence);
        int CountVowels(string str);
        Dictionary<char, int> EachCountVowels(string str);
        string FirstNonRepeatingChars(string str);
        bool HasAllUniqueCharacters(string uniqueInput);
        bool IsPalindrome(string palindromeInput);
        bool IsPalindrome2(string palindromeInput);
        bool IsStringsAnagrams(string one, string two);
        KeyValuePair<string, int> LengthLongestWordInASentence(string sentence);
        int MaximumNumberInAnArray(int[] numbers);
        int MaximumNumberInAnArrayTwoPointer(int[] numbers);
        string RemoveAllWhiteSpaces(string str);
        string[] RemoveDuplicates(string[] str);
        string ReplaceVowelsWithStar(string sentence);
        string ReverseString(string str);
        string ReverseString2(string str);
        string ReverseWordsSimpleMethod(string str);
        string ReverseWordsTwoPointer(string str);
        string TitleCase(string str);
        string TitleCaseTwoPointer(string str);
        int[] Twosum(int[] nums, decimal target);
        Dictionary<string, int> MaximumAndMinimumElements(int[] numbers);
        double AverageOfAllElements(int[] numbers);
        Dictionary<string, int> CountOddAndEvenNumbers(int[] numbers);
        int SecondLargestNumber(int[] numbers);
        string ReverseWordsKeepSameOrder(string sentence);
        string DecodeString(string input);
        int MaximumElement(int[] numbers);
    }
}