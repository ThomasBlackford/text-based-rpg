using System;
using System.Collections.Generic;

namespace TextBasedRPG
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Layout { get; set; }
        public (int X, int Y) PlayerPosition { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Layout = new char[width, height];
            InitializeMap();
            PlayerPosition = (width / 2, height / 2); // Start player in the center
            SetTile(PlayerPosition.X, PlayerPosition.Y, 'P'); // 'P' represents the player
        }

        private void InitializeMap()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Layout[x, y] = '.'; // Default to empty space
                }
            }
        }

        public void DisplayMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(Layout[x, y]);
                }
                Console.WriteLine();
            }
        }

        public void SetTile(int x, int y, char tile)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                Layout[x, y] = tile;
            }
        }

        public char GetTile(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return Layout[x, y];
            }
            return '\0'; // Return null character if out of bounds
        }

        public void MovePlayer(ConsoleKey key)
        {
            int newX = PlayerPosition.X;
            int newY = PlayerPosition.Y;

            switch (key)
            {
                case ConsoleKey.W:
                    newY--;
                    break;
                case ConsoleKey.S:
                    newY++;
                    break;
                case ConsoleKey.A:
                    newX--;
                    break;
                case ConsoleKey.D:
                    newX++;
                    break;
            }

            if (newX >= 0 && newX < Width && newY >= 0 && newY < Height)
            {
                SetTile(PlayerPosition.X, PlayerPosition.Y, '.'); // Clear old player position
                PlayerPosition = (newX, newY);
                SetTile(PlayerPosition.X, PlayerPosition.Y, 'P'); // Set new player position
            }
        }
    }
}