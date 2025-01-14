using System.Collections.Generic;

namespace Model;


public class AlunoFakeRepository : IRepository<Aluno> {

    List<Aluno> alunos = [];

    public AlunoFakeRepository() {
        alunos.Add(new() {
            Nome = "nicolle",
            Idade = 18
        });
    }

    public List<Aluno> All => alunos;

    void IRepository<Aluno>.Add(Aluno obj) => this.alunos.Add(obj);
}