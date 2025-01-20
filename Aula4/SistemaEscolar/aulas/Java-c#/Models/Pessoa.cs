using System.Collections.Generic;

namespace Models;

public class Pessoa
{
    public string? Name { get; set; }
    public List<string> docs { get; private set; } = new();

    public Pessoa(string name)
    {
        this.Name = name;
    }

    public string getName () => this.Name;
    private void setDocs(){}
}

