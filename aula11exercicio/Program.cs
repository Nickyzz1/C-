using System;
using System.Reflection;
using System.Text.Json;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Salario { get; set; }

    public Funcionario(int id, string nome, double salario)
    {
        Id = id;
        Nome = nome;
        Salario = salario;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Funcionario funcionario = new Funcionario(1, "Nini", 100_000);
        Type myType = typeof(Funcionario);

        // obtém as propriedades da classe
        var myPropertyInfo = myType.GetProperties();

        Console.WriteLine("{");
        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var item = myPropertyInfo[i];
            if (item.CanRead)
            {
                // pega o valor da propriedade do objeto
                var value = item.GetValue(funcionario);
                // converte o objt para o formato em json
                string jsonValue = JsonSerializer.Serialize(value); 

                // Adiciona vírgula entre os itens, exceto no último
                Console.Write($"    \"{item.Name}\" : {jsonValue}");
                if (i < myPropertyInfo.Length - 1)
                {
                    Console.WriteLine(",");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine("}");
    }
}
