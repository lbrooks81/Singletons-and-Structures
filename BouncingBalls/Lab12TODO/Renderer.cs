/*
* Name: [YOUR NAME HERE]
* South Hills Username: [YOUR SOUTH HILLS USERNAME HERE]
*/

using System.Drawing;
using System.Numerics;

namespace BouncingBalls.Lab12TODO;

// The Renderer is a singleton.
// Sealed classes cannot be inherited.
public sealed class Renderer
{
    // Rectangle is a struct.
    //                X    Y    width   height
    //Initial values: 10   10   200     200
    public Rectangle BoundingBox { get; private set; } = new Rectangle(10, 10, 200, 200);

    private Renderer() { } //Private constructor so it can't be constructed outside of this class

    public static Renderer GetInstance()
    {
        // TODO: Your code here
        throw new NotImplementedException();
    }

    public void ModifyBoundingBox(int x, int y, int width, int height)
    {
        // TODO: Your code here
        throw new NotImplementedException();
    }

    public Ball CreateBall(Vector2 pposition, Vector2 pvelocity, float psize, Color pcolor)
    {
        // TODO: Your code here
        throw new NotImplementedException();
    }

    public List<Ball> PerformBallPhysics(List<Ball> balls)
    {
        // TODO: Your code here
        // If a ball is outside of the X bounds, flip the X velocity.
        // If a ball is outside of the Y bounds, flip the Y velocity.
        // Ensure no ball is outside of the boundary.
        return balls;
    }

    private bool IsBallOutsideXBoundary(Ball ball)
    {
        //Right
        if (ball.Position.X + ball.Size > BoundingBox.Width) return true;
        //Left
        if (ball.Position.X + BoundingBox.X < BoundingBox.X) return true;
        return false;
    }

    private bool IsBallOutsideYBoundary(Ball ball)
    {
        //Bottom
        if (ball.Position.Y + ball.Size > BoundingBox.Height) return true;
        //Top
        if (ball.Position.Y + BoundingBox.Y < BoundingBox.Y) return true;
        return false;
    }
}
