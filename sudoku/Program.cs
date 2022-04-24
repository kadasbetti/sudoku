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
        const int depthSize = 9; //konstans z 
        const int smallRowSize = 3;
        const int smallColumnSize = 3;

        static int[,] FileRead(string fileName) //fájlbeolvasó függvény, ami megkapja a fileName stringet a Main fgvből
        {

            StreamReader sr = new StreamReader(fileName); //fájlbeolvasás

            int[,] table = new int[rowSize, columnSize]; //9x9 táblázat létrehozása

            int rowIndex = 0;
            while (!sr.EndOfStream && rowIndex < 9) //végigmegyünk egyenként a fájl sorain
            {
                string[] rowFromFile = sr.ReadLine().Split(' '); //fájlsorok egyenként szétszedése oszloponként
                for (int columnIndex = 0; columnIndex < rowFromFile.Length; columnIndex++) //számolja az oszlopokat
                {
                    table[rowIndex, columnIndex] = int.Parse(rowFromFile[columnIndex]); //egyeztetjük a fájlt a táblázattal, beleolvassuk
                }
                rowIndex++; //számozza a sorokat
            }
            return table;
        }
        
        static void ConsoleWrite(int[,] tableFromRead) //kiíró függvény, ami megkapja a táblázatot a Main fgvből, amit a FileRead 
        {
            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++) //végigmegy a sorokon
            {
                for (int columnIndex = 0; columnIndex < columnSize; columnIndex++) //végigmegy az oszlopokon
                {
                    Console.Write(tableFromRead[rowIndex, columnIndex] + " "); //kiír egy sort
                }
                Console.WriteLine(); //sortörés, majd új sor
            }

        }

     
        static int[,,] ConvertToSmallTables(int[,] table) //résztáblázatokat szétszedi 3 dimenziós tömbbe
        {
            //colIndex/3 + (rowIndex/3 )*3 = depth
            //smallRowIndex = rowIndex % 3
            //smallcolIndex = colIndex % 3
            int[,,] smallTable = new int[rowSize/3,columnSize/3,depthSize];

            for(int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex < columnSize; columnIndex++)
                {
                    int value = table[rowIndex, columnIndex];

                    int depth = columnIndex / 3 + (rowIndex / 3) * 3;
                    int smallRowIndex = rowIndex % 3;
                    int smallColumnIndex = columnIndex % 3;

                    smallTable[smallRowIndex, smallColumnIndex, depth] = value;
                }
            }

         

            return smallTable;
        }
        
        static void ConsoleWriteSmall(int[,,] smallTable)
        {

            for (int depthIndex = 0; depthIndex < depthSize; depthIndex++)
            {
                for (int rowIndex = 0; rowIndex < smallRowSize; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < smallColumnSize; columnIndex++)
                    {
                        Console.Write(smallTable[rowIndex, columnIndex, depthIndex] + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n\n");

        } //résztáblák kiírása

        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat");
            Console.WriteLine("Adja meg egy bemeneti fájl nevét! ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Adja meg egy sor számát!");
            int rowIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Adja meg egy oszlop számát!");
            int columnIndex = int.Parse(Console.ReadLine());


            int[,] tableFromRead = Program.FileRead(fileName); //fgv meghívása a 9x9-es táblázat megírásához


            Program.ConsoleWrite(tableFromRead); //kiírja a 9x9 táblát
            Console.WriteLine("Az adott helyen szereplő szám: " + tableFromRead[rowIndex-1,columnIndex-1]);

            int[,,] smallTable = Program.ConvertToSmallTables(tableFromRead);
            Program.ConsoleWriteSmall(smallTable);

            Console.ReadKey();
        }
    }
}
