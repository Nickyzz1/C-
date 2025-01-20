namespace DataBase; // duas classes podem ter o mesmo namespace
public abstract class DataBaseObject { //classe abstrata
    internal protected abstract void LoadFrom(string[] data); // vai pegar da string e por na tabela
    internal protected abstract string[] SaveTo(); // vai pegar da tabela e por na string
}

// a cada tabela teremos um loadfrome um save to