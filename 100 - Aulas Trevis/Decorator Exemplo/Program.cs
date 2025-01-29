var bizarro = new MontadoNaAranha {
    MonstroNaAranha = new MontadoNaAranha {
        MonstroNaAranha = new MontadoNaAranha {
            MonstroNaAranha = new Zumbi()
        }
    }
};

bizarro.Grunir();
Console.WriteLine(bizarro.CalcularDano());
Console.WriteLine(bizarro.CalcularVelocidade());

public abstract class Monstro
{
    public abstract void Grunir();

    public abstract int CalcularDano();

    public abstract int CalcularVelocidade();
}

public class Zumbi : Monstro
{
    public override int CalcularDano()
        => 5;

    public override int CalcularVelocidade()
        => 4;

    public override void Grunir()
        => Console.WriteLine("bruhhhhhhh");
}

public class Esqueleto : Monstro
{
    public override int CalcularDano()
        => 15;

    public override int CalcularVelocidade()
        => 2;

    public override void Grunir()
        => Console.WriteLine("cleq cleq");
}

public class MontadoNaAranha : Monstro
{
    public Monstro? MonstroNaAranha { get; set; }

    public override int CalcularDano()
        => 10 + MonstroNaAranha?.CalcularDano() ?? 0;

    public override int CalcularVelocidade()
        => 20;

    public override void Grunir()
        => MonstroNaAranha?.Grunir();
}