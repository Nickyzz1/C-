using Radiance;

public class MovingState(int x, int y) : State
{
    public override void Act()
    {
        if (character is null)
            return;
        
        var dx = x - character.X;
        var dy = y - character.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        if (mod < 5) {
            character.SetState(new WaitingState());
            return;
        }

        character.X += 200 * Window.DeltaTime * dx;
        character.Y += 200 * Window.DeltaTime * dy;
    }

}