using System.Text;
using System.Collections;

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
    public static Task<string> ToJsonAsync<T>(this T obj)
        => Task.Factory.StartNew(() => obj.ToJson());

    public static string ToJson<T>(this T obj)
    {
        var sb = new StringBuilder();
        AppendObject(obj, sb);
        return sb.ToString();
    }

    private static void AppendObject(object? obj, StringBuilder sb)
    {
        if (obj is string) {
            sb.Append($"\"{obj}\"");
            return;
        }

        if (obj is IEnumerable collection) {
            AppendCollection(collection, sb);
            return;
        }

        var type = obj.GetType();
        if (type.IsPrimitive || type == typeof(decimal)) {
            sb.Append(obj.ToString());
            return;
        }

        AppendComplexObject(obj, type, sb);
    }

    private static void AppendComplexObject(object obj, Type type, StringBuilder sb)
    {
        sb.AppendLine("{");
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            sb.Append($"\t\"{property.Name}\": ");
            AppendObject(value, sb);
            sb.AppendLine();
        }
        sb.Append('}');
    }

    private static void AppendCollection(IEnumerable collection, StringBuilder sb)
    {
        sb.Append("[ ");
        foreach (var item in collection)
        {
            AppendObject(item, sb);
            sb.Append(", ");
        }
        sb.Append(" ]");
    }
}
