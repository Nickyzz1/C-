using System;
using DataBase;

public class IClass : DataBaseObject {
    public string Name { get; set; }
    public int Quant { get; set; }
    public string[] Students { get; set; }
    public int id { get; set; }

    protected override void LoadFrom(string[] data) {
        this.id = int.Parse(data[0]);
        this.Name = data[1];
        this.Quant = int.Parse(data[2]);

        // Decodificar a string de Students para uma lista
        this.Students = data[3]?.Split('|') ?? new string[0];
    }

    protected override string[] SaveTo() {
        // Salvar a lista de Students como uma string unificada, separada por '|'
        return new string[] {
            this.id.ToString(),
            this.Name,
            this.Quant.ToString(),
            string.Join("|", this.Students ?? new string[0])
        };
    }
}
