using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Player(int score, List<int> machines) {

    public int Score {set;get;} = score;
    public List<int> Machine {set;get;} = machines;
    
}