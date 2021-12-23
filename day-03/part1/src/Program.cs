using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace src
{
  class Program
  {
    private static readonly IList<string> _testData = new List<string>(){
      "00100",
      "11110",
      "10110",
      "10111",
      "10101",
      "01111",
      "00111",
      "11100",
      "10000",
      "11001",
      "00010",
      "01010"
      };

    static void Main(string[] args)
    {
      var gammaRate = "";
      var epsilonRate = "";

      var puzzleData = System.IO.File.ReadAllLines("../../data.txt");

      var threshold = puzzleData.Count() / 2;

      for (int i = 0; i < puzzleData.First().Length; i++)
      {
        var value = puzzleData.Select(x => char.GetNumericValue(x[i])).Sum();

        if (value > threshold)
        {
          gammaRate += "1";
        }
        else
        {
          gammaRate += "0";
        }
      }

      for (int i = 0; i < puzzleData.First().Length; i++)
      {
        var value = puzzleData.Select(x => char.GetNumericValue(x[i])).Sum();

        if (value < threshold)
        {
          epsilonRate += "1";
        }
        else
        {
          epsilonRate += "0";
        }
      }

      //var bytes = gammaRate.Select(x => (byte)x).ToArray();
      //var chars = System.Text.Encoding.UTF8.GetString(bytes).ToCharArray();

      // TODO: This section needs work

      System.Console.WriteLine(gammaRate);
      System.Console.WriteLine(epsilonRate);

      // replace with cw output from above lines
      System.Console.WriteLine(0b110111000111);
      System.Console.WriteLine(0b001000111000);

      // multiply output to get the answer
      System.Console.WriteLine($"And the answer is... {3527 * 568}");
    }
  }
}