namespace NewSystem;

public static class NewConsole
{
    public static int? ReadLineInt()
    {
        var str = Console.ReadLine();

        if(int.TryParse(str, out int i))
            return i;

        return null;
    }

    public static int? ReadKeyInt()
    {
        var str = Console.ReadKey();

        return (int)str.KeyChar;
    }

    public static void Print(object obj) => Console.WriteLine(obj.ToString());
}