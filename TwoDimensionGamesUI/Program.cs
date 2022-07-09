using System;

namespace TwoDimensionGames
{
  class Program
  {
    static void Main(string[] args)
    {
      ConsoleKeyInfo userInput;
      TikTakToe tikTakToe = new TikTakToe();
      tikTakToe.Start();
      while (true)
      {
        Console.WriteLine("Drücken Sie [Enter] wenn sie nochmal spielen wollen oder [Esc], falls sie das Spiel beenden wollen.");
        userInput = Console.ReadKey();
        if (userInput.Key == ConsoleKey.Enter)
        {
          tikTakToe = new TikTakToe();
          tikTakToe.Start();
        }
        else if (userInput.Key == ConsoleKey.Escape)
        {
          return;
        }
      }
    }
  }
}
