public abstract class State
{
    protected Character? character;

    public abstract void Act();

    public void SetContext(Character character)
        => this.character = character;
}