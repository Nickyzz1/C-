using AttackSpace;
using DefenseSpace;

// fazer um ararray com sempre 3
// guardar o valor de dados em algum lugar

Random rand = new Random();
int N = 20;

int pontAtt = 0;
int pontDef = 0;
int pontAttTotal = 0;

int DiceAtt;
int DiceDef;

monteCarlo();

int roll() => rand.Next(6) + 1;

List<int> turnDice(int quantSoldires, int defOrAtt) { // girar dados attack

    List<int> result = new();

    if(defOrAtt == 1)
    {
        if(quantSoldires > 3) { 
            result.Clear();
            for(int j = 0; j < 3; j++) {
                DiceAtt = roll();
                result.Add(DiceAtt); 
            }
            return result;

        } else if (quantSoldires == 3) { 
            result.Clear();
            for(int j = 0; j < 2; j++) {
                DiceAtt = roll();
                result.Add(DiceAtt);
            }
            return result;

        } else if(quantSoldires == 2) { 

            result.Clear();
            DiceAtt = roll();
            result.Add(DiceAtt);
  
            return result;
        }

        } else {

        if(quantSoldires > 3) { 

            result.Clear();
            for(int j = 0; j < 3; j++) {
            DiceDef = roll();
            result.Add(DiceDef); 
            }
            return result;

        } else if (quantSoldires == 3) {

            result.Clear();
            for(int j = 0; j < 2; j++) {
                DiceDef = roll();
                result.Add(DiceDef);
            }
            return result;

        } else if(quantSoldires == 2) { 

            result.Clear();
            DiceDef = roll();
            result.Add(DiceDef);
            return result;
        }
    }
    result.Clear();
    return result;
}

void monteCarlo() {

   for(int n = 0; n < N; n++) {

        Attack attack = new(1000, pontAtt); // valores iniciais
        Defense defense = new(500, pontDef);

        while(true) {

            List<int> resultAtt = turnDice(attack.NumberSoldier, 1); // ataque representado por 1
            List<int> resultDef = turnDice(defense.NumberSoldier, 0); // defesa representado por 0

            System.Console.WriteLine("\n============================= ");

            if(resultAtt.Count() > 0 &&  resultDef.Count() > 0)
            for(int j = 0; j < 3; j++) {
                if (resultAtt?[j] > resultDef?[j]) {
                    pontAtt++;
                    System.Console.WriteLine($"{j + 1} ° batalha! Ataque venceu! Com {attack.NumberSoldier} contra {defense.NumberSoldier}");
                    defense.NumberSoldier--;
                }
                else if (resultAtt[j] != null && resultDef[j] != null && resultAtt[j] <= resultDef[j])  { 
                    pontDef++;
                    System.Console.WriteLine($"{j + 1} ° batalha! Defesa venceu! Com {defense.NumberSoldier} contra {attack.NumberSoldier}");
                    attack.NumberSoldier--;
                }
            }
            if (pontAtt > pontDef) {
                pontAttTotal += pontAtt;
                System.Console.WriteLine("Ataque venceu a rodada!");
                pontAtt = 0;
                pontDef = 0;

            } else{
                System.Console.WriteLine("Defesa venceu a rodada!");
                pontDef = 0;
                pontAtt = 0;
            }
        } 
   }
}
System.Console.WriteLine($"========== A probabilidade de um ataque com 1000 vencer uma defesa com 500 é de aproximadamente : {(pontAttTotal/N)}% ================");

// simular 10k vezes
// ter um count para contar quantas veze so ataque ganhou
// lista com 1000 soladados e outra com 5000
// sempre 3 contra tres
// Monte carlo executa o evento aleatóroio n(mais da metade das vezes) vezes e tira a média
// retono bool e para cada verdadeiro vc vai somar um no count e depois dvidir poor 10 milhões
// compara com dado e ve qual é o maior
// pararlelização

