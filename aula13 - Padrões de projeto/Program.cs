// Strategy

Button b1 = new Button();
Button b2 = new Button();

b1.ClickAction = new myActionA();
b2.ClickAction = new myActionB();
b1.Click();
b2.Click();

// State

Character character = new Character();
character.SetState(new MovingState(100, 200)); // consegue colocar o new moving state como parametro pq o New Moveen=ing state implementa a interface IState de estado

while (true)
{
    Thread.Sleep(200);
    Console.WriteLine(character.X);
    Console.WriteLine(character.Y);
    character.Act();
}


