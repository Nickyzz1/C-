using System.Collections.Generic;
using DataBase;

namespace Model;

public class Class : DataBaseObject
{
    public string id { get; set; }
    public string ClassName { get; set; }
    public string idProfessor { get; set; }
    public Professor professor { get; set; }
    public List<Aluno> alunos { get; set; }

    public Class() 
    {
        id = GetNewId;
        alunos = [];
    }

    protected override void LoadFrom(string[] data)
    {
        id = data[0];
        ClassName = data[1];
        idProfessor = data[2];
    }

    protected override string[] SaveTo()
    {
        return [
            id, ClassName, idProfessor
        ];
    }
}