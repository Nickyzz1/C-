var box = new Caixa("caixa do don", 8);
box.Valor = 30;

box.OnValueChanged += valor => Console.WriteLine(valor);

box.Valor++;

public class Caixa(string nome, int valor)
{
    public event Action<int> OnValueChanged;    
    

    public string Nome { get; set; } = nome;

    private int valor = valor;
    public int Valor
    {
        get => valor;
        set
        {
            valor = value;
            if (OnValueChanged == null)
                return;
            
            OnValueChanged(valor);
        }
    }
}

public class MyException(int code) : Exception
{
    public int Code => code;
    public override string Message => "Deu uns erro ai fi";
}


public record Aluno(string Nome, int Idade);

public class Pessoa(string nome)
{
    // Métodos (Method)
    public void Falar() { }

    // Campos (Field)
    private readonly string nome = nome;

    // Propriedades (Properties)
    public string Nome => nome;

    public required int Idade { get; init; }

    // Outras classes (records, enums, ...)
    // Construtores
    // Destrutores
    // Sobrecargas de Operadores
    // Eventos
}

// try
// {
//     throw new MyException(500);
// }
// catch (MyException ex) when (ex.Code == 500)
// {
//     throw;
//     throw ex;
// }
// catch (Exception ex)
// {

// }
// finally
// {

// }