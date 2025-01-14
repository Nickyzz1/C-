using Models;
using System;

// caracteres
var abs = "";
char a = 'a';
string s = "str";

//inteiros
byte bt = 0;
short st = 0;
int it = 1;
long lg = 1;

// flutuante
float fl = 0.1f; // se for float e nn colocar f no final vai interpretar automaticamente como double
double d = 0.1;
decimal dc = 0.2M;

// booleano 
bool bl = false;

// tipos anulaveis

int? podeSerNull = null;
int? escritaDiferente = 1_000_000;

// comparação de string

string aS = "a";
string bS = "b";

if(aS == bS){ System.Console.WriteLine("é igual"); }

// conversão/ type cast

float? flt = (float)escritaDiferente;

// tuplas

var tupla = (name: "Nini", idade: 18);
Console.WriteLine(tupla.name);

// print

Console.WriteLine(a + "\n" + s + "\n" + abs + "\n"  + bt + "\n" + st + "\n" + fl + "\n" + d + "\n" + dc + "\n" + bl + "\n"+ podeSerNull + "\n" + it + "\n" + lg); 

// array
// tipo[] nomeDoArray = new tipo[tamanho_do_array];

int[] array = new int[10];

// inserção de dados

int[] array1 = new int[5] { 1, 3, 7, 12, 8 };
int[] array2 = { 1, 3, 2, 7, 6 };

// ponto de ! é o contrário do de ?, se ? = pode ser nulo, ! = deve ter um valor

// classes
// AlgumaClasse agc = new();

Funcionario func = new("Nicolle", 18, "aprendiz", 1000000);

NewConsole.Print("Pressione uma tecla numérica: ");
int? read = NewConsole.ReadLineInt();
NewConsole.Print("Pressione outra tecla numérica: ");
int? read2 = NewConsole.ReadLineInt();

if(read is null || read2 is null){
    NewConsole.Print("Inválido");
} else {
    NewConsole.Print("Resultado: ");
    NewConsole.Print( read + read2);
}
