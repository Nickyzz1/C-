using System.Runtime.CompilerServices;
using university;

var uni = new Universidade();

// ===========================================================

var queryDepartamentsDiscipline = 
from dep in uni.Departamentos
join discipline in uni.Disciplinas
on dep.Id equals discipline.DepartamentoId
select new {
    Disciplina = discipline.Nome,
    Departamento = dep.Nome,
};

var sortData = queryDepartamentsDiscipline.OrderBy(d => d.Departamento);
var countData = sortData.Count();

// ===========================================================

var alunosProfessores = uni.Alunos
    .Select(aluno => new // Para cada aluno, cria um novo objeto contendo informações do aluno e seus professores.
    {
        Aluno = aluno.Nome, // Nome do aluno.
        Idade = aluno.Idade, // Idade do aluno.
        Professores = aluno.Matriculas // Para cada matrícula do aluno...
            .Select(matriculaId => uni.Turmas // Busca a turma correspondente na lista de turmas.
                .FirstOrDefault(t => t.Id == matriculaId)?.ProfessorId) // Obtém o ID do professor da turma encontrada (ou null se não existir).
            .Select(professorId => uni.Professores.FirstOrDefault(p => p.Id == professorId)?.Nome) // Com o ID do professor, busca seu nome na lista de professores.
    });


// ===========================================================

var professoresAlunos = uni.Professores
    .Select(professor => new // para cada professor, cria um novo objeto contendo informações do professor e seus alunos
    {
        Professor = professor.Nome, 
        Salario = professor.Salario, 
        Alunos = uni.Alunos // para cada aluno
            .Where(aluno => aluno.Matriculas // fmiltra alunos que tenham alguma matrícula
                .Any(matriculaId => uni.Turmas // que corresponda a uma turma lecionada pelo professor atual. Any é tipo um if, ele verifica se algum elemebto atende a uma condição
                    .Any(turma => turma.Id == matriculaId && turma.ProfessorId == professor.Id)))
            .Select(aluno => aluno.Nome) // após filtrar os alunos, seleciona apenas os nomes deles.
    });

// ===========================================================


var top5Profss = uni.Professores
    .Select(professor => new // Para cada professor, cria um novo objeto contendo informações do professor e seus alunos.
    {
        Professor = professor.Nome, 
        Salario = professor.Salario, 
        Alunos = uni.Alunos // Para cada aluno
            .Where(aluno => aluno.Matriculas // Filtra alunos que tenham alguma matrícula
                .Any(matriculaId => uni.Turmas // que corresponda a uma turma lecionada pelo professor atual. 
                    .Any(turma => turma.Id == matriculaId && turma.ProfessorId == professor.Id)))
            .Select(aluno => aluno.Nome).Count()
            
    });

var top5 = top5Profss.OrderByDescending(aluno => aluno.Alunos).Take(5);

// ===========================================================

var query5 = 
    from p in uni.Professores
    join t in uni.Turmas
    on p.Id equals t.ProfessorId
    join a in uni.Alunos
    on t.Id equals a.Matriculas.FirstOrDefault()
    group a by new { p.Nome, p.Salario, t.Id } into g
    select new {
        Alunos = g.Select(a => a.Nome).Distinct(),
        CustoPorAluno = 300 + (g.Key.Salario / g.Count())
    };

// ===========================================================

System.Console.WriteLine("\n===========================================================");
Console.WriteLine("Os departamentos, em ordem alfabética, com o número de disciplinas.");
System.Console.WriteLine($"Quantidade de disciplinas: {countData}\n");
foreach (var item in sortData)
{
    Console.WriteLine(item);
}

// ===========================================================


System.Console.WriteLine("\n===========================================================");
Console.WriteLine("Os departamentos, em ordem alfabética, com o número de disciplinas.");
System.Console.WriteLine($"Quantidade de disciplinas: {countData}\n");
foreach (var item in sortData)
{
    Console.WriteLine(item);
}
// ===========================================================

Console.WriteLine();

System.Console.WriteLine("\n===========================================================");
Console.WriteLine("Liste os alunos e suas idades com seus respectivos professores.");
Console.WriteLine();

foreach (var item in alunosProfessores)
{
    Console.WriteLine($"Aluno: {item.Aluno}, Idade: {item.Idade}");
    Console.WriteLine("Professores:");
    foreach (var professor in item.Professores.Where(p => p != null))
    {
        Console.WriteLine($"  - {professor}");
    }
    Console.WriteLine();
}

// ===========================================================

System.Console.WriteLine("\n===========================================================");
Console.WriteLine("Liste os professores e seus salários com seus respectivos alunos.");
Console.WriteLine();

foreach (var item in professoresAlunos)
{
    Console.WriteLine($"Professor: {item.Professor}, Salário: {item.Salario:C}");
    Console.WriteLine("Alunos:");
    foreach (var aluno in item.Alunos)
    {
        Console.WriteLine($"  - {aluno}");
    }
    Console.WriteLine();
}

// ===========================================================


System.Console.WriteLine("\n===========================================================");
Console.WriteLine("Top 5 Professores com mais alunos da universidade.\n");
foreach (var item in top5)
{
    Console.WriteLine($"Professor: {item.Professor}, Salário: {item.Salario:C}");
    Console.WriteLine($"Alunos:{item.Alunos} alunos");

}
Console.WriteLine();

// ===========================================================

System.Console.WriteLine("\n===========================================================");
Console.WriteLine(
    """
    Considerando que todo aluno custa 300 reais mais o salário dos seus professores
    divido entre seus colegas de classe. Liste os alunos e seus respectivos custos.
    """
);
System.Console.WriteLine();

foreach (var turma in query5)
{
    foreach (var aluno in turma.Alunos)
    {
        Console.WriteLine($"Aluno: {aluno} - Custo: {turma.CustoPorAluno:C}");
    }
}

