using System;

namespace DataBase.Exceptions;

public class DataCannotBeOpenedExecption : Exception  {

    private string file;
    public DataCannotBeOpenedExecption(string file) => this.file = file;
    public override string Message => $"os dados nã puderam ser lidos/escritos no arquivo '{file}' "; // cifrão permite colocar var dentro do texto
}