using DataBase;
namespace Model;
public class Disciplines : DataBaseObject {
    public string Name{ get; set; }
    public string Teacher{ get; set; }
    public int id { get; set; }

    protected override void LoadFrom(string[] data) {
        this.id = int.Parse(data[0]);
        this.Name = data[1];
        this.Teacher = data[2];
    }

    protected override string[] SaveTo() { // retorna uma lista do que já temos
        return new string[] { this.id.ToString(), this.Name, this.Teacher };
    }

}