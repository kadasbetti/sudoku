using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sudoku
{
    internal class Program
    {
        const int rowSize = 9; //konstans sorok száma
        const int columnSize = 9; //konstans oszlopok száma

        static string[,] FileRead(string fileName) //fájlbeolvasó függvény, ami megkapja a fileName stringet a Main fgvből
        {

            StreamReader sr = new StreamReader(fileName); //fájlbeolvasás

            string[,] table = new string[rowSize, columnSize]; //9x9 táblázat létrehozása

            int rowIndex = 0;
            while (!sr.EndOfStream && rowIndex < 9) //végigmegyünk egyenként a fájl sorain
            {
                string[] rowFromFile = sr.ReadLine().Split(' '); //fájlsorok egyenként szétszedése oszloponként
                for (int columnIndex = 0; columnIndex < rowFromFile.Length; columnIndex++) //számolja az oszlopokat
                {
                    table[rowIndex, columnIndex] = rowFromFile[columnIndex]; //egyeztetjük a fájlt a táblázattal, beleolvassuk
                }
                rowIndex++; //számozza a sorokat
            }
            return table;
        }
        
        static void ConsoleWrite(string[,] tableFromRead) //kiíró függvény, ami megkapja a táblázatot a Main fgvből, amit a FileRead 
        {
            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++) //végigmegy a sorokon
            {
                for (int columnIndex = 0; columnIndex < columnSize; columnIndex++) //végigmegy az oszlopokon
                {
                    Console.Write(tableFromRead[rowIndex, columnIndex] + ' '); //kiír egy sort
                }
                Console.WriteLine(); //sortörés, majd új sor
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat");
            Console.WriteLine("Adja meg egy bemeneti fájl nevét! ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Adja meg egy sor számát!");
            int rowIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Adja meg egy oszlop számát!");
            int columnIndex = int.Parse(Console.ReadLine());


            string[,] tableFromRead = Program.FileRead(fileName);
            Program.ConsoleWrite(tableFromRead);
            Console.WriteLine(tableFromRead[rowIndex-1,columnIndex-1]);

            

            Console.ReadKey();
        }
    }
}
