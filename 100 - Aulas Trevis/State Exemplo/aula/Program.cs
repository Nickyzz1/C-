using Radiance;
using static Radiance.Utils;

Character puca = new Character(red);
Character garu = new Character(blue);

puca.charc2 = garu;
garu.charc2 = puca;

puca.SetState(new WaitingState());
garu.SetState(new WaitingState());

garu.X = 1000;
garu.Y = 500;

Window.OnFrame += () =>
{
    puca.Act();
    garu.Act();

};

Window.OnRender += () =>
{
    puca.Draw();
    garu.Draw();
};
Window.CloseOn(Input.Escape);
Window.Open();