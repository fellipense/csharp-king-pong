using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace King_Pong
{
    class Program : GameWindow
    {
        // Set "x, y" positions and speed of the ball and playes
        int xBallPos = 0;
        int yBallPos = 0;
        int BallSize = 10;
        
        int xBallSpeed = 0;
        int yBallSpeed = 0;

        int yPlayer1Pos = 0;
        int yPlayer2Pos = 0;
 
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Set value positive or negative randomlly
            int NegOrPos(int val)
            {
                int[] a = { 1, -1 };
                return val * a[new Random().Next(0, 2)];
            }

            // Set the direction that the ball will start going with 5px of speed
            if (xBallSpeed == 0)
            {
                xBallSpeed = NegOrPos(5);
            }

            // Randomize the "y" direction at start
            if (yBallSpeed == 0)
            {
                yBallSpeed = NegOrPos(new Random().Next(-10, 10));
            }

            // Make objects move
            xBallPos += xBallSpeed;
            yBallPos += yBallSpeed;

            // Restarts the game with someone loses
            if ((xBallPos - BallSize > ClientSize.Width / 2) || (xBallPos + BallSize < -ClientSize.Width / 2))
            {
                xBallPos = 0;
                yBallPos = 0;
                BallSize = 10;

                xBallSpeed = 0;
                yBallSpeed = 0;

                yPlayer1Pos = 0;
                yPlayer2Pos = 0;
            }

            // If ball touch top or bottom it will go to opposite "y" direction
            if ((yBallPos + BallSize / 2 > ClientSize.Height / 2) || (yBallPos - BallSize / 2 < -ClientSize.Height / 2))
            {
                yBallSpeed = -yBallSpeed;
            }

            // Controls of Player 1 (you)
            if (Keyboard.GetState().IsKeyDown(Key.Up) && !(yPlayer1Pos + 30 > ClientSize.Height / 2))
            {
                yPlayer1Pos += 8;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Down) && !(yPlayer1Pos - 30 < -ClientSize.Height / 2))
            {
                yPlayer1Pos -= 8;
            }

            // Ball colision system
            if ((yBallPos + BallSize / 2 < yPlayer1Pos + 30) && (yBallPos - BallSize / 2 > yPlayer1Pos - 30) && (xBallPos + BallSize / 2 >= ClientSize.Width / 2 - 5))
            {
                if (xBallSpeed > 0) xBallSpeed = -(xBallSpeed + 1);
                else if (xBallSpeed < 0) xBallSpeed = -(xBallSpeed - 1);
                yBallSpeed = NegOrPos(new Random().Next(-10, 10));
                // cmd "logger" system
                Console.WriteLine("-------------------");
                Console.WriteLine("Right");
                Console.WriteLine($"xBallSpeed: {xBallSpeed}");
                Console.WriteLine($"yBallSpeed: {yBallSpeed}");
            }

            if ((yBallPos + BallSize / 2 < yPlayer2Pos + 30) && (yBallPos - BallSize / 2 > yPlayer2Pos - 30) && (xBallPos - BallSize / 2 <= -ClientSize.Width / 2 + 5))
            {
                if (xBallSpeed > 0) xBallSpeed = -(xBallSpeed + 1);
                else if (xBallSpeed < 0) xBallSpeed = -(xBallSpeed - 1);
                yBallSpeed = NegOrPos(new Random().Next(-10, 10));
                // cmd "logger" system
                Console.WriteLine("-------------------");
                Console.WriteLine("Left");
                Console.WriteLine($"xBallSpeed: {xBallSpeed}");
                Console.WriteLine($"yBallSpeed: {yBallSpeed}");
            }

            // Speed limit
            if (xBallSpeed > 15) xBallSpeed = 15;
            if (xBallSpeed < -15) xBallSpeed = -15;

            // Player 2 IA
            if (yBallPos > yPlayer2Pos + 10)
            {
                yPlayer2Pos += 8;
            } 

            else if (yBallPos < yPlayer2Pos - 10)
            {
                yPlayer2Pos -= 8;
            }

        }

        // Objects been placed on screen (I don´t know as weel what's happening)
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Ball
            SetRetangle(xBallPos, yBallPos, 10, 10);

            // Player 1
            SetRetangle(ClientSize.Width / 2 - 5, yPlayer1Pos, 10, 60);

            // Player 2
            SetRetangle(-ClientSize.Width / 2 + 5, yPlayer2Pos, 10, 60);

            SwapBuffers();
        }

        // Function to easely make a square/retangle
        void SetRetangle(int x, int y, int w, int h)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * w + x, -0.5f * h + y);
            GL.Vertex2(0.5f * w + x, -0.5f * h + y);
            GL.Vertex2(0.5f * w + x, 0.5f * h + y);
            GL.Vertex2(-0.5f * w + x, 0.5f * h + y);
            GL.End();
        }

        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
