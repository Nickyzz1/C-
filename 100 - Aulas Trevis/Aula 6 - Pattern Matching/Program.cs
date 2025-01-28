using System.Numerics;

object num = 450;

if (num is <500 and >400 and int number)
{
    
}

List<int> list = [ 1, 2, 3, 4, 5 ];
int[] list2 = [ 0, ..list, 6, 7, 8 ];
foreach (var x in list2[2..5])
    Console.WriteLine(x); // 2, 3, 4
Console.WriteLine(list2[^3]); // 6

if ("Olá mundo" is [ .., 'm', 'u', 'n', 'd', 'o' ])
{
    
}


int var1 = 3;
string var2 = "ACCEPTED";
bool var3 = false;

int result = (var1, var2, var3) switch
{
    (0, "ACCEPTED", true) => 1,
    (>0, "ACCEPTED", false) => 2,
    (>5 and <18, "ACCEPTED" or "FAIL", true) => 3,
    (>18, _, false) => 4,
    _ => 5
};

List<int> values = [ 1, 2, 3, 4, 5, 6 ];
if (values is [ 1, 2, int value2, .. ])
{

}
var result2 = values switch
{
    [ 1, 2, _, 4, ..] or [ .., 5, 6] => "OK",
    [ 1, 2, int value, .. ] => value.ToString(),
    _ => "VISH"
};
if (values is null)
{

}

if (values is not [ 1, int num3, .. ])
{
    
}

int valor = 1231;
int outrovalor = valor switch
{
    <1231 => 3,
    1231 => 4,
    >=1233 => 5,
    _ => 6
};

Instrutor[] instrutors = [ 
    new Instrutor("don", 1.4f),
    new Instrutor("queila", 1.45f),
    new Instrutor("trevis", 2.45f),
];

foreach (var instrutor in instrutors)
{
    string result4 = instrutor switch
    {
        { Altura: < 1.7f } => "BAIXIN KKKK",
        { Altura: > 1.7f, Nome: not "trevis" } => "ALTIN",
        _ => "LINDÃO"
    };
    Console.WriteLine($"{instrutor.Nome} é {result4}");
}

var etsCuritiba = new ETS("Curitiba", instrutors);
foreach (var instrutor in etsCuritiba?.Instrutors ?? [])
{
    Console.WriteLine(instrutor?.Nome ?? "Sem nome");
}

public record ETS(string Cidade, Instrutor[] Instrutors);

public record Instrutor(string Nome, float Altura);