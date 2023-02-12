/* Задача 54: Задайте двумерный массив. Напишите программу, которая 
упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

Console.Write("Задайте количество строк: ");
int row = int.Parse(Console.ReadLine() ?? String.Empty);
Console.Write("Задайте количество столбцов: ");
int col = int.Parse(Console.ReadLine() ?? String.Empty);

int[,] array = new int[row, col];
FillArray(array);
PrintArray(array);
BubbleSort(array);
PrintArray(array);

void FillArray(int[,] arrayF)
{
    Random random = new Random();
    for (int i = 0; i < arrayF.GetLength(0); i++)
    {
        for (int j = 0; j < arrayF.GetLength(1); j++)
        {
            arrayF[i, j] = random.Next(0, 10);
        }
    }
}

void PrintArray(int[,] arrayP)
{
    for (int i = 0; i < arrayP.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < arrayP.GetLength(1); j++)
        {
            Console.Write($"{arrayP[i, j],3}");
        }
    }
    Console.WriteLine();
}

void BubbleSort(int[,] arrayB)
{
    int temp;
    for (int i = 0; i < arrayB.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            for (int k = j + 1; k < arrayB.GetLength(1); k++)
            {
                if (arrayB[i, j] < arrayB[i, k])
                {
                    temp = arrayB[i, j];
                    arrayB[i, j] = arrayB[i, k];
                    arrayB[i, k] = temp;
                }
            }
        }
    }
}
