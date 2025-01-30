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

    public Ball() { }
}
