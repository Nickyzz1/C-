using lista;

myList<int> lista = new myList<int>();

lista.Add(1);
lista.Add(2);
lista.Add(3);
lista.Add(4);
lista.Add(5);
lista.Add(6);

for(int i = 0; i < lista.Count - 1; i++) 
    System.Console.WriteLine(lista[i]);


