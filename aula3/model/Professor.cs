using DataBase;
namespace Model;

public class Professor : DataBaseObject
{
    public string Nome { get; set; }

    public string Formacao { get; set; }

    public int id { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.id = int.Parse(data[0]);
        this.Nome = data[1];
        this.Formacao = data[2];
    }

    protected override string[] SaveTo() => [ this.id.ToString(), this.Nome, this.Formacao];  
    
}