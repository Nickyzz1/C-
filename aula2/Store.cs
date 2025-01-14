using mainWindow;
using reading;
namespace store;
public static class Store {
    public static List<int> StoreMenu (int score, List<int> machines) {

        int price1 = 20;
        int price2 = 35;
        int price3 = 50;

        int key1 = 49;
        int key2 = 50;
        int key3 = 51;
        int close = 57;

        Console.Clear();

        Console.WriteLine(@"
        .----------------.  .----------------.  .----------------.  .----------------. 
        | .--------------. || .--------------. || .--------------. || .--------------. |
        | |   _____      | || |     ____     | || |     _____    | || |      __      | |
        | |  |_   _|     | || |   .'    `.   | || |    |_   _|   | || |     /  \     | |
        | |    | |       | || |  /  .--.  \  | || |      | |     | || |    / /\ \    | |
        | |    | |   _   | || |  | |    | |  | || |   _  | |     | || |   / ____ \   | |
        | |   _| |__/ |  | || |  \  `--'  /  | || |  | |_' |     | || | _/ /    \ \_ | |
        | |  |________|  | || |   `.____.'   | || |  `.___.'     | || ||____|  |____|| |
        | |              | || |              | || |              | || |              | |
        | '--------------' || '--------------' || '--------------' || '--------------' |
        '----------------'  '----------------'  '----------------'  '----------------' 
        ");

       Console.WriteLine(" -- ### DIGITE O NÚMERO PARA COMPRAR OU PRESSIONE 9 PARA SAIR --\n");

        Console.WriteLine("1 - MÁQUINA 1, CORAÇÃO DE MÃE! ONDE CABE UM CABEM 2, NÃO É? TIPO CORAÇÃO DE MÃE!");
        Console.WriteLine("- PREÇO: 20 CLICKS");
        Console.WriteLine("- A CADA 5 CLIQUES FAZ UM CLIQUE DUPLO");
        Console.WriteLine(@"
                                             
        ___  ___  ___  ___  ___  ___  ___  ___  ___ 
        (___)(___)(___)(___)(___)(___)(___)(___)(___)
                                                    
        ");

        Console.WriteLine("2 - MÁQUINA 2, QUANTO MAIS MELHOR: INVESTIR É TUDO! ESSE INVESTIMENTO RETORNA 5 VEZES MAIS");
        Console.WriteLine("- PREÇO: 35 CLICKS");
        Console.WriteLine("- ADICIONA 5 CLIQUES A MAIS A CADA 10 CLIQUES");
        Console.WriteLine(@"
                                             
        ___  ___  ___  ___  ___  ___  ___  ___  ___ 
        (___)(___)(___)(___)(___)(___)(___)(___)(___)
                                                    
        ");

        Console.WriteLine("3 - MÁQUINA 3, O DOBRO, COMO UM DVD QUE VEM 2 EM 1!");
        Console.WriteLine("- PREÇO: 70 CLICKS");
        Console.WriteLine("- FAZ CADA CLIQUE SEU VALER 2 CLIQUES");
        Console.WriteLine(@"
                
        /(         /(         /(         /(         /(         /(         /(         /(         /(        
        ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,,  ) \/(.-,, 
        (      _  )(      _  )(      _  )(      _  )(      _  )(      _  )(      _  )(      _  )(      _  )
        `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \(  `._.-' \( 
            
        ");

        // validação das máquinas compradas
        var key = ReadClicks.ReadKeyint();
        if(key != 49 && key != 50 && key != 51 && key != close) {
            Console.WriteLine ("\nTecla inválida!\n");
        }
        if(key == key1) { 
            // A cada 5 clicks faz um clique DUPLO
            if(score > price1) {
                Console.WriteLine ("\nCompra bem sucedida! Agora você possui a máquina 1!");
                machines.Add(1);
             
                
            } else {
                Console.WriteLine ("\nSaldo insuficiente! Faça mais prontos para adquirir essa máquina!");
            }
        }
        if(key == key2) {
            // A cada 10 clicks adiciona mais 5 clicks
            if(score > price2) {
                Console.WriteLine ("\nCompra bem sucedida! Agora você possui a máquina 2!");
                machines.Add(2);
             
            } else {
                Console.WriteLine ("\nSaldo inbsuficiente! Faça mais prontos para adquirir essa máquina!");
            }
        }
        if(key == key3) {
            // Faz cada clique seu valer 2 clicks
            if(score > price3) {
                Console.WriteLine ("\ncompra bem sucedida! Agora você possui a máquina 3!");
                machines.Add(3);
            
            } else {
                Console.WriteLine ("\nSaldo insuficiente! Faça mais prontos para adquirir essa máquina!");
            }
        }
        if(key == close) {
           Console.WriteLine ("Saindo da loja...");
        }
        return machines;
    }
}