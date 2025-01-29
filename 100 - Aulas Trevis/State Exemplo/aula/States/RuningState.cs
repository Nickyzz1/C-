using Radiance;

public class RuningState(Character garu, Character puca) : State
{
    public override void Act()
    {

        var dx = puca.X - garu.X;
        var dy = puca.Y - garu.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        puca.X += 300 * Window.DeltaTime * dx;
        puca.Y += 300 * Window.DeltaTime * dy;

        if(puca.Y < 0 || puca.X < 0 || puca.X >= Window.Width || puca.Y >= Window.Height) 
            puca.SetState(new MovingState(Random.Shared.Next(Window.Width),
            Random.Shared.Next(Window.Height)));
    }
}