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

        System.Console.WriteLine($"mod {mod}");

        if(mod > 1 && mod <= 200) {

            if(character.personColor == (0, 0, 1, 1)) {
                character.SetState(new HutingState(character, character.charc2));
                character.charc2.SetState(new RuningState(character, character.charc2));
            }

        }

        // if (character.X == character.charc2.X && character.Y == character.charc2.Y ) {

        //     Window.Close();
        //     return;
        // }

        if(mod <= 1) {
            Window.Close();
            return;
        }


        character.X += 200 * Window.DeltaTime * dx;
        character.Y += 200 * Window.DeltaTime * dy;
    }
}