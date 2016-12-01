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
    [InlineData("71182", "seventy-one thousand one hundred eighty-two")]
    [InlineData("71000182", "seventy-one million one hundred eighty-two")]
    [InlineData("71000182", "seventy-one million one hundred eighty-two")]
    [InlineData("2001004003005008", "two quadrillion one trillion four billion three million five thousand eight")]
    [InlineData("0", "zero")]

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
