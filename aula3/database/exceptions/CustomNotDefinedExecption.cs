using System;

namespace DataBase.Exceptions;

public class CustomNotDefinedExecption: Exception {
    public override string Message => "o arquivo custom não foi definido";
}