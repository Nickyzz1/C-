using DataBase;
namespace Model;

public class Aluno : DataBaseObject
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public int id { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.id = int.Parse(data[0]);
        this.Nome = data[1];
        this.Idade = int.Parse(data[2]);
    }

    protected override string[] SaveTo()
    {
        return new string[] {this.id.ToString(), this.Nome, this.Idade.ToString()};  
    }
}