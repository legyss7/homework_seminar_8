/* Задача 58: Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

Console.WriteLine("Задайте размерность перемножаемых матриц (А и B)");
Console.Write("Задайте количество строк матрицы A: ");
int rowsA = int.Parse(Console.ReadLine() ?? String.Empty);
Console.Write("Задайте количество столбцов матрицы A: ");
int columnsA = int.Parse(Console.ReadLine() ?? String.Empty);
Console.WriteLine($"Количество строк матрицы B: {columnsA}");
Console.Write("Задайте количество столбцов матрицы B: ");
int columnsB = int.Parse(Console.ReadLine() ?? String.Empty);

int[,] matrixA = new int[rowsA, columnsA];
int[,] matrixB = new int[columnsA, columnsB];

FillArray(matrixA);
FillArray(matrixB);

PrintArrayMul(matrixA, matrixB, MulArrays(matrixA, matrixB));



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

void PrintArrayMul(int[,] arrayA, int[,] arrayB, int[,] arrayC)
{
    Console.Write("\nПроизведение матриц (A * B = C)\n");
    Console.Write("\nМатрица А:\n");
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < arrayA.GetLength(1); j++)
        {
            Console.Write($"{arrayA[i, j],3}");
        }
        Console.Write("|\n");
    }
    Console.Write("\nМатрица B:\n");
    for (int i = 0; i < arrayB.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            Console.Write($"{arrayB[i, j],3}");
        }
        Console.Write("|\n");
    }
    Console.Write("\nМатрица C:\n");
    for (int i = 0; i < arrayC.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < arrayC.GetLength(1); j++)
        {
            Console.Write($"{arrayC[i, j],5}");
        }
        Console.Write("|\n");
    }
}

int[,] MulArrays(int[,] arrayA, int[,] arrayB)
{
    int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayC.GetLength(0); i++)
    {
        for (int j = 0; j < arrayC.GetLength(1); j++)
        {
            for (int k = 0; k < arrayB.GetLength(0); k++)
            {
                arrayC[i, j] += arrayA[i, k] * arrayB[k, j];
            }
        }
    }

    return arrayC;
}