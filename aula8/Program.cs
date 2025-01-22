using System.Data.Common;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

// var aluno = new Aluno("donzinho", 16);
// var aluno2 = aluno2 with { Nome = "queila"};
// var aluno2 = aluno2 with { Idade = 20};

// var box = new Caixa(8);
// box.OnValueChanged += () => System.Console.WriteLine("Cortei o cabelo e gostaram"); // função lambda
// box.OnValueChanged += (valor, caixa) => System.Console.WriteLine($"a caixa tem {caixa.Nome} e {valor}"); // função lambda

// box.valor++;

//STACK TRACE

try {
    System.Console.WriteLine();
}
// especificando a exeption
catch (DbException ex ) when (ex.ErrorCode == 500) { 
    throw;
} 
catch (Exception ex) {
    System.Console.WriteLine(ex.Message);
    throw;
} 
finally {
    System.Console.WriteLine();
}

public record Aluno (string Nome, int Idade) { /// RECORD :  é uma classe que nn pode ser modificada só pode ser usada para modelar dados (com jsons)
    public required string Nome {get; init;}
    public required int Idade {get; init;}
}

public class Pessoa (string nomeUser, string lastName, int Idade) {

    private string name = nomeUser; // atributos/campos(fields): td que nn tiver get/set
    private readonly string Sobrenome = lastName ; // não é possível mudar/settar
    public int age {get; private set;} = Idade; // private set só pode ser mudado na própria classe
    public int somInteger{get;init;} //pode setar na inicialização apenas, não depois
    public int someIntegerToo{get;init;} //pode setar na inicialização apenas, não depois
    public required string OutherString{get; init;} //propriedades (properties) com get e set
    
    //======== O QUE PODE TER EM UMA CLASSE ===========

    //Classe (records, enums)
    //métodos
    //construtores
    //destrutores
    //sobrecarga de operadores (?)
    //eventos

    // Modificadores de acesso java
    ///public
    //private
    //protected
    //default (só poide ser usado no mesmo pacote)

    //c# Tem td e mais um pouco
    //internal( igual ao default, nn funciona em projetos diferentes)
    //internal protected (visto publico no seu projeto, mas no projetto de outras pessoa, só pode ser usado se a pessoa herdar daquela classe)
    //private protected (pode ver na classe filha e nn funciona em diferentes projetos)
    //file (nn existe fora do arquivo a classe)

    // ORIENTAÇÃO A EVENTOS C# É FEITA COM DELEGATE
    // como definir eventos: palavras reservadas e um delegade
}

public class Caixa(string nome, int valor) {
    // quando o valor da caixa for modifuicado deve haver uma notificação
    private int Valor = valor;
    private string Nome = nome;

    public required Action<int, Caixa> OnValueChanged; // nn recebe nada e nn retorna nd
    public int valor {
         get => valor;
         set {
            valor = value;
            if(OnValueChanged is null) {
                return;
            }
            // OverValueException;
         }
    }

}