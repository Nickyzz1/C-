using System;

var red = 1;
var green = 2;
var blue = 3;
var yellow = 4;

// cima, meio, baixo, tras, esquerda, direita
var blockA = new int[6] { red, yellow, blue, yellow, yellow, green };
var blockC = new int[6] { green, blue, green, yellow, red, green };

// Função para criar uma matriz 6x6 zerada
int[,] CreateNewMatrix()
{
    var matrix = new int[4, 4];
    for (int i = 0; i < 4; i++)
        for (int j = 0; j < 4; j++)
            matrix[i, j] = 0;
    return matrix;
}

// Função para exibir uma matriz
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
            Console.Write(matrix[i, j] + "\t");
        Console.WriteLine();
    }
    Console.WriteLine();
}

// Função para validar um par específico de linhas
bool ValidatePair(int a, int c)
{
    return a != c; // os valores devem ser diferentes
}

// Função principal para gerar combinações válidas
void GenerateValidMatrices()
{
    int totalCombinations = 0;
    int count = 0;

    // Verificar todas as combinações possíveis de linhas
    for (int line1 = 0; line1 < blockA.Length; line1++)
    {
        for (int line2 = line1 + 1; line2 < blockA.Length; line2++)
        {
            // Valores a serem validados
            int valueA1 = blockA[line1 + count];
            int valueC1 = blockC[line1 + count];

            int valueA2 = blockA[line2 + count + 1];
            int valueC2 = blockC[line2 + count + 1];

            Console.WriteLine($"Conferindo linha[{line1}] matriz A: {valueA1} com linha[{line1}] matriz C: {valueC1}");
            Console.WriteLine($"Conferindo linha[{line2}] matriz A: {valueA2} com linha[{line2}] matriz C: {valueC2}");

            // Validar o par de valores
            bool isValid1 = ValidatePair(valueA1, valueC1);
            bool isValid2 = ValidatePair(valueA2, valueC2);

            if (isValid1 && isValid2)
            {
                Console.WriteLine("Já que os dois são válidos, a matriz é válida.");
                var newMatrix = CreateNewMatrix();
                newMatrix[line1, 0] = valueA1;
                newMatrix[line1, 2] = valueC1;
                newMatrix[line2, 0] = valueA2;
                newMatrix[line2, 2] = valueC2;

                PrintMatrix(newMatrix);
                totalCombinations++;
            }
            else
            {
                Console.WriteLine("Já que um dos dois é inválido, não printa.");
                Console.WriteLine();
            }
           count +=1;
        }
    }

    Console.WriteLine($"Total de combinações válidas: {totalCombinations}");
}

// Executa a função principal
GenerateValidMatrices();
