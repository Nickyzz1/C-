using System.Collections.Generic;
using DataBase;

namespace Model;

public class Professor : DataBaseObject
{
    public string id { get; private set; }
    public string Nome { get; set; }
    public string Formacao { get; set; }

    public Professor() => id = GetNewId;

    protected override void LoadFrom(string[] data)
    {
        this.id = data[0];
        this.Nome = data[1];
        this.Formacao = data[2];
    }

    protected override string[] SaveTo()
        => [
            this.id,
            this.Nome,
            this.Formacao
        ];

    public override string ToString()
        => $"""
            ID: {id}
            Nome: {Nome }
            Formação: {Formacao}
        """;
}