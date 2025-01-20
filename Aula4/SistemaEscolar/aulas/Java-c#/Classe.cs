using System.Collections.Generic;

public class Classe
{
    private Dictionary<string, object> _values = new();

    public object? this[string properties]
    {
        get => _values.ContainsKey(properties) ? _values[properties] : null;
        set => _values[properties] = value!;
    }

}