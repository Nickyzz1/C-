using reading;
using menu;
using store;
namespace mainWindow;

public static class mainWin {

    public static void MainWindow(int c) {

        // teclas
        int keyStore = 108; // 1
        int keyClick = 55; // 7
        int keyClose = 57; // 9

        List<int> machines = new List<int>();

        Player player = new Player(c, machines);
        int old1 = player.Score;
        int old2 = player.Score;

        // Mostra o layout inicial
        Menu.Print();
        Console.WriteLine("Pressione 7 para clicar, 1 para abrir a loja, ou 9 para sair.");
        Console.WriteLine("Score: " + player.Score);

        // lendo a key que é pressionada   
        while (true){

            var key = ReadClicks.ReadKeyint();
            bool updated = false; 

            if(key != keyClick && key != keyStore && key != keyClose) {
                Console.WriteLine("Tecla inválida!");
            } else {
            
                if(player.Machine.Contains(1)){
                    if(old1 + 5 == player.Score) { old1 += 5; player.Score += 1; updated = true; }
                    Console.WriteLine("Clique duplo a cada 5 cliques.");
                }
                if(player.Machine.Contains(2)){
                    if(old2 + 10 == player.Score) { old1 += 10; player.Score += 4; updated = true; }
                    Console.WriteLine("Clique quíntuplo a cada 10 cliques.");
                }

                if(player.Machine.Contains(3)){
                    if(old2 + 10 == player.Score) { player.Score += 1; updated = true; }
                    Console.WriteLine("Clique duplo.");
                }
                player.Score += 1;
                updated = true;
            }

            // Abrindo a loja e verificando seu retorno
            if (key == keyStore) {
                player.Machine = Store.StoreMenu(player.Score, player.Machine);

                // Atualiza os atributos do player de acordo com as compras
                if (player.Machine.Count > 0) {
                    int lastMachine = player.Machine[player.Machine.Count - 1];
                    if (lastMachine == 1) player.Score -= 20;
                    else if (lastMachine == 2) player.Score -= 35;
                    else if (lastMachine == 3) player.Score -= 70;
                    updated = true;
                }
            }

            // Atualiza o score na tela, se necessário
            if (updated) {
                Console.SetCursorPosition(0, Console.CursorTop - 1); // Volta para a linha anterior
                Console.WriteLine("Score: " + player.Score + "       "); // Sobrescreve com o novo score
            }

            if(key == keyClose) {
                Console.WriteLine("\nJogo finalizado"); 
                return;
            }
        }
    }
}
