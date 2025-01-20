using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoFileRepository : IRepository<Aluno>
{
    public List<Aluno> All => DBFile<Aluno>.App.All;

    public void Add(Aluno obj)
    {
        List<Aluno> alunos = this.All;
        alunos.Add(obj);
        DBFile<Aluno>.App.Save(alunos);
    }
}