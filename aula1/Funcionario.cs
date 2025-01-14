using Models;
// HERANÇA
public class Funcionario(string name, int age, string obs, decimal salarioInicial) : Pessoa(name, age, obs) {

    public decimal Salario = salarioInicial; // instancia

    public decimal getSalario() => Salario;  // get

    public decimal calcularSalario() => Salario * 12; // função

}

// ------------------------------------- OUTRA FORMA DE ESCREVER -------------------------------------

// public class Funcionario : Pessoa(string name, int age, string obs, decimal salarioInicial) : base(name, age, obs) {

    // public Funcionario(string name, int age, string obs, decimal salarioInicial) : base(name, age, obs) // base são os argumentos da classe pai, são obrigatórios pois ele está herdando
    // {
    //     public decimal Salario { get; set;} = salarioInicial;
    // }