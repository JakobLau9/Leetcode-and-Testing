﻿using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanAppTest
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("_ ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return rightLetters;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("-----------------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "sunflower", "house", "diamond", "memes", "yeet", "hello", "test", "yeet" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            printHangman(0);
            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // Prompt user for input
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                // Check if that letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                }
                else
                {
                    // Check if letter is in randomWord
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) 
                    { 
                        if (letterGuessed == randomWord[i]) 
                        { 
                            right = true; 
                        } 
                    }

                    // User is right
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                    }
                    // User was wrong
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Update the drawing
                        printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                    }
                }
            }

            
            Console.WriteLine("\r\nGame is over! Thank you for playing :)");
        }
    }
}