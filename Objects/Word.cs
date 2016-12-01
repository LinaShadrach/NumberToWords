using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NumToWord.Objects
{
  public class Word
  {
    public string InputString {get; set;}
    public string OutputWord {get; set;}

    public Word(string input)
    {
      this.InputString = input;
      this.OutputWord = "";
    }

    public List<string> SliceInput()
    {
      List<string> chunkList = new List<string>{};
      string input = this.InputString;
      int chunks = this.InputString.Length/3;
      if (input.Length > 3)
      {
        for (int i=0; i < chunks+1; i++)
        {
          if (input.Length > 2)
          {
            chunkList.Add(input.Substring(input.Length-3));
            input = input.Substring(0, input.Length-3);
          }
          else
          {
            chunkList.Add(input);
          }
        }
        chunkList.Reverse();
        return chunkList;
      }
      else
      {
        chunkList.Add(input);
        chunkList.Reverse();
        return chunkList;
      }

    }
    public void ConvertNum()
    {
      Dictionary<char, string> ref9Under = new Dictionary<char, string>() {{'1', "one"}, {'2', "two"}, {'3', "three"}, {'4', "four"}, {'5', "five"}, {'6', "six"}, {'7', "seven"}, {'8', "eight"}, {'9', "nine"}};
      Dictionary<char, string> ref12Under = new Dictionary<char, string>() {{'0', "ten"}, {'1', "eleven"}, {'2', "twelve"}};
      Dictionary<char, string> refTeens = new Dictionary<char, string>() {{'3', "thir"}, {'4', "four"}, {'5', "fif"}, {'6', "six"}, {'7', "seven"}, {'8', "eigh"}, {'9', "nine"}};
      Dictionary<char, string> refTruncated = new Dictionary<char, string>() {{'2', "twen"}, {'3', "thir"}, {'4', "for"}, {'5', "fif"}, {'6', "six"}, {'7', "seven"}, {'8', "eigh"}, {'9', "nine"}};
      string[] illions = {"", " thousand ", " million ", " billion ", " trillion ", " quadrillion "};

      List<string> inputChunks = SliceInput();
      int count = inputChunks.Count-1;
      Regex all0= new Regex("0");
      if (all0.Matches(this.InputString).Count == this.InputString.Length)
      {
        this.OutputWord = "zero";
      }
      else{
        foreach(string chunk in inputChunks)
        {
          int chunkInt = Convert.ToInt32(chunk);
          char[] inputChars = chunk.ToCharArray();
          int index = inputChars.Length - 1;
          if (chunkInt > 0)
          {
            if(chunkInt < 999 && chunkInt > 99 )
            {
              this.OutputWord += ref9Under[inputChars[index-2]] + " hundred";
              int val = inputChars[index-2] - '0';
              chunkInt -= val * 100;
              if (chunkInt > 0)
              {
                this.OutputWord += " ";
              }
            }
            if(chunkInt < 91 && chunkInt > 19)
            {
              this.OutputWord += refTruncated[inputChars[index-1]] + "ty";
              int val = inputChars[index-1] - '0';
              chunkInt -= val * 10;
              if (chunkInt > 0)
              {
                this.OutputWord += "-";
              }
              // index--;
            }
            if(chunkInt < 20 && chunkInt > 12)
            {
              this.OutputWord += refTeens[inputChars[index]] + "teen";
              chunkInt -= chunkInt;
            }
            if(chunkInt < 13 && chunkInt > 9)
            {
              this.OutputWord += ref12Under[inputChars[index]];
              chunkInt -= chunkInt;
            }
            if(chunkInt < 10 && chunkInt > 0)
            {
              this.OutputWord += ref9Under[inputChars[index]];
            }
            this.OutputWord += illions[count];
          }
          count--;
        }
      }
    }
  }
}
