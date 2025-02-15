﻿using System.Xml.Linq;
using Helpers;
namespace _05_Wines_Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Wines with Interface and Tesxt Streams!");

        var rnd = new csSeedGenerator();
        WineCellar wineCellar = new WineCellar("Martin's cellar");

        #region Add wines to the winecellar
        for (int i = 0; i < 50; i++)
        {
            wineCellar.Add(new csWine().Seed(rnd));
            wineCellar.Add(new stWine().Seed(rnd));
        }
        #endregion

        #region write cellar to console
        Console.WriteLine($"\nWinecellar: {wineCellar.Name}");
        Console.WriteLine($"Nr of bottles: {wineCellar.Count}");
        Console.WriteLine($"Value of winecellar: {wineCellar.Value:N2} Sek");

        var hilo = wineCellar.WineHiLoCost();
        Console.WriteLine($"\nMost expensive wine:\n{hilo.hicost}");
        Console.WriteLine($"Least expensive wine:\n{hilo.locost}");

        Console.WriteLine("\nMyCellar");
        Console.WriteLine(wineCellar);
        #endregion

        #region write cellar to disk
        //Your code
        string filePath = fname("WineCellar.txt");

        using (TextWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Winecellar: {wineCellar.Name}");
        }

        #endregion

    }
    static string fname(string name)
    {
        var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        documentPath = Path.Combine(documentPath, "ADOP", "M3_Exercises");
        if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
        return Path.Combine(documentPath, name);
    }
}

/* Exercises
1. Write code to save your winecellar to disk, using TextWriter
2. Change to store you cellar in MyDocuments
3. Open you text file in Word
*/