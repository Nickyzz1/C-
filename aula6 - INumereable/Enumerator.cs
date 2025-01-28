// using System.Data.SqlTypes;

// List<int> list = [1,2,3];

// var it = list.GetEnumerator();

// // mostrra numeros manualmente
// it.MoveNext();
// System.Console.WriteLine(it.Current);
// it.MoveNext();
// System.Console.WriteLine(it.Current);

// // mostrar todos os números
// while (it.MoveNext()) { 
//     System.Console.WriteLine(it.Current);
// }

// public static class Enumerator {
    

//     public static void readStepTop(IEnumerable<int> collention) { // mostra de 2 em 2
//         var l = collention.GetEnumerator();
//         while(l.MoveNext() && l.MoveNext()) {
//             System.Console.WriteLine(l.Current);
//         }
//     }

//     public static IEnumerable<int> pegarTop4(IEnumerable<int> coll) {
//         var it = coll.GetEnumerator();
//         for(int i = 0; i < 4; i ++) {
//             if(it.MoveNext()) {
//                 yield return i;
//             }
//         }
//     }

//     // retorna uma lista de numeros somados
//     public static int Sum (this IEnumerable<int> array) {
//         int sum = 0;
//         var it = array.GetEnumerator();
//         while(it.MoveNext()) {
//             sum += it.Current;
//         }
//         return sum;
//     }

//     // retorna uma lista/enumereable
//     public static IEnumerable<int> aoQuadrado(this IEnumerable<int> coll) {
//         List<int> result = [];
//         foreach(int i in coll) {
//             result.Add(i *i);
//         }
//         return result;
//     }

//     // executa aoenas por demanda, umd e cada vez só quando eu enviar a informação, ou seja, a cada linha procesaada ele descongela um processo
//     public static IEnumerable<int> aoQuadrado2(this IEnumerable<int> coll) {
//         // é como se fosse a stream(de java) do c#
//         List<int> result = [];
//         foreach(int i in coll) {
//         yield return i *i;
//     }}

//     int mainResult = Sum(aoQuadrado(pegarTop4(list)));
//     int mainResult2 = list.pegarTop4().



// // public interface IEnumerator<T> {
// //     bool MoveNext();
// //     T Current { get; }
// // }

// // public interface IEnumerable<T> {
// //     IEnumerator<T> GetEnumerator();

// // }



// }