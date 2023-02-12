/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

Console.Write("Задайте размер квадратной матрицы: ");
int n = int.Parse(Console.ReadLine() ?? String.Empty);

int[,] array = new int[n, n];

FillArray(array);
PrintArray(array);





void FillArray(int[,] arrayF)
{
    int i = 0;
    int j = 0;
    int count = 1;

    Perimeter(arrayF, count, i, j, numberPerimeter: 0);

    void Perimeter(int[,] squareArray, int countNumbers, int indexI, int indexJ, int numberPerimeter)
    {
        while (countNumbers - 1 < squareArray.GetLength(0) * squareArray.GetLength(1) + 1)
        {
            if (indexI == numberPerimeter && indexJ < squareArray.GetLength(1) - 1 - numberPerimeter)
            {
                squareArray[indexI, indexJ] = countNumbers;
                indexJ++;
            }
            else if (indexI < squareArray.GetLength(0) - 1 - numberPerimeter && indexJ == squareArray.GetLength(1) - 1 - numberPerimeter)
            {
                squareArray[indexI, indexJ] = countNumbers;
                indexI++;
            }
            else if (indexI == squareArray.GetLength(0) - 1 - numberPerimeter && indexJ > numberPerimeter)
            {
                squareArray[indexI, indexJ] = countNumbers;
                indexJ--;
            }
            else if (indexI > numberPerimeter && indexJ == numberPerimeter)
            {
                squareArray[indexI, indexJ] = countNumbers;
                indexI--;
                if (indexI == numberPerimeter)
                {
                    indexI++;
                    indexJ++;
                    countNumbers++;
                    if(squareArray.GetLength(0) % 2 != 0) squareArray[indexI, indexJ] = countNumbers;
                    numberPerimeter++;
                    Perimeter(squareArray, countNumbers, indexI, indexJ, numberPerimeter: numberPerimeter);
                    break;
                }
            }
            countNumbers++;
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
            Console.Write(arrayP[i, j].ToString(" 00"));
        }
    }
    Console.WriteLine();
}
