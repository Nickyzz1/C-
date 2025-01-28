using System.Xml.Serialization;
using Radiance;
using Radiance.Bufferings;
using static Radiance.Utils;

public class Character(vec4 myColor)
{
    public Character? char2{get;set;}

    public vec4 persnColor = myColor;

    dynamic charRender = render((vec2 dx) =>
    {
        zoom(40);
        move(dx); // vetor de coordenadas
        color = myColor;
        fill();

    });

    Polygon polygon = Polygons.Circle;
    public void Draw()
    {
        charRender(polygon, X, Y);
    }

    public float X { get; set; }
    public float Y { get; set; }

    State? state = null;
    public void SetState(State state)
    {
        this.state = state;
        this.state.SetContext(this);
    }
    
    public void Act()
        => state?.Act();
}

