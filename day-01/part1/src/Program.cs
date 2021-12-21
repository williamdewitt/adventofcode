using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace src
{
  class Program
  {
    private static readonly int[] Report = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

    static void Main(string[] args)
    {
      var increasedCount = 0;

      var data = File.ReadAllLines("../../data.txt").Select(x => int.Parse(x)).ToArray();

      for (int i = 0; i < data.Count(); i++)
      {
        if (i == 0)
        {
          System.Console.WriteLine($"{data[i]} (N/A - no previous measurement)");
        }
        else if (data[i] > data[i - 1])
        {
          System.Console.WriteLine($"{data[i]} (increased)");
          increasedCount++;
        }
        else if (data[i] < data[i - 1])
        {
          System.Console.WriteLine($"{data[i]} (decreased)");
        }
      }

      System.Console.WriteLine($"The depth has increased {increasedCount} times.");
    }
  }
}
