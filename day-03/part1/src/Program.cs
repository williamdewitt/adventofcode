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

      private static readonly IList<byte> _testDataAsBytes = new List<byte>(){
      0b00100,
      0b11110,
      0b10110,
      0b10111,
      0b10101,
      0b01111,
      0b00111,
      0b11100,
      0b10000,
      0b11001,
      0b00010,
      0b01010
      };

      //0b00100

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
          epsilonRate += "0";
        }
        else
        {
          gammaRate += "0";
          epsilonRate += "1";
        }
      }

      var gammaRateAsDecimal = BinaryStringToDecimal(gammaRate);
      var epsilonRateAsDecimal = BinaryStringToDecimal(epsilonRate);
      
      System.Console.WriteLine($"And the answer is... {gammaRateAsDecimal * epsilonRateAsDecimal}");
    }

    private static double BinaryStringToDecimal(string binaryString)
    {
      double myDecimal = 0;
      int power = 0;

      for (int i = binaryString.Length -1; i >= 0; i--)
      {
        if(binaryString[i] == '0')
        {
          myDecimal += System.Math.Pow(2, power) * 0;
        }
        else
        {
          myDecimal += System.Math.Pow(2, power) * 1;
        }

        power++;
      }
      
      return myDecimal;
    }
  }
}