/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы 
каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */

Console.WriteLine("Задайте трехмерный массив.");
Console.Write("Задайте количество строк (rows): ");
int rows = int.Parse(Console.ReadLine() ?? String.Empty);
Console.Write("Задайте количество столбцов (columns): ");
int columns = int.Parse(Console.ReadLine() ?? String.Empty);
Console.Write("Задайте глубину массива (depth): ");
int depth = int.Parse(Console.ReadLine() ?? String.Empty);

if (rows * columns * depth > 89)
{
    Console.WriteLine();
    Console.WriteLine($"rows * columns * depth = {rows * columns * depth}, количество ячеек трехмерного массива не должно превышать 89,");
    Console.WriteLine("при превышении данного значения массив не может быть заполнен двухзначными не повторяющимися числами.");
}

int[,,] array = new int[rows, columns, depth];

FillArray(array);
PrintArray(array);


void FillArray(int[,,] arrayF)
{
    int numberRandomMin = 10;
    int numberRandomMax = 99;
    int[] arrayRandom = new int[numberRandomMax - numberRandomMin];
    for (int i = 0; i < arrayRandom.Length; i++)
    {
        arrayRandom[i] = i + numberRandomMin;
    }

    int temp;
    int iRandom;
    Random random = new Random();
    for (int i = 0; i < arrayRandom.Length; i++)
    {
        iRandom = random.Next(0, arrayRandom.Length);
        temp = arrayRandom[i];
        arrayRandom[i] = arrayRandom[iRandom];
        arrayRandom[iRandom] = temp;
    }

    int indexArrayRandom = 0;
    for (int k = 0; k < arrayF.GetLength(2); k++)
    {
        for (int i = 0; i < arrayF.GetLength(0); i++)
        {
            for (int j = 0; j < arrayF.GetLength(1); j++)
            {
                if (indexArrayRandom == numberRandomMax - numberRandomMin - 1) indexArrayRandom = 0;
                arrayF[i, j, k] = arrayRandom[indexArrayRandom++];
            }
        }
    }
}

void PrintArray(int[,,] arrayP)
{
    for (int k = 0; k < arrayP.GetLength(2); k++)
    {
        Console.WriteLine();
        for (int i = 0; i < arrayP.GetLength(0); i++)
        {
            for (int j = 0; j < arrayP.GetLength(1); j++)
            {
                Console.Write($"{arrayP[i, j, k],3} ({i}, {j}, {k})");
            }
            Console.WriteLine();
        }
    }
}