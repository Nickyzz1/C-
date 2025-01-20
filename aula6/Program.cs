int[] array = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ];

var result = array.FirstOrDefault<int>();

Console.WriteLine($"FirstOfDefault: {array.FirstOrDefault<int>()}");
Console.WriteLine($"LastOrDefault: {array.LastOrDefault<int>()}");

Console.Write("\nToArray: ");
foreach (var item in array.ToArray()){
    Console.Write($"{item} ");
}
Console.Write($"\nTipo: {array.ToArray().GetType()}\n");

Console.Write("\nToList: ");
foreach (var item in array.ToList()){
    Console.Write($"{item} ");
}
Console.Write($"\nTipo: {array.ToList().GetType()}\n");


Console.Write("\nTake: ");
foreach (var item in array.Take(3)){
    Console.Write($"{item} ");
}

Console.Write("\nSkip: ");
foreach (var item in array.Skip(3)){
    Console.Write($"{item} ");
}

Console.Write("\nAppend: ");
foreach (var item in array.Append(58)){
    Console.Write($"{item} ");
}

Console.Write("\nPreprend: ");
foreach (var item in array.Preprend(58)){
    Console.Write($"{item} ");
}

System.Console.WriteLine($"\nCount: {array.myCount()}");

public static class Enumerator
{
    public static T? FirstOrDefault<T>(this IEnumerable<T> coll) // pega o primeiro ou o default
    {
        var it = coll.GetEnumerator();
        int count = 0;
        if(it.MoveNext() && count < 1) 
            return it.Current;
        return default;
    }

    public static T? LastOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        int count = 0;

        while(it.MoveNext()){

            if(count == coll.Count() - 1){
                return it.Current;
            } else {
                count++;
            }
        }
        return default;
      
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        T[] newArray = new T[coll.Count()];
        int count = 0;

        while(it.MoveNext()) {
            newArray[count] = it.Current;
            count++;
        }
        return newArray;
      
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();
        var it = coll.GetEnumerator();
        if(it.MoveNext()) {
            list.Add(it.Current);
        }
        return list;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int num) // pegar o primerio até o 5
    {
        var it = coll.GetEnumerator();

        for(int i = 0; i < num; i++) {
                it.MoveNext();
                // System.Console.WriteLine(it.Current);
                yield return it.Current;
            }
  
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int num) // pulo 5 e pego o resto
    {
        var it = coll.GetEnumerator();

        for (int i = 0; i < num; i++){
            it.MoveNext();
        }

        for(int i = num; i < coll.Count(); i++) {
                it.MoveNext();
                yield return it.Current;
        }
        
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item) // adiciona um valor ao final de uma sequencia
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext()){
            yield return it.Current;
        }
        yield return item;
    }

    public static IEnumerable<T> Preprend<T>(this IEnumerable<T> coll, T item) // adiciona o um valor no incnio d alista
    {
        // List<T> list = new List<T>();
        // list.Add(item);
        var it = coll.GetEnumerator();
        yield return item;
        while(it.MoveNext()){
            yield return it.Current;
        }
    }

    public static int myCount<T>(this IEnumerable<T> coll) // retorna o numero de elementos
    {
        var it = coll.GetEnumerator();
        int count = 0;
        while(it.MoveNext()) {
            count++;
        }
        return count;
    }

   

    // public static IEnumerable<int> PegaPar(this IEnumerable<int> coll)
    // {
    //     foreach (var val in coll)
    //         if (val % 2 == 0)
    //             yield return val;
    // }
    
    // public static IEnumerable<int> PegaQuadrado(this IEnumerable<int> coll)
    // {
    //     foreach (var x in coll)
    //         yield return x * x;
    // }

    // public static IEnumerable<int> PegaTop4(this IEnumerable<int> coll)
    // {
    //     var it = coll.GetEnumerator();
    //     for (int i = 0; i < 4; i++)
    //     {
    //         if (it.MoveNext())
    //             yield return it.Current;
    //     }
    // }
    
    // public static int Sum(this IEnumerable<int> array)
    // {
    //     int soma = 0;
    //     var it = array.GetEnumerator();
    //     while (it.MoveNext())
    //     {
    //         soma += it.Current;
    //     }
    //     return soma;
    // }
}

// public interface IEnumberable<T>
// {
//     IEnumerator<T> GetEnumerator();
// }

// public interface IEnumerator<T>
// {
//     bool MoveNext();
//     T Current { get; }
// }