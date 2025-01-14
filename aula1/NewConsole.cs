namespace System;
public static class NewConsole // classe estatica
{
    public static int? ReadLineInt() {
        var str = Console.ReadLine(); // le uma linha do console
        if(int.TryParse(str, out int i)) // tentar transfortmar em int
            return i;   

        return null;
    }
    public static void Print(Object obj) => Console.WriteLine(obj.ToString());
    
}