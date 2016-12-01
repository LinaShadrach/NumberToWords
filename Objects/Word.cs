using System;
using System.Collections.Generic;

namespace NumToWord.Objects
{
  public class Word
  {
    public string InputString {get; set;}
    public int InputNumber {get; set;}
    public string OutputWord {get; set;}

    public Word(string input)
    {
      this.InputString = input;
      this.InputNumber = Int32.Parse(input);
      this.OutputWord = "";
    }

    public void ConvertNum()
    {
      char[] inputChars = InputString.ToCharArray();
      int index = inputChars.Length - 1;

      Dictionary<char, string> ref9Under = new Dictionary<char, string>() {{'0', "zero"}, {'1', "one"}, {'2', "two"}, {'3', "three"}, {'4', "four"}, {'5', "five"}, {'6', "six"}, {'7', "seven"}, {'8', "eight"}, {'9', "nine"}};
      Dictionary<char, string> ref12Under = new Dictionary<char, string>() {{'0', "ten"}, {'1', "eleven"}, {'2', "twelve"}};
      Dictionary<char, string> refTeens = new Dictionary<char, string>() {{'3', "thir"}, {'4', "four"}, {'5', "fif"}, {'6', "six"}, {'7', "seven"}, {'8', "eigh"}, {'9', "nine"}};
      Dictionary<char, string> refTruncated = new Dictionary<char, string>() {{'2', "twen"}, {'3', "thir"}, {'4', "for"}, {'5', "fif"}, {'6', "six"}, {'7', "seven"}, {'8', "eigh"}, {'9', "nine"}};

      if(this.InputNumber < 91 && this.InputNumber > 19)
      {
        this.OutputWord += refTruncated[inputChars[index-1]] + "ty";
        int val = inputChars[index-1] - '0';
        this.InputNumber -= val * 10;
        // index--;
      }
      if(this.InputNumber < 20 && this.InputNumber > 12)
      {
        this.OutputWord += refTeens[inputChars[index]] + "teen";
        this.InputNumber -= this.InputNumber;
      }
      if(this.InputNumber < 13 && this.InputNumber > 9)
      {
        this.OutputWord += ref12Under[inputChars[index]];
        this.InputNumber -= this.InputNumber;
      }
      if(this.InputNumber < 10 && this.InputNumber > 0)
      {
        this.OutputWord += ref9Under[inputChars[index]];
      }
    }

  }
}
