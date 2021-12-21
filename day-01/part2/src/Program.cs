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

      var data = File.ReadAllLines("../../data.txt").Select(x => int.Parse(x)).ToList();

      var threes = new List<int>();
      
      for (int i = 0; i < data.Count() -2; i++)
      {
        var val = data.Skip(i).Take(3).Sum();
        threes.Add(val);
      }

      for (int i = 0; i < threes.Count(); i++)
      {
        if (i == 0)
        {
          System.Console.WriteLine($"{threes[i]} (N/A - no previous measurement)");
        }
        else if (threes[i] == threes[i - 1])
        {
          System.Console.WriteLine($"{threes[i]} (no change)");
        }
        else if (threes[i] > threes[i - 1])
        {
          System.Console.WriteLine($"{threes[i]} (increased)");
          increasedCount++;
        }
        else if (threes[i] < threes[i - 1])
        {
          System.Console.WriteLine($"{threes[i]} (decreased)");
        }
      }

      System.Console.WriteLine($"The depth has increased {increasedCount} times.");
    }
  }
}
