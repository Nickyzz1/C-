using System.Collections.Generic;
using System.Threading.Tasks;
using DataBase;

namespace Model.Repository;

public class SalaFileRepository
    (IRepository<Professor> profRepo, IRepository<Aluno> alunoRepo) 
    : IRepository<Class>
{
    private IRepository<Professor> professorRepo = profRepo;
    private IRepository<Aluno> alunoRepo = alunoRepo;


    public List<Class> All 
    {
        get
        {
            var classes = DBFile<Class>.App.All;
            for(int i = 0; i < classes.Count; i++)
            {
                List<Aluno> alunos = alunoRepo.All;
                foreach (var aluno in alunos)
                    if(aluno.idSala == classes[i].id)
                        classes[i].alunos.Add(aluno);
                List<Professor> profs = professorRepo.All;                
                foreach (var prof in profs)
                    if(prof.id == classes[i].idProfessor)
                        classes[i].professor = prof;
            }

            return classes;
        }
    }

    public void Add(Class obj)
    {
        for(int i = 0; i < obj.alunos.Count; i++)
        {
            obj.alunos[i].idSala = obj.id;
            alunoRepo.Add(obj.alunos[i]);
        }
        var classes = this.All;
        classes.Add(obj);
        DBFile<Class>.App.Save(classes);
    }
}