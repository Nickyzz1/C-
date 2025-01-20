// using System.Collections.Generic;
// using DataBase;

// namespace Model.Repository;

// public class ProfessorFileRepository : IRepository<Professor>
// {
//     public List<Professor> All => DBFile<Professor>.App.All;

//     public void Add(Professor obj)
//     {
//         List<Professor> professores = this.All;
//         professores.Add(obj);
//         DBFile<Professor>.App.Save(professores);

//     }
// }