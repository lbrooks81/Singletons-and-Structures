using System.Drawing;
using System.Numerics;

namespace BouncingBalls.Lab12TODO;

// You can change anything except for the property names
//  and their get access modifiers. Remember to use proper
//  OOP encapsulation methodologies.
public struct Ball
{
    public Vector2 Position { get; private set; } = Vector2.Zero;
    public Vector2 Velocity { get; private set; } = Vector2.Zero;
    public float Size { get; init; } = 0f;
    public Color Color { get; init; } = Color.Empty;
    public Ball updatePosition()
    {
        Vector2 newPosition = new Vector2((Position.X + Velocity.X), (Position.Y + Velocity.Y));
        return new Ball(newPosition, Velocity, Size, Color);
    }
    public Ball(Vector2 position, Vector2 velocity, float size, Color color) 
    {
        Position = position;
        Velocity = velocity;
        Size = size;
        Color = color;
    }
}
