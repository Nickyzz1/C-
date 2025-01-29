public class Button {
    public IAction? ClickAction {get;set;}
    public void Click() {
        ClickAction?.Execute();
    }
}

public interface IAction {
    public void Execute();
}

public class myActionA() : IAction
{
    public void Execute()
    {
        System.Console.WriteLine("Ação 1");
    }
}

public class myActionB() : IAction
{
    public void Execute()
    {
        System.Console.WriteLine("Ação 2");
    }
}


