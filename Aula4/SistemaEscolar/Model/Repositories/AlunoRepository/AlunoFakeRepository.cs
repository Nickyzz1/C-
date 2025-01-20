using System.Collections.Generic;

namespace Model.Repository;

public class AlunoFakeRepository : IRepository<Aluno>
{

    List<Aluno> alunos = [];
    public AlunoFakeRepository()
    {
        alunos.Add(new (){
            Nome = "Nycollas",
            Idade = 21
        });
        alunos.Add(new (){
            Nome = "Irineu",
            Idade = 20
        });
    }

    public List<Aluno> All => alunos;

    public void Add(Aluno obj)
        => this.alunos.Add(obj);
}