using System.Text;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Collections;

Funcionario funcionario = new Funcionario(1, "Nini", 100_000);
var obj = funcionario.GetType().GetProperties();

Type myType = typeof(Funcionario);
Type[] myTypeArray = new Type[2];

myTypeArray.SetValue(typeof(int), 0);
myTypeArray.SetValue(typeof(int),1);

IEnumerable myPropertyInfo = myType.GetProperties();

foreach (var item in myPropertyInfo)
{
    System.Console.WriteLine($"        Nome : {item.Name}\n        Salario : {item.Salario}");
}

System.Console.WriteLine("{");





var empresa = new Empresa(
    "Bosch",
    new Funcionario(1, "Fábio", 100_000), [
    new Funcionario(2, "Don", 50_000),
    new Funcionario(3, "Queila", 20_000),
    new Funcionario(4, "Trevis", 600),
    ]
);

var json = empresa.ToJson();
Console.WriteLine(json);

public record Funcionario(
    int Id,
    string Nome,
    decimal Salario
);
public record Empresa(
    string Nome,
    Funcionario Chefe,
    List<Funcionario> Funcionarios
);

public static class Converter
{
    // public static Task<string> ToJsonAsync<T>(this T obj)
    // {
       
    // }

    public static string ToJson<T>(this T obj)
    {
        var sb = new StringBuilder();
        AppendObject(obj, sb);
        return sb.ToString();
    }

    private static void AppendObject<T>(T? obj, StringBuilder sb)
    {
        throw new NotImplementedException();
    }

    private static void toJson<T>(T obj, StringBuilder sb)
    {
	
    }
}


// um objeto e tranformar num json emnum arquivo reflexãoi
// json de outrso json
// json de listas