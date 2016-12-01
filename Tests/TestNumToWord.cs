using Xunit;
using System;
using System.Collections.Generic;
using NumToWord.Objects;

namespace  NumToWord
{
  public class WordTest
  {
    [Theory]
    [InlineData("2", "two")]
    [InlineData("12", "twelve")]
    [InlineData("14", "fourteen")]
    [InlineData("60", "sixty")]
    [InlineData("53", "fifty-three")]
    [InlineData("100", "one hundred")]
    [InlineData("530", "five hundred thirty")]
    [InlineData("514", "five hundred fourteen")]
    [InlineData("711", "seven hundred eleven")]

    public void ConvertNum_Digits_true(string input, string expected)
    {
      //Arrange
      Word newWord = new Word(input);
      string expectedResult = expected;
      //Act
      newWord.ConvertNum();
      //Assert
      Assert.Equal(expectedResult, newWord.OutputWord);
    }
  }
}
