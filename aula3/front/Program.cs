// See https://aka.ms/new-console-template for more information
using Model;
using static System.Console;
using Model.Repository;
using DataBase;
using System.Collections.Generic;

// criando repositórios que vão acessar os mpetodos no IRepository
IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<IClass> classRepo = null;
IRepository<Disciplines> disciplineRepo = null;

// pegando os dados mock contidos
alunoRepo = new AlunoFakeRepository();
profRepo = new ProfessorFakeRepository();
classRepo = new ClassFakeRepository();
disciplineRepo = new DisciplinesFakeRepository();

// cria banco com os dados iniciais
DB<Aluno>.SetCustom("csvAlunoCustom");  
DB<Professor>.SetCustom("csvProfessorCustom");
DB<Disciplines>.SetCustom("csvDisciplinaCustom");
DB<IClass>.SetCustom("csvClassCustom");

DB<Aluno> csvAluno = DB<Aluno>.Custom;
DB<Disciplines> csvDisciplina = DB<Disciplines>.Custom;
DB<IClass> csvTurma = DB<IClass>.Custom;
DB<Professor> csvProfessor = DB<Professor>.Custom;

// Pegue os dados dos repositórios e salve no arquivo CSV
List<Aluno> alunosData = alunoRepo.All;
List<Disciplines> disciplinesData = disciplineRepo.All;
List<IClass> classData = classRepo.All;
List<Professor> professorData = profRepo.All;

// Se os arquivos estiverem vazios, inicialize-os com listas vazias
try
{
    // Operações de salvar no arquivo
    csvAluno.save(alunosData);
    csvDisciplina.save(disciplinesData);
    csvTurma.save(classData);
    csvProfessor.save(professorData);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao salvar dados: {ex.Message}");
}

csvAluno.save(alunosData); 
csvDisciplina.save(disciplinesData);
csvTurma.save(classData);
csvProfessor.save(professorData);



void SaveAluno(Aluno aluno)
{
    string filePath = "csvAlunoCustomAluno.csv";  // Certifique-se de adicionar a extensão ".csv" ao nome do arquivo

    // Verifique se o arquivo já existe
    bool fileExists = File.Exists(filePath);

    // Se o arquivo não existe, criamos um novo com cabeçalho
    using (StreamWriter sw = new StreamWriter(filePath, true))  // 'true' indica que vamos adicionar no arquivo
    {
        // Se o arquivo não existe, escreva o cabeçalho
        if (!fileExists)
        {
            sw.WriteLine("id,Nome,Idade");  // Cabeçalho, apenas no primeiro uso
        }

        // Escrever os dados do aluno no arquivo CSV
        sw.WriteLine($"{aluno.id},{aluno.Nome},{aluno.Idade}");
    }
}


