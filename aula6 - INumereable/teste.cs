using System;
using System.Collections.Generic;

namespace Exemplo {
    class Program {
        public static void Main() {
            List<int> list = new List<int> { 1, 2, 3 };

            var it = list.GetEnumerator();

            // Mostra números manualmente
            it.MoveNext();
            Console.WriteLine(it.Current);
            it.MoveNext();
            Console.WriteLine(it.Current);

            // Mostrar todos os números
            while (it.MoveNext()) {
                Console.WriteLine(it.Current);
            }

            // Somar os quadrados de todos os números
            int mainResult = list.aoQuadrado().Sum();
            Console.WriteLine(mainResult);

            // Somar os top 4 (ou todos, caso a lista tenha menos de 4)
            // int mainResult2 = list.pegarTopQuatro().Sum();
            // Console.WriteLine(mainResult2);
        }
    }

    // Métodos de extensão definidos na classe Enumerator
    public static class Enumerator {
        public static void readStepTop(IEnumerable<int> collection) { // mostra de 2 em 2
            var l = collection.GetEnumerator();
            while (l.MoveNext() && l.MoveNext()) {
                Console.WriteLine(l.Current);
            }
        }

        public static IEnumerable<int> pegarTopQuatro(IEnumerable<int> coll) {
            var it = coll.GetEnumerator();
            for (int i = 0; i < 4; i++) {
                if (it.MoveNext()) {
                    yield return it.Current;
                }
            }
        }

        // Método de soma
        public static int Sum(this IEnumerable<int> array) {
            int sum = 0;
            var it = array.GetEnumerator();
            while (it.MoveNext()) {
                sum += it.Current;
            }
            return sum;
        }

        // Retorna uma lista de números elevados ao quadrado
        public static IEnumerable<int> aoQuadrado(this IEnumerable<int> coll) {
            List<int> result = new List<int>();
            foreach (int i in coll) {
                result.Add(i * i);
            }
            return result;
        }

        // Retorna números elevados ao quadrado de forma "preguiçosa" (Lazy)
        public static IEnumerable<int> aoQuadradoLazy(this IEnumerable<int> coll) {
            foreach (int i in coll) {
                yield return i * i;
            }
        }
    }
}
