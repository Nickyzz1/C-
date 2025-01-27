using System;
using System.Reflection; // capacidade de ler o priprio código e tomar decisões em cima disso

// =================== IPROGRAM SCOPE ====================

var type = typeof(Funcionario);

Console.WriteLine($"Class {type.Name}:");

// Obtém membros publicos!
foreach (var prop in type.GetMembers()) {
    System.Console.WriteLine($"{prop.MemberType} {prop.Name} :
    {prop.DeclaringType}");
}
// Obtém campos privados!
foreach (var field in type.GetRuntimeFields()) {
    Console.WriteLine($"\t{field.MemberType} {field.Name} :
    {field.DeclaringType}");
}
Console.WriteLine();
Funcionario funcionario = new Funcionario("Xispita", "12345678", 10);
var nameProp = type.GetProperty("Nome");
var name = nameProp.GetValue(funcionario) as string;
nameProp.SetValue(funcionario, name + "!");
Console.WriteLine(funcionario.Nome);
var calcMethod = type.GetMethod("CalcularSalario");
var wage = calcMethod.Invoke(funcionario, new object[] { 200 });
Console.WriteLine(wage);
Console.WriteLine();
var assembly = Assembly.GetExecutingAssembly();
foreach (var x in assembly.GetTypes())
Console.WriteLine(x.Name);

// =================== INTERFACES ====================

public interface IReadeable<out T> { T GetValue();}

public interface IStorable<in T> { void SetValue(T value);}

public interface IBox<T> : IReadeable<T>, IStorable<T>;

// =================== CLASSES ======================

public class Pessoa;
public class Cliente : Pessoa;

public class SimpleBox<T> : IBox<T> {

    public T GetValue() { throw new NotImplementedException();}

    public void SetValue(T value){ throw new NotImplementedException();}
}

public class Funcionario {
    
    public string? Nome {get;set;}
    public int Idade {get;set;}

    public static void Trabalhar(int hours) {
        if( hours > 32) {
            System.Console.WriteLine("Estou cansado chefe!");
        }
    }
}

public class A {}
public class A1 : A {} 
public class A2 : A {} 

public class B<T> where T : A {
    public T? Result {get;set;}
}

// ainda não pode ser feito com um construtor vazio
public class B<T, U> 
    where T : U, new() // retringindo a um tipo U
    where U : class { // restringindo a ser uma classe
        public T Create() => new T();
    }

public class C1<T> where T : class { } // T deve ser uma classe
public class C2<T> where T : class? { } // pode que pode receber valor nulo
public class C3<T> where T : struct { } // T deve ser uma struct 
public class C4<T> where T : notnull { } // Não deve ser anulável
public class C5<T> where T : unmanaged { } // Deve ser um tipo gerenciável, structs


// // ================== ANOTAÇÕES =================================
// int e object nn funcionam pq um é tipo por valor e outro é tipo por refernecia 
// // são a mesma coisa
// int? y = null;
// Nullable<int> z = null;
// System.Console.WriteLine(y + z);

/**
33 Saída:
34 Class Funcionario:
35 Method get_Nome : Funcionario
36 Method set_Nome : Funcionario
37 Method get_EDV : Funcionario
38 Method set_EDV : Funcionario
39 Method get_SalarioHora : Funcionario
40 Method CalcularSalario : Funcionario
41 Method GetType : System.Object
42 Method ToString : System.Object
43 Method Equals : System.Object
44 Method GetHashCode : System.Object
45 Constructor .ctor : Funcionario
46 Property Nome : Funcionario
47 Property EDV : Funcionario
48 Property SalarioHora : Funcionario
49 Field salarioHora : Funcionario
50 Field <Nome>k__BackingField : Funcionario
51 Field <EDV>k__BackingField : Funcionario
52
53 Xispita!
*/
