var empresa = new Chefe("Robert Bosch", [
    new Chefe("Fábio", [
        new Espiao("Don"),
        new Operario("Trevis"),
        new Chefe("Queila", [
            new Operario("Sabrina"),
            new Operario("Wallace"),
            new Operario("Adrian"),
            new Operario("Helena"),
            new Operario("Juan"),
            new Espiao("Cristian"),
        ])
    ])
]);

var mensagem = new Mensagem(null, null, "Cristian é um espião", MensagemTipo.Privada);
empresa.Receber(mensagem);


public enum MensagemTipo
{
    Confidencial,
    Privada,
    Publica
}

public record Mensagem(
    Funcionario Remetente,
    Funcionario Destinatario,
    string Texto,
    MensagemTipo Tipo
);

public abstract class Funcionario(string nome)
{
    public readonly string Nome = nome;
    public abstract void Receber(Mensagem mensagem);
}

public class Operario(string nome) : Funcionario(nome)
{
    public override void Receber(Mensagem mensagem) { }
}

public class Chefe(string nome, List<Funcionario> funcs) : Funcionario(nome)
{
    public readonly List<Funcionario> Funcionarios = funcs;

    public override void Receber(Mensagem mensagem)
    {
        if (mensagem.Tipo == MensagemTipo.Confidencial)
        {
            foreach (var chefe in Funcionarios.Where(f => f is Chefe))
                chefe.Receber(mensagem);
        }
        
        foreach (var func in Funcionarios)
            func.Receber(mensagem);
    }
}

public class Espiao(string nome) : Funcionario(nome)
{
    public override void Receber(Mensagem mensagem)
    {
        if (mensagem.Tipo == MensagemTipo.Publica)
            return;
        
        Console.WriteLine(mensagem.Texto);
    }
}