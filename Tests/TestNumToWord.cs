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

    public void Convert_Digits_true(string input, string expected)
    {
      //Arrange
      Word newWord = new Word(input);
      string expectedResult = expected;
      //Act
      newWord.Convert();
      //Assert
      Assert.Equal(expectedResult, newWord.OutputWord);
    }
  }
}
