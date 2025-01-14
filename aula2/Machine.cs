namespace machine;
public class Machine {

    // A cada 5 clicks faz um clique triplo
    public static int Machine1(int count) {
        return count += 2;
    }
    // A cada 10 clicks adiciona mais 5 clicks
     public static int Machine2(int count) {
        return count += 5;
    }
     // Faz cada clique seu valer 2 clicks
     public static int Machine3(int count) {
        return count += 1;
    }
}