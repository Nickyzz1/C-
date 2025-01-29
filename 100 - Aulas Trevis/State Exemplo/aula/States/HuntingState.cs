using Radiance;

public class HutingState(Character garu, Character puca) : State
{
    public override void Act()
    {

        var dx = puca.X - garu.X;
        var dy = puca.Y - garu.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        garu.X += 200 * Window.DeltaTime * dx;
        garu.Y += 200 * Window.DeltaTime * dy;

       if(garu.Y < 0 || garu.X < 0 || garu.X >= Window.Width || garu.Y >= Window.Height) 
            garu.SetState(new MovingState(Random.Shared.Next(Window.Width),
            Random.Shared.Next(Window.Height)));

        
        if (garu.X == puca.X && garu.Y == puca.Y ) {
            Window.Close();
            return;
        }
    }
}