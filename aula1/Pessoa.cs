namespace Models; // crio um nome para  o que estpu fazendo
public class Pessoa (string name, int age, string obs)  // já pode colocar o construtor na hora de declarar a classe
{  
    // instanciando já fazendo get e set
    private string Name {get;set;} =  name; 
    private int Age {get;} = age;
    private string Obs{get; set;} = obs;   

    // -------------------------------------

    // private string? Obs
    // {
    //     get => Obs;
    //     set => Obs = value ;
    // } = obs;

    // -------------------------------------

    public List<string> docs { get; private set;} = new(); // voce só pode settar os valores dentro da classe mas pode gettar fora dela

    private void setDocs(string value) { }

}