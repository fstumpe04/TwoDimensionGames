using System;
using System.Collections.Generic;
using System.Text;

namespace TwoDimensionGames
{
  internal class TikTakToe
  {
    /// <summary>
    /// true = Spieler 1, false = Spieler 2
    /// </summary>
    bool playerTurn = true;
    byte[] player1Counts = new byte[8]; // 0 = FirstVerticalLine, 1 = SecondVerticalLine, 2 = ThirdVerticalLine, 3 = FirstHorizontalLine, 4 = SecondHorizontalLine, 5 = ThirdHorizontalLine, 6 = DigonalLeftTopToRightBottom, 7 = DigonalRightTopToLeftBottom
    byte[] player2Counts = new byte[8]; // 0 = FirstVerticalLine, 1 = SecondVerticalLine, 2 = ThirdVerticalLine, 3 = FirstHorizontalLine, 4 = SecondHorizontalLine, 5 = ThirdHorizontalLine, 6 = DigonalLeftTopToRightBottom, 7 = DigonalRightTopToLeftBottom
    char player1Symbol = 'X';
    char player2Symbol = 'O';
    private char [,] blankMap = { { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                  { '|', ' ', '|', ' ', '|', ' ', '|' },
                                  { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                  { '|', ' ', '|', ' ', '|', ' ', '|' },
                                  { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                  { '|', ' ', '|', ' ', '|', ' ', '|' },
                                  { ' ', '-', ' ', '-', ' ', '-', ' ' },};
    private char[,] currentMap = { { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                   { '|', ' ', '|', ' ', '|', ' ', '|' },
                                   { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                   { '|', ' ', '|', ' ', '|', ' ', '|' },
                                   { ' ', '-', ' ', '-', ' ', '-', ' ' },
                                   { '|', ' ', '|', ' ', '|', ' ', '|' },
                                   { ' ', '-', ' ', '-', ' ', '-', ' ' },};
    List<ConsoleKey> pressedKeys = new List<ConsoleKey>();
    internal void Start()
    {
      ConsoleKeyInfo userInput;
      while (true)
      {
        PlayGame();
        while (true)
        {
          Console.WriteLine("Drücken Sie [Enter] wenn sie nochmal spielen wollen oder [Esc], falls sie das Spiel beenden wollen.");
          userInput = Console.ReadKey();
          if (userInput.Key == ConsoleKey.Enter)
          {
            RefreshGame();
          }
          else if (userInput.Key == ConsoleKey.Escape)
          {
            return;
          }
          else
          {
            Console.Clear();
          }
        }
      } 
    }

    private void RefreshGame()
    {
      playerTurn = true;
      player1Counts = new byte[8];
      player2Counts = new byte[8];
      currentMap = blankMap;
    }

    private void PlayGame()
    {
      while (true)
      {
        ShowMap();
        ConsoleKeyInfo userInput = Console.ReadKey();
        SetSymbol(userInput);
        byte winGame = CheckWin();
        ShowMap();
        if (winGame > 0)
        {
          Console.WriteLine($"Spieler {winGame} hat gewonnen!");
          return;
        }
        if (IsFullMap())
        {
          Console.WriteLine("Remi!");
          return;
        }
      }
    }

    private bool IsFullMap()
    {
      bool ret = false;
      byte notEmptyFields = 0;
      for (int i = 1; i <= 5; i += 2)
      {
        for (int j = 1; j <= 5; j += 2)
        {
          if (currentMap[i, j] != ' ')
            notEmptyFields++;
        }
      }
      if (notEmptyFields == 9)
      {
        ret = true;
      }
      return ret;
    }

    private byte CheckWin()
    {
      byte ret = 0;
      for (byte i = 0; i < player1Counts.Length; i++)
      {
        if (player1Counts[i] == 3)
        {
          ret = 1;
          break;
        }
      }
      if (ret == 0)
      {
        for (byte i = 0; i < player2Counts.Length; i++)
        {
          if (player2Counts[i] == 3)
          {
            ret = 2;
            break;
          }
        }
      }
      return ret;
    }

    private void SetSymbol(ConsoleKeyInfo userInput)
    {
      byte[] playerCount = new byte[5];
      char turnSymbol = ' ';
      if (playerTurn)
      {
        turnSymbol = player1Symbol;
        playerCount = player1Counts;
      }
      else if (!playerTurn)
      {
        turnSymbol = player2Symbol;
        playerCount = player2Counts;
      }
      if (!pressedKeys.Contains(userInput.Key))
      {
        if (userInput.Key == ConsoleKey.Q || userInput.Key == ConsoleKey.NumPad7)
        {
          currentMap[1, 1] = turnSymbol;
          playerCount[0]++;
          playerCount[3]++;
          playerCount[6]++;
        }
        else if (userInput.Key == ConsoleKey.W || userInput.Key == ConsoleKey.NumPad8)
        {
          currentMap[1, 3] = turnSymbol;
          playerCount[1]++;
          playerCount[3]++;
        }
        else if (userInput.Key == ConsoleKey.E || userInput.Key == ConsoleKey.NumPad9)
        {
          currentMap[1, 5] = turnSymbol;
          playerCount[2]++;
          playerCount[3]++;
          playerCount[7]++;
        }
        else if (userInput.Key == ConsoleKey.A || userInput.Key == ConsoleKey.NumPad4)
        {
          currentMap[3, 1] = turnSymbol;
          playerCount[0]++;
          playerCount[4]++;
        }
        else if (userInput.Key == ConsoleKey.S || userInput.Key == ConsoleKey.NumPad5)
        {
          currentMap[3, 3] = turnSymbol;
          playerCount[1]++;
          playerCount[4]++;
          playerCount[6]++;
          playerCount[7]++;
        }
        else if (userInput.Key == ConsoleKey.D || userInput.Key == ConsoleKey.NumPad6)
        {
          currentMap[3, 5] = turnSymbol;
          playerCount[2]++;
          playerCount[4]++;
        }
        else if (userInput.Key == ConsoleKey.Y || userInput.Key == ConsoleKey.NumPad1)
        {
          currentMap[5, 1] = turnSymbol;
          playerCount[0]++;
          playerCount[5]++;
          playerCount[7]++;
        }
        else if (userInput.Key == ConsoleKey.X || userInput.Key == ConsoleKey.NumPad2)
        {
          currentMap[5, 3] = turnSymbol;
          playerCount[1]++;
          playerCount[5]++;
        }
        else if (userInput.Key == ConsoleKey.C || userInput.Key == ConsoleKey.NumPad3)
        {
          currentMap[5, 5] = turnSymbol;
          playerCount[2]++;
          playerCount[5]++;
          playerCount[6]++;
        }
        pressedKeys.Add(userInput.Key);
      }
      if (playerTurn)
      {
        player1Counts = playerCount;
        playerTurn = false;
      }
      else if (!playerTurn)
      {
        player2Counts = playerCount;
        playerTurn = true;
      }
    }

    private void ShowMap()
    {
      Console.Clear();
      for (byte i = 0; i < 7; i++)
      {
        for (byte j = 0; j < 7; j++)
        {
          Console.Write(currentMap[i,j]);
        }
        Console.WriteLine();
      }
    }
  }
}
