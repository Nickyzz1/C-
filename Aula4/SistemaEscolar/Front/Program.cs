// using static Model;
using Model;
using Model.Repository;

Aluno aluno = new();
aluno.Nome = "nini";
aluno.Idade = 18;
aluno.idSala = "a";

var aRepo = new AlunoDBRepository();
aRepo.Add(aluno);
var list = aRepo.All;
foreach (var item in list) {
    System.Console.WriteLine(item.Nome);
}
System.Console.WriteLine();

// IRepository<Aluno> alunoRepo = null;
// IRepository<Professor> profRepo = null;

// alunoRepo = new AlunoFakeRepository();
// profRepo = new ProfessorFakeRepository();


// while (true)
// {
//     try
//     {
//         Clear();
//         WriteLine("""
//             1 - Cadastrar Professor
//             2 - Cadastrar Aluno
//             3 - Ver Professores
//             4 - Ver Alunos
//             5 - Sair
//         """);

//         int option = int.Parse(ReadLine());

//         switch (option)
//         {
//             case 1:
//                 Clear();
//                 Professor professor = new();
//                 WriteLine("Insira o nome do professor: ");
//                 professor.Nome = ReadLine();
//                 WriteLine("Insira a formação: ");
//                 professor.Formacao = ReadLine();
//                 profRepo.Add(professor);
//                 break;
//             case 2:
//                 Clear();
//                 Aluno aluno = new();
//                 WriteLine("Insira o nome do aluno: ");
//                 aluno.Nome = ReadLine();
//                 WriteLine("Insira a idade do aluno: ");
//                 aluno.Idade = int.Parse(ReadLine());
//                 alunoRepo.Add(aluno);
//                 break;
//             case 3:
//                 var profs = profRepo.All;
//                 foreach (var prof in profs)
//                 {
//                     WriteLine($"""
//                         {prof.Formacao} - {prof.Nome}
//                     ----------------------
//                     """);
//                 }
//                 break;
//             case 4:
//                 var alunos = alunoRepo.All;
//                 foreach (var al in alunos)
//                 {
//                     WriteLine($"""
//                         {al.Nome} - {al.Idade} anos
//                     ----------------------
//                     """);
//                 }
//                 break;
//             case 5:
//                 return;

//             default:
//                 break;
//         }
//     }
//     catch
//     {
//         WriteLine("Erro na aplicação, por favor consulte a TI.");
//     }

//     WriteLine("Pressione qualquer tecla para continuar...");
//     ReadKey(true);
// }
