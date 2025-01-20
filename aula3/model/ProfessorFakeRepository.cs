using System.Collections.Generic;

namespace Model.Repository;

public class ProfessorFakeRepository : IRepository<Professor> {

    List<Professor> professores = [];

    public ProfessorFakeRepository() {
        professores.Add(new() {
            Nome = "Nini",
            Formacao = "matemática"
        });

        professores.Add(new() {
            Nome = "Akik",
            Formacao = "biologia"
        });
    }

    public List<Professor> All => professores;

    void IRepository<Professor>.Add(Professor obj) => this.professores.Add(obj);
}