using System.Collections.Generic;

namespace Model.Repository;


public class AlunoFakeRepository : IRepository<Aluno> {

    List<Aluno> alunos = [];

    public AlunoFakeRepository() {
        alunos.Add(new() {
            Nome = "Nini",
            Idade = 18
        });
           alunos.Add(new() {
            Nome = "Akik",
            Idade = 20
        });
    }

    public List<Aluno> All => alunos;

    void IRepository<Aluno>.Add(Aluno obj) => this.alunos.Add(obj);
}