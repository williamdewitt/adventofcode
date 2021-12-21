using System;
using System.IO;
using System.Collections.Generic;

namespace src
{
  class Program
  {
    private static readonly IList<(string, int)> _sampleData = new List<(string, int)>{

      ("forward", 5),
      ("down", 5),
      ("forward", 8),
      ("up", 3),
      ("down", 8),
      ("forward", 2)
    };

    static void Main(string[] args)
    {
      var horizontalPosition = 0;
      var depth = 0;

      var lines = File.ReadAllLines("../../data.txt");

      var puzzleData = new List<(string, int)>();

      foreach (var item in lines)
      {
        var split = item.Split(" ");
        puzzleData.Add((split[0], int.Parse(split[1])));
      }

      foreach (var command in puzzleData)
      {
        Console.WriteLine($"Move {command.Item1} by {command.Item2} units.");
        switch (command.Item1)
        {
          case "forward":
            horizontalPosition += command.Item2;
            break;

          case "down":
            depth += command.Item2;
            break;

          case "up":
            depth -= command.Item2;
            break;

          default:
            break;
        }
      }

      Console.WriteLine($"And the answer is... {horizontalPosition * depth}!");
    }
  }
}
