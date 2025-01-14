using System;

namespace DataBase.Exceptions;

public class ConvertObjectExecption : Exception {
    public override string Message => "Não foi possível converter";
}