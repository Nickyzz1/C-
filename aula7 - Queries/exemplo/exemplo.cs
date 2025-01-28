// using System.Linq;

// Pessoa[] pessoas = [
//     new Pessoa("Don", "210430"),
//     new Pessoa("Queila", "456"),
//     new Pessoa("Trevis", "123"),
//     new Pessoa("Fabio", "2"),
// ];
// Transferencia[] transferencia = [
//     new Transferencia("210430", 1000),
//     new Transferencia("210430", 800),
//     new Transferencia("123", 250),
//     new Transferencia("2", 1000),
//     new Transferencia("456", 800),
//     new Transferencia("123", 250),
//     new Transferencia("456", 3000)
// ];

// var query = pessoas
//     .Where(p => p.Cpf.Length < 4)
//     .Select(p => p.Nome);

// var quer2 = 
//     from p in pessoas
//     join t in transferencia
//     on p.Cpf equals t.Cpf
//     select new { p.Nome, t.Valor } into r
//     group r by r.Nome into g
//     let sum = g.Sum(x => x.Valor)
//     where sum > 5000
//     select new { Nome = g.Key, Valor = sum };


// // var pagamentoDados = pessoas
// //     .Join(transferencia, p => p.Cpf, p => p.Cpf,
// //     (pessoa, pagamento) => new { pessoa.Nome, pagamento.Valor });

// public record Pessoa(string Nome, string Cpf);
// public record Transferencia(string Cpf, decimal Valor);
// public record Resultado(string Nome, decimal ValorTotal);

// public static class Enumerator
// {
//     public static IEnumerable<R> Join<T, U, K, R>(
//         this IEnumerable<T> source, IEnumerable<U> other,
//         Func<T, K> keyA, Func<U, K> keyB,
//         Func<T, U, R> map
//         )
//     {
//         throw new NotImplementedException();
//     }
// }

// // public interface IEnumberable<T>
// // {
// //     IEnumerator<T> GetEnumerator();
// // }

// // public interface IEnumerator<T>
// // {
// //     bool MoveNext();
// //     T Current { get; }
// // }