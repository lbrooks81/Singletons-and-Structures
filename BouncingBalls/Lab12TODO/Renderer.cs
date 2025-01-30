/*
* Name: Logan Brooks
* South Hills Username:
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

    private static Renderer instance;
    private Renderer() { } //Private constructor so it can't be constructed outside of this class

    public static Renderer GetInstance()
    {
        // TODO: Your code here
        if (instance == null)
        {
            instance = new Renderer();
        }
        return instance;
    }

    public void ModifyBoundingBox(int x, int y, int width, int height)
    {
        BoundingBox = new Rectangle(x, y, width, height);   
    }

    public Ball CreateBall(Vector2 pposition, Vector2 pvelocity, float psize, Color pcolor)
    {
        return new Ball(pposition, pvelocity, psize, pcolor);
    }

    public List<Ball> PerformBallPhysics(List<Ball> balls)
    {
        // TODO: Your code here
        foreach (Ball ball in balls)
        {
            if (IsBallOutsideXBoundary(ball))
            {
                int index = balls.IndexOf(ball);
                balls.Remove(ball);
                Ball newBall = new Ball(ball.Position, new Vector2(-ball.Velocity.X, ball.Velocity.Y), ball.Size, ball.Color);
                balls.Insert(index, newBall);
            }
            if (IsBallOutsideYBoundary(ball))
            {
                int index = balls.IndexOf(ball);
                balls.Remove(ball);
                Ball newBall = new Ball(ball.Position, new Vector2(ball.Velocity.X, -ball.Velocity.Y), ball.Size, ball.Color);
                balls.Insert(index, newBall);
            }
            // If a ball is outside of the X bounds, flip the X velocity.
            // If a ball is outside of the Y bounds, flip the Y velocity.
            // Ensure no ball is outside of the boundary.
        }
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