Console.WriteLine();

// ===========================================================

var query6 =
    from a in uni.Alunos
    select new { 
        Nome = a.Nome, 
        Idade = a.Idade,
        QuantidadeDisciplinas = a.Matriculas.Count()
        } into r
    group r by r.Nome into g
    orderby g.Key
    select g;

// ===========================================================

var query7 = 
    from p in uni.Professores
    join t in uni.Turmas
    on p.Id equals t.ProfessorId
    join dis in uni.Disciplinas
    on t.DisciplinaId equals dis.Id
    join dep in uni.Departamentos
    on dis.DepartamentoId equals dep.Id
    select new {
        Nome = p.Nome,
        Idade = p.Idade,
        Salario = p.Salario,
        Departamento = dep.Nome,
    };

query7 = query7.Where(s => s.Salario > 12_000 && s.Salario < 15_000);

// ===========================================================
// Turmas com Professores Específicos. Identifique todas as turmas onde professores do departamento de DAINF estão lecionando. Mostre o ID da turma, a disciplina e o professor.

var query8 = 
    from p in uni.Professores
    join t in uni.Turmas
    on p.Id equals t.ProfessorId
    join dis in uni.Disciplinas
    on t.DisciplinaId equals dis.Id
    join dep in uni.Departamentos
    on dis.DepartamentoId equals dep.Id
    select new {
        Nome = p.Nome,
        Disciplina = dis.Nome,
        Turma = t.Id,
        Departamento = dep.Nome
    };

query8 = query8.Where(d => d.Departamento == "DAINF");

// ===========================================================

// Professor Mais Jovem Encontre o professor mais jovem em cada departamento e exiba o nome, departamento e idade.

var query9 = 
    from p in uni.Professores
    join t in uni.Turmas
    on p.Id equals t.ProfessorId
    join dis in uni.Disciplinas
    on t.DisciplinaId equals dis.Id
    join dep in uni.Departamentos
    on dis.DepartamentoId equals dep.Id
    group new {p.Nome, p.Idade, Departamento = dep.Nome} by dep.Nome into g
    select new {
        Departamento = g.Key,
        ProfessorNovo = g.OrderBy(p => p.Idade).First()
    };

// ===========================================================
//  Identifique todas as disciplinas que possuem mais de uma turma associada. Mostre o nome da disciplina e a quantidade de turmas.

var query10 = 
    from t in uni.Turmas
    join d in uni.Disciplinas
    on t.DisciplinaId equals d.Id
    group t by new {d.Id, d.Nome } into g
    where g.Count() > 1
    select new {
        Disciplina = g.Key.Nome,
        QuantidadeDeTurmas = g.Count()
    };

// ===========================================================


System.Console.WriteLine
("\n===========================================================");
Console.WriteLine("Alunos em Mais de Três Disciplinas. Liste os nomes dos alunos matriculados em mais de três disciplinas, mostrando o nome, idade e a quantidade de disciplinas.");
System.Console.WriteLine();

foreach (var aluno in query6) {

    Console.WriteLine($"Aluno: {aluno.Key} ");

    foreach(var item in aluno) {
        Console.WriteLine($"Idade: {item.Idade} - Disciplinas: {item.QuantidadeDisciplinas}");
    }
}
// ===========================================================

System.Console.WriteLine
("\n===========================================================");
Console.WriteLine("Professores por Faixa Salarial. Liste os professores cuja faixa salarial está entre R$12.000 e R$15.000, mostrando o nome, idade, departamento e salário.");
System.Console.WriteLine();

foreach (var professor in query7) {

    Console.WriteLine($"Professor: {professor.Nome} - Idade: {professor.Idade} - Salario: {professor.Salario} - Departamento: {professor.Departamento}");
}
// ===========================================================

System.Console.WriteLine
("\n===========================================================");
Console.WriteLine("Turmas com Professores Específicos. Identifique todas as turmas onde professores do departamento de DAINF estão lecionando. Mostre o ID da turma, a disciplina e o professor.");
System.Console.WriteLine();

foreach (var professor in query8) {

    Console.WriteLine($"Professor: {professor.Nome} - Turma: {professor.Turma} - Disciplina: {professor.Disciplina} - Departamento: {professor.Departamento}");
}

// ===========================================================

System.Console.WriteLine
("\n===========================================================");
Console.WriteLine("Professor Mais Jovem. Encontre o professor mais jovem em cada departamento e exiba o nome, departamento e idade.");
System.Console.WriteLine();

foreach (var result in query9)
{
    Console.WriteLine($"Departamento: {result.Departamento}, Nome: {result.ProfessorNovo.Nome}, Idade: {result.ProfessorNovo.Idade}");
}

// ===========================================================

System.Console.WriteLine
("\n===========================================================");
Console.WriteLine("Disciplinas com Turmas Repetidas. Identifique todas as disciplinas que possuem mais de uma turma associada. Mostre o nome da disciplina e a quantidade de turmas.");
System.Console.WriteLine();

foreach (var result in query10)
{
    Console.WriteLine($"Disciplina: {result.Disciplina}, Quantidade de Turmas: {result.QuantidadeDeTurmas}");
}

// ===========================================================

Console.ReadKey(true);

public record Professor(
    int Id,
    string Nome,
    int Idade,
    int DepartamentoId,
    decimal Salario
);

public record Departamento(
    int Id, 
    string Nome
);

public record Disciplina(
    int Id,
    string Nome,
    int DepartamentoId
);

public record Turma(
    int Id,
    int DisciplinaId,
    int ProfessorId,
    string Codigo
);

public record Aluno(
    int Id,
    string Nome,
    int Idade,
    List<int> Matriculas
);
