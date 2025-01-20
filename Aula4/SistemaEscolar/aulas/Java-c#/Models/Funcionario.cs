namespace Models;

public class Funcionario(string name, decimal salarioInicial) 
    : Pessoa(name)
{
    public decimal Salario { get; set; } = salarioInicial;
    public string Cargo { get; set; }

    public decimal CalcularSalarioAnual() => Salario * 12;
}