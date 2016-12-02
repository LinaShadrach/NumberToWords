using Nancy;
using System.Collections.Generic;
using System;
using NumToWord.Objects;

namespace NumToWord
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Post["/result"] = _ => {
        Word newWord = new Word(Request.Form["input"]);
        newWord.ConvertNum();
        return View["index.cshtml", newWord];
      };
    }
  }
}
