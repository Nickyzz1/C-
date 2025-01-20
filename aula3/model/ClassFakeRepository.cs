using System.Collections.Generic;
using Model;

namespace Model.Repository
{
    public class ClassFakeRepository : IRepository<IClass> 
    {
        List<IClass> classes = new List<IClass>(); // Inicializando corretamente a lista de turmas

        public ClassFakeRepository() 
        {
            // Adicionando turmas fictícias
            classes.Add(new IClass
            {
                Name = "Digital solutions",
                Quant = 17,
                Students = new string[] {} // Inicializando com um array vazio de alunos
            });

            classes.Add(new IClass
            {
                Name = "Cyber",
                Quant = 3,
                Students = new string[] { "João", "Maria", "Carlos" } // Alunos fictícios
            });
        }

        public List<IClass> All => classes; // Retorna todas as turmas

        // Método para adicionar uma turma
        void IRepository<IClass>.Add(IClass obj) => this.classes.Add(obj);
    }
}
