using System.ComponentModel;
using Radiance;

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
        
        lastTime = null;
        character?.SetState(new MovingState(
            Random.Shared.Next(Window.Width),
            Random.Shared.Next(Window.Height)
        ));
    }
}