while (true)
{
    try
    {
        WriteLine(@"                                             
        EEEEEEEEEEEEEEEEEEEEEETTTTTTTTTTTTTTTTTTTTTTT   SSSSSSSSSSSSSSS 
        E::::::::::::::::::::ET:::::::::::::::::::::T SS:::::::::::::::S
        E::::::::::::::::::::ET:::::::::::::::::::::TS:::::SSSSSS::::::S
        EE::::::EEEEEEEEE::::ET:::::TT:::::::TT:::::TS:::::S     SSSSSSS
        E:::::E       EEEEEETTTTTT  T:::::T  TTTTTTS:::::S            
        E:::::E                     T:::::T        S:::::S            
        E::::::EEEEEEEEEE           T:::::T         S::::SSSS         
        E:::::::::::::::E           T:::::T          SS::::::SSSSS    
        E:::::::::::::::E           T:::::T            SSS::::::::SS  
        E::::::EEEEEEEEEE           T:::::T               SSSSSS::::S 
        E:::::E                     T:::::T                    S:::::S
        E:::::E       EEEEEE        T:::::T                    S:::::S
        EE::::::EEEEEEEE:::::E      TT:::::::TT      SSSSSSS     S:::::S
        E::::::::::::::::::::E      T:::::::::T      S::::::SSSSSS:::::S
        E::::::::::::::::::::E      T:::::::::T      S:::::::::::::::SS 
        EEEEEEEEEEEEEEEEEEEEEE      TTTTTTTTTTT       SSSSSSSSSSSSSSS                                                           
        ");
        WriteLine("=========================================================================================================#");
        WriteLine("\n1 - cadastrar professor\n2 - cadastrar aluno\n3 - ver professores\n4 - ver alunos\n5 - Turmas\n6 - Disciplinas\n9 - sair\n--");

        int option = int.Parse(ReadLine());
        switch (option)
        {
            // ADIONANDO PROFESSOR ===================================================
            case 1:

                Clear();
                Professor p = new();
                WriteLine("Insira o nome do p:");
                p.Nome = ReadLine();
                WriteLine("Insira a formacao do p:");
                p.Formacao = ReadLine();
                profRepo.Add(p);
                break;

            // ADICIONANDO ALUNO ==================================================================

            case 2:
                Clear();
                Aluno aluno = new();
                WriteLine("Insira o nome do aluno:");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno:");
                aluno.Idade = int.Parse(ReadLine());

                // Adiciona o aluno ao repositório
                alunoRepo.Add(aluno);

                // Salva o aluno no arquivo CSV sem sobrescrever os dados existentes
                DB<Aluno>.Custom.save(alunosData);
                break;

            // VENDO PROFESSORES ==================================================================

            case 3:

                Clear();
                var profs = profRepo.All;
                foreach (var prof in profs)
                {
                    WriteLine($""" 
                        {prof.Formacao} - {prof.Nome}
                        ---------------------------------
                        """);
                }
                break;
            // VENDO ALUNOS ==================================================================

            case 4:

                Clear();
                var alunos = DB<Aluno>.Custom.All;
                // foreach (var student in alunos)
                // {
                //     WriteLine($"""
                //         {student.Nome} - {student.Idade}
                //         ---------------------------------
                //         """);
                // }
                break;

            // TURMAS ==================================================================
            case 5:
                Clear();
                WriteLine("\n1 - Cadastrar turma\n2 - Ver turmas\n3 - Atualizar turmas\n4 - Adicionar pessoas a uma turma\n0 - voltar\n--");
                int op = int.Parse(ReadLine());

                switch (op)
                {
                    // CRIANDO TURMA =============================================
                    case 1:

                        Clear();

                        IClass c = new();

                        WriteLine("Digite o nome da turma:\n--");
                        c.Name = ReadLine();
                        WriteLine("Digite a quantidade de alunos:\n--");
                        int quant = int.Parse(ReadLine());
                        c.Quant = quant;
                        classRepo.Add(c);
                        break;

                    // VER TURMA =============================================
                    case 2:

                        Clear();
                        var classes = classRepo.All;
                        
                        
                        foreach (var i in classes)
                        {
                            WriteLine($""" 
                            {i.Name} - {i.Quant}
                            ---------------------------------
                            """);

                            WriteLine($""" 
                            ALUNOS:
                            """);

                            if (i.Students != null && i.Students.Length > 0)
                            {
                                foreach (var studentName in i.Students)
                                {
                                    WriteLine($"- {studentName}");
                                }
                            }
                            else
                            {
                                WriteLine("Nenhum aluno foi adicionado a esta turma ainda.");
                            }
                        }
                        break;
                    // ATUALIZANDO TURMA =============================================
                    case 3:
                        WriteLine("ainda não existe : (");
                        break;
                    // ADICIONANDO ALUNOS A TURMA =============================================
                    case 4:

                        Clear();
                        var quantAllStudents = csvAluno.All.Count;
                        var allTurmas = classRepo.All;
                        var allAlunos = csvAluno.All;

                        WriteLine("Digite o nome da turma:\n--");
                        var turmaChoose = ReadLine();

                        // Procurar a turma selecionada
                        var turma = allTurmas.FirstOrDefault(t => t.Name.Equals(turmaChoose, StringComparison.OrdinalIgnoreCase));

                        if (turma != null)
                        {
                            WriteLine("Adicione alunos à turma\n\nALUNOS DISPONÍVEIS:\n");

                            // Exibir lista de alunos
                            foreach (var student in allAlunos)
                            {
                                WriteLine($"""
                                {student.Nome} - {student.Idade}
                                ---------------------------------
                                """);
                            }

                            // Inicializar a lista de alunos na turma
                            List<string> studentsClass = new List<string>();

                            // Adicionar alunos na turma
                            for (int i = 0; i < turma.Quant; i++)
                            {
                                WriteLine($"Digite o nome do aluno ou S para sair ({i + 1}/{turma.Quant}):\n--");
                                var newStudent = ReadLine();

                                if(newStudent == "S") // Se a pessoa escolher sair
                                    break;

                                var matchedStudent = allAlunos.FirstOrDefault(s => s.Nome.Equals(newStudent, StringComparison.OrdinalIgnoreCase));
                                if (matchedStudent != null)
                                {
                                    studentsClass.Add(newStudent);
                                    WriteLine($"Aluno {newStudent} adicionado com sucesso!");
                                }
                                else
                                {
                                    WriteLine($"Aluno {newStudent} não encontrado. Tente novamente.");
                                    i--; // Repetir a entrada para o mesmo índice
                                }
                            }

                            // Atualizar a turma com os alunos adicionados
                            turma.Students = studentsClass.ToArray();
                        }
                        else
                        {
                            WriteLine("Turma não encontrada!");
                        }

                        WriteLine("\nAlunos adicionados à turma com sucesso!");
                        break;
                    // VOLTAR =============================================
                    case 0:
                        break;
                }
                break;

            // DISCIPLINAS ==================================================================

            case 6:
                Clear();
                WriteLine("1 - Cadastrar disciplina\n2 - Ver disciplinas\n3 - Atualizar disciplinas\n0 - voltar\n--");
                int turmaOp = int.Parse(ReadLine()); 

                switch (turmaOp )
                {
                    // CRIANDO DISCIPLINA =============================================
                    case 1:
                        Clear();
                        Disciplines d = new();

                        WriteLine("Digite o nome da disciplina\n--");
                        d.Name = ReadLine();
                        WriteLine("Digite o nome do professor que mestra a disciplina\n--");
                        d.Teacher = ReadLine();

                        disciplineRepo.Add(d);
                        break;

                    // VENDO DISCIPLINAS =============================================
                    case 2:
                        Clear();
                        var disciplines = disciplineRepo.All;

                        foreach (var i in disciplines)
                        {
                            WriteLine($"{i.Name} - {i.Teacher}");
                        }
                        break;
                    // ATUALIZANDO DISCIPLINAS =============================================
                    case 3:
                        WriteLine("ainda não existe : (");
                        break;
                    // VOLTANDO AO MENO PRINCIPAL ==========================================
                    case 4:
                        break;
                    // OPÇÃO DESCONHECIDA =============================================
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }
                break;

            // // FAZENDO CSV ==================================================================
            // case 7: 

            //     break;

            // SAINDO DO WHILE ==================================================================
            case 9:
                return;
        }
    }
    catch (System.Exception)
    {
        WriteLine("erro na aplicação");
    }
}