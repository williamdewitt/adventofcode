using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    private double OxygenGeneratorRating { get; set; }
    private double Co2ScrubberRating { get; set; }
    private double LifeSupportRating => OxygenGeneratorRating * Co2ScrubberRating;

    static void Main(string[] args)
    {
      var program = new Program();

      var puzzleData = File.ReadAllLines("../../data.txt").ToList();
      var data = puzzleData;

      for (int i = 0; i < data.First().Length; i++)
      {
        var onesCount = data.Select(x => char.GetNumericValue(x[i])).Sum();
        var zerosCount = Math.Abs(data.Count() - onesCount);

        if (onesCount >= zerosCount)
        {
          data = data.Where(x => x[i] == '1').ToList();
        }
        else
        {
          data = data.Where(x => x[i] == '0').ToList();
        }

        if(data.Count() == 1)
        {
          program.OxygenGeneratorRating = BinaryStringToDouble(data.First());
          break;
        }
      }

      data = puzzleData;

      for (int i = 0; i < data.First().Length; i++)
      {
        var onesCount = data.Select(x => char.GetNumericValue(x[i])).Sum();
        var zerosCount = Math.Abs(data.Count() - onesCount);

        if (onesCount >= zerosCount)
        {
          data = data.Where(x => x[i] == '0').ToList();
        }
        else
        {
          data = data.Where(x => x[i] == '1').ToList();
        }

        if(data.Count() == 1)
        {
          program.Co2ScrubberRating = BinaryStringToDouble(data.First());
          break;
        }
      }

      Console.WriteLine($"The life support rating is: { program.LifeSupportRating }");
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
