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
