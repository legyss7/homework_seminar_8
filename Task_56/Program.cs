/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая 
будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
наименьшей суммой элементов: 1 строка */

Console.WriteLine("Задайте прямоугольный двумерный массив!");
Console.Write("Задайте количество строк: ");
int rows = int.Parse(Console.ReadLine() ?? String.Empty);
Console.Write("Задайте количество столбцов: ");
int columns = int.Parse(Console.ReadLine() ?? String.Empty);

if (rows == columns)
{
    Console.WriteLine("Количество задаваемых строк не должно быть равно количеству столбцов.");
    return;
}

int[,] array = new int[rows, columns];
FillArray(array);
PrintArray(array);
Console.WriteLine($"Строка с наименьшей суммой элементов: {RowWithSmallestSum(array)}");


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

int RowWithSmallestSum(int[,] arrayR)
{
    int numberRowWithSmallestSum = 0;
    for (int i = 0; i < arrayR.GetLength(0); i++)
    {
        for (int j = 1; j < arrayR.GetLength(1); j++)
        {
            arrayR[i, 0] += arrayR[i, j];
        }

        if (arrayR[0, 0] > arrayR[i, 0])
        {
            arrayR[0, 0] = arrayR[i, 0];
            numberRowWithSmallestSum = i;
        }
    }

    return numberRowWithSmallestSum + 1;
}
