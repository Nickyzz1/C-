using Radiance;
using static Radiance.Utils;

Character puca = new Character(red);
Character garu = new Character(blue);

puca.SetState(new WaitingState());
garu.SetState(new WaitingState());

Window.OnFrame += () =>
{
    puca.Act();
    garu.Act();

    puca.char2 = garu;
    garu.char2 = puca;

    //

    // float tolerance = 5;
    // if (Math.Abs(puca.X - garu.X) <= tolerance && Math.Abs(puca.Y - garu.Y) <= tolerance)
    // {
    //     bool founded = false;

    //     while(!founded) {
    //         garu.SetState(new MovingState((int)puca.X, (int) puca.Y));

    //         if (Math.Abs(puca.X - garu.X) <= tolerance && Math.Abs(puca.Y - garu.Y) <= tolerance) {
    //             founded = true;
    //         }
    //     }
    // }
};

Window.OnRender += () =>
{
    puca.Draw();
    garu.Draw();
};
Window.CloseOn(Input.Escape);
Window.Open();

