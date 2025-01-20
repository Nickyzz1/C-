//! TIPOS

// // Inteiros
// byte bt = 0;
// short st = 0;
// int it = 1;
// long lg = 1;

// // Flutuante
// float fl = 0.1f;
// double d = 0.1;
// decimal dc = 0.2M; // Dinheiro

// // Caractere
// char c = 'a';
// string str = "string";

// // Boleano
// bool bl = false;

// //--------------------------------
// // tipos anulaveis

// int? podeSerNull = 1_000_000_000; // 1000000000
// float? flt = (float)podeSerNull;


// // java
// // String a = "a";
// // String b = "b";
// // boolean equals = a.equals(b);

// string a = "a";
// string b = "b";
// if(a == b){}


// // AlgumaClasse agc = new();


// tuplas 
// var tuple = (name: "Irineu", idade:20);
// Console.WriteLine(tuple.name);
// Console.WriteLine();




// -----------------------------------------
// namespaces

// using Models;

// Pessoa irineu = new("Irineu");
// irineu.Name = "josias";
// foreach (var item in irineu.docs)
// {
    
// }
// System.Console.WriteLine(irineu.Name);


// Classe cls = new();

// cls["Qtd Alunos"] = 12;
// cls["Professor"] = "Nycollas";
// // {
// //     "Professor": "Nycollas",
// //     "Qtd Alunos" : 12
// // }
// Console.WriteLine(cls["Professor"]); // "Nycollas"


// Funcionario func = new("Nycollas", 1_000.00M);
// Console.WriteLine(func.Salario.ToString("C2"));


// --------------------------------------------------------------
using NewSystem;

NewConsole.Print("Pressione uma tecla: ");
int? a = NewConsole.ReadLineInt();
NewConsole.Print("Pressione outra tecla: ");
int? b = NewConsole.ReadLineInt();

if(a is null || b is null)
    NewConsole.Print("Algum numero inválido");
else
    NewConsole.Print(a + b);


//! Utilizando 'using static'
// using static NewSystem.NewConsole;

// Print("Digite um numero: ");
// int? a = ReadLineInt();
// Print("Digite um numero: ");
// int? b = ReadLineInt();

// if(a is null || b is null)
//     Print("Algum numero inválido");
// else
//     Print(a + b);

