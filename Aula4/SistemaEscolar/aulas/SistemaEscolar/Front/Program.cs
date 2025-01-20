using static System.Console;
using Model;
using Model.Repository;
using System;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<Class> classRepo = null;


// #if DEBUG

// alunoRepo = new AlunoFakeRepository();
// profRepo = new ProfessorFakeRepository();

// #else

alunoRepo = new AlunoFileRepository();
profRepo = new ProfessorFileRepository();
classRepo = new SalaFileRepository(profRepo, alunoRepo);

// #endif

while (true)
{
    try
    {
        Clear();
        WriteLine("""
            1 - Cadastrar Turma
            2 - Cadastrar Professor
            3 - Ver Professores
            4 - Ver Alunos
            5 - Ver Turmas
            6 - Sair
        """);

        int option = int.Parse(ReadLine());
        Professor p = new();

        switch (option)
        {
            case 1:
                Clear();
                Class novaTurma = new();
                WriteLine("Insira o nome da turma: ");
                novaTurma.ClassName = ReadLine();
                WriteLine("Insira o codigo do professor: ");
                novaTurma.idProfessor = ReadLine();
                bool addStudent = true;
                int studentCount = 0;
                while(addStudent)
                {  
                    Clear();
                    Aluno aluno = new();
                    WriteLine("Inserir estudante");
                    WriteLine($"Insira o nome do {studentCount +1}º estudante:");
                    aluno.Nome = ReadLine();
                    WriteLine($"Insira a idade do {studentCount +1}º estudante:");
                    aluno.Idade = int.Parse(ReadLine());
                    novaTurma.alunos.Add(aluno);
                    Clear();
                    WriteLine("Deseja adicionar outro estudante? (S/n)");
                    string chose = ReadLine().ToLower();
                    switch (chose)
                    {
                        case "s":
                            continue;
                                            
                        case "n":
                            addStudent = false;
                            break;

                        default:
                            Clear();
                            WriteLine("Deseja adicionar outro estudante? (S/n)");
                            chose = ReadLine();
                            break;
                    }
                }
                classRepo.Add(novaTurma);
                break;
            case 2:
                Clear();
                Professor prof = new();
                WriteLine("Insira o nome do professor: ");
                prof.Nome = ReadLine();
                
                WriteLine("Insira a formação do professor: ");
                prof.Formacao = ReadLine();
                profRepo.Add(prof);
                WriteLine(prof);
                break;
            case 3:
                var profs = profRepo.All;
                for(int i = 0; i < profs.Count; i++)
                {
                    WriteLine($"""
                        {profs[i].Formacao} - {profs[i].Nome}
                    ----------------------
                    """);
                }
                break;
            case 4:
                var alunos = alunoRepo.All;
                for(int i = 0; i < alunos.Count; i++)
                {
                    WriteLine($"""
                        {alunos[i].Nome} - {alunos[i].Idade}anos
                    ----------------------
                    """);
                }
                break;
            case 5:
                var turmas = classRepo.All;
                for(int i = 0; i < turmas.Count; i++)
                {
                    WriteLine($"-------------------------------------");
                    WriteLine($"Turma: {turmas[i].ClassName}");
                    WriteLine($"Professor: {turmas[i].professor.Nome}");
                    WriteLine("Alunos: ");
                    for (int j = 0; j < turmas[i].alunos.Count; j++)
                    {
                        var crrAluno = turmas[i].alunos[j];
                        WriteLine($"    {crrAluno.Nome}");
                    }
                    WriteLine($"-------------------------------------");
                }
                break;
            case 6:
                return;

            default:
                break;
        }
    }
    catch (Exception e)
    {
        WriteLine("Erro na aplicação, por favor consulte a TI.");
        WriteLine("Erro:");
        WriteLine(e);
    }

    WriteLine("Pressione qualquer tecla para continuar...");
    ReadKey(true);
}
