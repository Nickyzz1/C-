// Pattern matching

using System.Runtime.CompilerServices;

Object obj = 99;
if(obj is int number) { // se for inteiro coloque dentro da variável number
    System.Console.WriteLine(number + 1);
}

int num = 500;

if(num is 400 or 500) {
    System.Console.WriteLine("éeeee");
} else {
    System.Console.WriteLine(num); // posso printar o num apenas no else
}

// if(num is < 400 and >500 and int isNumber) {
//     System.Console.WriteLine("éeeee");
// }

List<int> list = [1,2,34,5];
// int[] list2 = [ 0, list, 6,7,8];

foreach(var x in list[2..5]) { // pegar intervalo específico
    Console.WriteLine(x);
}

System.Console.WriteLine(list[3]);

if (list is [1,2,3,..]) { // ele ve se o 1,2,3 etá no começo nda lista

}

if (list is [..,1,2,3]) { // ele ve se o 1,2,3 etá no final nda lista

}

int var1 = 3;
string var2 = "ACCEPTED";
bool var3 = false;

// comparações
int result = (var1,var2,var3) switch 
{
    (0, "ACCEPTED", true) => 1,
    (> 0, "ACCEPTED", false) => 2,
    (>5 and <18, "ACCEPTED" or "FAIL", true ) => 3,
    (>18, _, false) => 4,
    _ => 5
};

// td que está nas verifiações pode ser colocada depois do "is"

List<int> values = [ 1,2,3,4,5,6,7,8,9,10,11,];
var result2 = values switch {
    [1,2,_, 4,..] or [..,5,6] => "OK", // se começar com 1, 2, um numero qualquer e 4 ou terminar com 5,6 ele dá okay
    [1,2,int value] => value.ToString(), // se começar com 1,2 e o terceitro número foi um int...
    _=> "VISH"
};

if(values is null){}
if(values is not []){}

int valor = 1231;

int outroValor = valor switch{
    <1231 => 3,
    1231 => 4,
    >=1233 => 5,
    _=> 0
};

Object outroValor2 = valor switch{
    <1231 => 3,
    1231 => 4,
    >=1233 => 5,
    _=> "aff"
};

Instrutor[] instrutors = [
    new Instrutor("dom", 1.45f),
    new Instrutor("trevis", 2.45f)
];

foreach (var inst in instrutors)
{
    string result3 = inst switch{
        {Altura: < 1.7f} => "baixin kkkkk",
        {Altura: > 1.7f, Nome: not "trevis"} => "altin",
        _ => "meio a meio"
    };
}
var etsCuritiba = new ETS("Curitiba", instrutors);

foreach (var inst in etsCuritiba?.Instrutorss??[]) // tratamento de erro nulo, se td for nulo retorne a expressão da direita "[]"
{
    //nullpointer execpetion é quando ele acha algo nulo e não sabe tratar, exemplo do foreach, se eleachar um elemento na lsita que for n ulo, se a lista for nula, se o .instructor for nulo
    System.Console.WriteLine(inst?.Nome?? "sem nome"); // vcerifica se td é nulo
}
// records e classes sempre em baixo ou da top-level error
public record Instrutor(string Nome, float Altura);
public record ETS(string Cidade, Instrutor[] Instrutorss);


