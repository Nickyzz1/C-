namespace reading;
public static class ReadClicks {
    public static int? ReadKeyint() {
        var str = Console.ReadKey();
        return (int)str.KeyChar;
    }
}

// 1 : 49, 2 = 50, 3 = 51
// 55 = 7
// 57 = 9
// 32 = espaço