using static FunctionUtils;

var f = x * x * x - 4 * x * x - 6 * x + 12;
Console.WriteLine(newtonRaphson(f, 4, 5));

double newtonRaphson(Function f, double x, int n)
{
    var df = f.Derive();
    for (int i = 0; i < n; i++)
        x -= f[x] / df[x];
    return x;
}

public abstract class Function
{
    public double this[double x] => Calcule(x);
    protected abstract double Calcule(double x);

    public abstract Function Derive();

    public static implicit operator Function(double value)
        => new ConstantFunction(value);
    
    public static Function operator +(Function f, Function g)
        => new SumFunction(f, g);
    
    public static Function operator *(Function f, Function g)
        => new ProductFunction(f, g);
    
    public static Function operator ^(Function f, Function g)
        => new PowerFunction(f, g);
    
    public static Function operator +(Function f)
        => f;
    
    public static Function operator -(Function g)
        => -1 * g;
    
    public static Function operator -(Function f, Function g)
        => f + -g;
    
    public static Function operator /(Function f, Function g)
        => f * (g^-1);
}

public static class FunctionUtils
{
    public readonly static Function x = new LinearFunction();

    public static Function cos(Function f)
        => new CosFunction(f);

    public static Function sin(Function f)
        => new SinFunction(f);

    public static Function ln(Function f)
        => new LnFunction(f);
}

// f(x) = x
public class LinearFunction : Function
{
    protected override double Calcule(double x) => x;
    public override Function Derive() => 1;
}

// f(x) = c
public class ConstantFunction(double value) : Function
{
    override protected double Calcule(double x) => value;
    public override Function Derive() => 0;
}

// f(x) + g(x)
public class SumFunction(Function f, Function g) : Function
{
    protected override double Calcule(double x) => f[x] + g[x];
    public override Function Derive() => f.Derive() + g.Derive();
}

// f(x) * g(x)
public class ProductFunction(Function f, Function g) : Function
{
    protected override double Calcule(double x) => f[x] * g[x];
    public override Function Derive() => f.Derive() * g + f * g.Derive();
}

// f(x)^g(x)
public class PowerFunction(Function f, Function g) : Function
{
    protected override double Calcule(double x) => Math.Pow(f[x], g[x]);
    public override Function Derive() => this * (g * ln(f)).Derive();
}

// f(x) = cos(g(x))
public class CosFunction(Function inner) : Function
{
    protected override double Calcule(double x)
        => Math.Cos(inner[x]);

    public override Function Derive()
        => sin(inner) * inner.Derive();
}

// f(x) = sin(g(x))
public class SinFunction(Function inner) : Function
{
    protected override double Calcule(double x)
        => Math.Sin(inner[x]);
    
    public override Function Derive()
        => -cos(inner) * inner.Derive();
}

// f(x) = log_e(g(x))
public class LnFunction(Function inner) : Function
{
    protected override double Calcule(double x)
        => Math.Log(inner[x]);
    
    public override Function Derive()
        => inner.Derive() / inner;
}