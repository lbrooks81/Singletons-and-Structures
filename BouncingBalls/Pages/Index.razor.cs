using BouncingBalls.Client;
using BouncingBalls.Lab12TODO;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Numerics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BouncingBalls.Pages
{
    public partial class Index : ComponentBase
    {
        private List<Ball> balls = [];
        private readonly Renderer renderer = Renderer.GetInstance();
        private readonly TimerWrapper boundaryBoxGrowth = new TimerWrapper(8000);
        private int timesBBChanged = 0;

        //Physics calls per second. Increasing this could make movement smoother.
        private readonly float callsPerSecond = 30f;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CreateStockBalls();

            Timer timer = new Timer(1000/callsPerSecond);
            timer.Elapsed += OnTimedEvent!;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            StateHasChanged();

            boundaryBoxGrowth.Elapsed += OnBoundaryBoxGrowthTimedEvent!;
            boundaryBoxGrowth.AutoReset = true;
            boundaryBoxGrowth.Enabled = true;
            boundaryBoxGrowth.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            balls = renderer.PerformBallPhysics(balls);
            StateHasChanged();
        }

        private void OnBoundaryBoxGrowthTimedEvent(Object source, ElapsedEventArgs e)
        {
            timesBBChanged++;
            switch(timesBBChanged)
            {
                case 1:
                    renderer.ModifyBoundingBox(10, 10, 300, 400);
                    CreateStockBalls();
                    break;
                case 2:
                    renderer.ModifyBoundingBox(10, 10, 500, 400);
                    CreateStockBalls();
                    break;
                case 3:
                    renderer.ModifyBoundingBox(5, 5, 700, 700);
                    CreateStockBalls();
                    boundaryBoxGrowth.Stop();
                    break;
            }
            
            StateHasChanged();
        }

        private void CreateStockBalls()
        {
            for(int i = 0; i < 3; i++)
            {
                float size = Random.Shared.Next(12, renderer.BoundingBox.Width / 2) - Random.Shared.NextSingle();
                float px = Random.Shared.Next(1, renderer.BoundingBox.Width - (int)(size - 1));
                float py = Random.Shared.Next(1, renderer.BoundingBox.Height - (int)(size - 1));
                float vx = Random.Shared.Next(1, 21) - Random.Shared.NextSingle();
                float vy = Random.Shared.Next(1, 21) - Random.Shared.NextSingle();
                balls.Add(renderer.CreateBall(new Vector2(px, py), new Vector2(vx, vy), size, GenerateRandomColor()));
            }
        }

        //Static because it does not access any instance members.
        private static Color GenerateRandomColor()
        {
            return Random.Shared.Next(0, 24) switch
            {
                0 => Color.Aqua,
                1 => Color.Black,
                2 => Color.Blue,
                3 => Color.Fuchsia,
                4 => Color.Gray,
                5 => Color.Green,
                6 => Color.Lime,
                7 => Color.Maroon,
                8 => Color.Navy,
                9 => Color.Olive,
                10 => Color.Purple,
                11 => Color.Red,
                12 => Color.Silver,
                13 => Color.Teal,
                14 => Color.Yellow,
                15 => Color.Orange,
                16 => Color.Brown,
                17 => Color.Azure,
                18 => Color.Gold,
                19 => Color.Cyan,
                20 => Color.DarkRed,
                21 => Color.Gold,
                22 => Color.Pink,
                23 => Color.Wheat,
                _ => Color.Black,
            };
        }
    }
}
