// Classe principal que representa um "Personagem" no jogo.
public class Character
{
    // Propriedades X e Y para armazenar a posição do personagem.
    public int X { get; set; }
    public int Y { get; set; }

    // Variável que armazena o estado atual do personagem (ex.: andando, parado).
    IState? state = null;

    // Método para definir o estado atual do personagem.
    public void SetState(IState state)
    {
        this.state = state;             // Atualiza o estado para o novo estado passado como parâmetro.
        this.state.SetContext(this);   // Passa o "contexto" (o personagem atual) para o estado, para que ele possa interagir com ele.
        // Nesse caso o contexto é a posição dele
    }
    
    // Método que executa a ação correspondente ao estado atual do personagem.
    public void Act()
        => this.state?.Act(); // Chama o método "Act" do estado atual, caso exista., ou seja se a o estoo atual está na posição 10 e 12 ele vai partir desses números
}

// Interface que define o comportamento dos estados (contrato para os estados).
public interface IState
{
    void Act(); // Método para realizar a ação específica do estado.
    void SetContext(Character character); // Define o contexto (o personagem) que o estado controla.
}

// Classe que representa o estado de "Movendo-se" do personagem.
public class MovingState(int x, int y) : IState
{
    // Coordenadas finais para onde o personagem deve se mover.
    private readonly int x; // Destino no eixo X.
    private readonly int y; // Destino no eixo Y.

    // Método que define o que acontece quando o personagem age nesse estado.
    public void Act()
    {
        if (character is null) // Verifica se o contexto (personagem) foi definido.
            return;
        
        // Move o personagem em direção ao destino no eixo X, em passos de 5.
        if (character.X < x)
            character.X += 5;
        
        // Move o personagem em direção ao destino no eixo Y, em passos de 5.
        if (character.Y < y)
            character.Y += 5;
        
        // Se o personagem chegar ao destino, muda o estado para "Parado" (IdleState).
        if (character.X == x && character.Y == y)
            character.SetState(new IdleState());
    }

    // Armazena o contexto (o personagem que está se movendo).
    Character? character;

    // Método para definir o contexto (personagem atual) que o estado controla.
    public void SetContext(Character character)
        => this.character = character;
}

// Classe que representa o estado de "Parado" do personagem.
public class IdleState : IState
{
    // No estado "Parado", a ação não faz nada.
    public void Act() { }

    // Define o contexto (o personagem), mas nesse caso não é usado.
    public void SetContext(Character character) { } // só está aqui pe está na interface
}
