using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace src
{
  class Program
  {
    private static readonly IList<string> _sampleData = new List<string>(){
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

      var puzzleData = File.ReadAllLines("../../data.txt");
      var threshold = puzzleData.Count() / 2;

      for (int i = 0; i < puzzleData.First().Length; i++)
      {
        var value = puzzleData.Select(x => char.GetNumericValue(x[i])).Sum();

        if (value > threshold)
        {
          gammaRate += "1";
          epsilonRate += "0";
        }
        else
        {
          gammaRate += "0";
          epsilonRate += "1";
        }
      }

      var gammaRateAsDouble = BinaryStringToDouble(gammaRate);
      var epsilonRateAsDouble = BinaryStringToDouble(epsilonRate);
      var powerConsumption = gammaRateAsDouble * epsilonRateAsDouble;

      Console.WriteLine($"The power consumption is... {powerConsumption}");
    }

    private static double BinaryStringToDouble(string binaryString)
    {
      return binaryString
        .Reverse()
        .Select((item, index) => Math.Pow(2, index) * char.GetNumericValue(item))
        .Sum();
    }
  }
}