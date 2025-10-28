using FluentAssertions;
using Practice.StringAndArrays;
using System;
using System.Collections.Generic;
using Xunit;

namespace PracticeTests
{
    public class StringsAndArraysTests
    {
        private readonly IStringsAndArrays _sut; // System Under Test

        public StringsAndArraysTests()
        {
            _sut = new StringsAndArrays();
        }

        // ============================================================
        // 🟢 EASY LEVEL TESTS
        // ============================================================

        [Fact]
        public void ReverseString_ShouldReverseCorrectly()
        {
            var result = _sut.ReverseString("hello");
            result.Should().Be("olleh");
        }

        [Fact]
        public void ReverseString2_ShouldReverseCorrectly()
        {
            var result = _sut.ReverseString2("abc");
            result.Should().Be("cba");
        }

        [Theory]
        [InlineData("madam", true)]
        [InlineData("hello", false)]
        public void IsPalindrome_ShouldDetectCorrectly(string input, bool expected)
        {
            _sut.IsPalindrome(input).Should().Be(expected);
        }

        [Fact]
        public void RemoveAllWhiteSpaces_ShouldRemoveSpaces()
        {
            _sut.RemoveAllWhiteSpaces(" a b c ").Should().Be("abc");
        }

        [Fact]
        public void ReplaceVowelsWithStar_ShouldReplaceAllVowels()
        {
            _sut.ReplaceVowelsWithStar("Apple").Should().Be("*ppl*");
        }

        [Fact]
        public void TitleCase_ShouldCapitalizeEachWord()
        {
            _sut.TitleCase("hello world").Should().Be("Hello World");
        }

        [Fact]
        public void CountVowels_ShouldReturnCorrectCount()
        {
            _sut.CountVowels("hello").Should().Be(2);
        }

        [Fact]
        public void EachCountVowels_ShouldReturnCorrectDictionary()
        {
            var result = _sut.EachCountVowels("banana");
            result.Should().ContainKey('a').WhoseValue.Should().Be(3);
        }

        [Fact]
        public void CounntVowelConstants_ShouldReturnCorrectCounts()
        {
            var result = _sut.CounntVowelConstants("abcde");
            result["vowels"].Should().Be(2);
            result["consonants"].Should().Be(3);
        }

        [Fact]
        public void MaximumNumberInAnArray_ShouldReturnMax()
        {
            _sut.MaximumNumberInAnArray(new[] { 1, 2, 5, 3 }).Should().Be(5);
        }

        [Fact]
        public void RemoveDuplicates_ShouldReturnUniqueValues()
        {
            var result = _sut.RemoveDuplicates(new[] { "a", "a", "b" });
            result.Should().BeEquivalentTo("a", "b");
        }

        // ============================================================
        // 🟡 INTERMEDIATE LEVEL TESTS
        // ============================================================

        [Fact]
        public void ReverseWordsSimpleMethod_ShouldReverseWordOrder()
        {
            var result = _sut.ReverseWordsSimpleMethod("hello world");
            result.Should().Be("world hello");
        }

        [Fact]
        public void FirstNonRepeatingChars_ShouldReturnCorrectChar()
        {
            _sut.FirstNonRepeatingChars("aabbc").Should().Be("c");
        }

        [Theory]
        [InlineData("listen", "silent", true)]
        [InlineData("apple", "pale", false)]
        public void IsStringsAnagrams_ShouldDetectAnagrams(string a, string b, bool expected)
        {
            _sut.IsStringsAnagrams(a, b).Should().Be(expected);
        }

        [Fact]
        public void LengthLongestWordInASentence_ShouldReturnLongestWordAndLength()
        {
            var result = _sut.LengthLongestWordInASentence("I love programming");
            result.Key.Should().Be("programming");
            result.Value.Should().Be(11);
        }

        [Fact]
        public void Twosum_ShouldReturnCorrectPair()
        {
            var result = _sut.Twosum(new[] { 1, 2, 3, 4, 5 }, 9);
            result.Should().Contain(new[] { 4, 5 });
        }

        [Fact]
        public void HasAllUniqueCharacters_ShouldReturnTrueForUniqueString()
        {
            _sut.HasAllUniqueCharacters("abc").Should().BeTrue();
        }

        [Fact]
        public void HasAllUniqueCharacters_ShouldReturnFalseForDuplicateString()
        {
            _sut.HasAllUniqueCharacters("hello").Should().BeFalse();
        }

        // ============================================================
        // 🧩 NUMERIC & EXTRA TESTS
        // ============================================================

        [Fact]
        public void MaximumAndMinimumElements_ShouldReturnCorrectValues()
        {
            var result = _sut.MaximumAndMinimumElements(new[] { 3, 1, 4 });
            result["max"].Should().Be(4);
            result["min"].Should().Be(1);
        }

        [Fact]
        public void AverageOfAllElements_ShouldReturnCorrectAverage()
        {
            _sut.AverageOfAllElements(new[] { 1, 2, 3 }).Should().Be(2);
        }

        [Fact]
        public void CountOddAndEvenNumbers_ShouldReturnCorrectCounts()
        {
            var result = _sut.CountOddAndEvenNumbers(new[] { 1, 2, 3, 4 });
            result["odd"].Should().Be(2);
            result["even"].Should().Be(2);
        }

        [Fact]
        public void SecondLargestNumber_ShouldReturnCorrectSecondLargest()
        {
            _sut.SecondLargestNumber(new[] { 10, 20, 5 }).Should().Be(10);
        }

        [Fact]
        public void ReverseWordsKeepSameOrder_ShouldReverseEachWord()
        {
            _sut.ReverseWordsKeepSameOrder("hello world").Should().Be("olleh dlrow");
        }

        [Fact]
        public void DecodeString_ShouldDecodeSimplePattern()
        {
            _sut.DecodeString("3[a]").Should().Be("aaa");
        }

        [Fact]
        public void MaximumElement_ShouldReturnMax()
        {
            _sut.MaximumElement(new[] { 1, 2, 10, 5 }).Should().Be(10);
        }
    }
}
