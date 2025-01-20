using System.Collections.Generic;
namespace Model.Repository;

public class DisciplinesFakeRepository : IRepository<Disciplines> { // implementando a interface
    List<Disciplines> disciplines = [];

    public DisciplinesFakeRepository() { // adicionando objeto estático incial no banco
        disciplines.Add(new() { 
        Name = "intro C#",
        Teacher = "Nicolas"
    });
    }

    public List<Disciplines> All => disciplines;
    void IRepository<Disciplines>.Add(Disciplines Obj) => this.disciplines.Add(Obj);
    
}