using System.ComponentModel;
using OpenTK.Graphics.OpenGL;
using Radiance;
using static Radiance.Utils;

public class WaitingState : State
{
    DateTime? lastTime = null;

    public override void Act()
    {

        if (lastTime is null)
        {
            lastTime = DateTime.Now.AddSeconds(1);
            return;
        }

        if (DateTime.Now < lastTime)
            return;

        float tolerance = 5;

        // if(character != null && character.persnColor == blue)  
        
        if (Math.Abs(character?.char2?.X?? 0 - character?.X?? 0) <= tolerance && Math.Abs(character?.char2?.X?? - character?.X?? 0) <= tolerance) {
            character?.SetState(new MovingState(
            Random.Shared.Next(Window.Width),
            Random.Shared.Next(Window.Height)
        ));
        }

        lastTime = null;
        character?.SetState(new MovingState(
            Random.Shared.Next(Window.Width),
            Random.Shared.Next(Window.Height)
        ));
    }
}