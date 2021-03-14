using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;
using System.Media;
using King_Pong;

namespace King_Pong
{
    class Program : GameWindow
    {
        bool InGame = false;

        // Set game speed here
        int Speed = 6;

        // Set "x, y" positions and speed of the ball and playes
        int xBallPos = 0;
        int yBallPos = 0;
        int BallSize = 10;
        
        int xBallSpeed = 0;
        int yBallSpeed = 0;

        int yPlayer1Pos = 0;
        int yPlayer2Pos = 0;

        // Set score
        int Player1Score = 0;
        int Player2Score = 0;

        int HitCounter = 0;
 
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            SoundPlayer BallHit = new SoundPlayer(functions.SoundLocal("BallHit.wav"));
            SoundPlayer GameLose = new SoundPlayer(functions.SoundLocal("Lose.wav"));
            SoundPlayer GameWin = new SoundPlayer(functions.SoundLocal("Win.wav"));

            Random ale = new Random();

            if (Player1Score > 9 || Player2Score > 9) Exit();

            if (yBallPos == 0 || InGame == false) yBallPos = ale.Next(-ClientSize.Height / 2, ClientSize.Height / 2); InGame = true ;
            
            // Set the direction that the ball will start going with 5px of speed
            if (xBallSpeed == 0)
            {
                xBallSpeed = functions.NegOrPos(Speed);
            }

            // Randomize the "y" direction at start
            if (yBallSpeed == 0)
            {
                yBallSpeed = functions.NegOrPos(Speed);
            }

            // Make objects move
            xBallPos += xBallSpeed;
            yBallPos += yBallSpeed;

            // Restarts the game with someone loses
            if (xBallPos - BallSize > ClientSize.Width / 2)
            {
                // cmd logger
                GameLose.Play();
                Console.WriteLine($"Hit counter:......{HitCounter}");
                Console.WriteLine($"BallSpeed:........{functions.Absolute(xBallSpeed)}px");
                Console.WriteLine($"Player1 score:....{Player1Score}");
                Console.WriteLine($"Player2 score:....{Player2Score}");
                Console.WriteLine("-------------------");

                xBallPos = 0; yBallPos = 0; BallSize = 10; xBallSpeed = 0;
                yBallSpeed = 0; yPlayer1Pos = 0; yPlayer2Pos = 0; HitCounter = 0;

                InGame = false;
                
                Player2Score++;
            }

            if (xBallPos + BallSize < -ClientSize.Width / 2)
            {
                // cmd logger
                GameWin.Play();
                Console.WriteLine($"Hit counter:......{HitCounter}");
                Console.WriteLine($"BallSpeed:........{-xBallSpeed}px");
                Console.WriteLine($"Player1 score:....{Player1Score}");
                Console.WriteLine($"Player2 score:....{Player2Score}");
                Console.WriteLine("-------------------");

                xBallPos = 0; yBallPos = 0; BallSize = 10; xBallSpeed = 0;
                yBallSpeed = 0; yPlayer1Pos = 0; yPlayer2Pos = 0; HitCounter = 0;

                InGame = true;
                
                Player1Score++;
            }

            // If ball touch top or bottom it will go to opposite "y" direction
            if ((yBallPos + BallSize / 2 > ClientSize.Height / 2) || (yBallPos - BallSize / 2 < -ClientSize.Height / 2))
            {
                yBallSpeed = -yBallSpeed;
            }

            // Controls of Player 1 (you)
            if (Keyboard.GetState().IsKeyDown(Key.Up) && !(yPlayer1Pos + 30 > ClientSize.Height / 2))
            {
                yPlayer1Pos += Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Down) && !(yPlayer1Pos - 30 < -ClientSize.Height / 2))
            {
                yPlayer1Pos -= Speed;
            }

            // Ball colision system
            if ((yBallPos - BallSize / 2 < yPlayer1Pos + 30) && (yBallPos + BallSize / 2 > yPlayer1Pos - 30) && (xBallPos + BallSize / 2 >= ClientSize.Width / 2 - 5))
            {
                BallHit.Play();
                xBallSpeed = -ale.Next(Speed, Speed + 10);
                
                HitCounter++;
            }

            if ((yBallPos - BallSize / 2 < yPlayer2Pos + 30) && (yBallPos + BallSize / 2 > yPlayer2Pos - 30) && (xBallPos - BallSize / 2 <= -ClientSize.Width / 2 + 5))
            {
                BallHit.Play();
                xBallSpeed = ale.Next(Speed, Speed + 10);

                HitCounter++;
            }

            // Speed limit
            if (xBallSpeed > 15) xBallSpeed = 15;
            if (xBallSpeed < -15) xBallSpeed = -15;

            // Player 2 IA
            if (yBallPos > yPlayer2Pos + 5)
            {
                yPlayer2Pos += Speed;
            } 

            else if (yBallPos < yPlayer2Pos - 5)
            {
                yPlayer2Pos -= Speed;
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

            Console.SetWindowSize(40, 40);

            functions.RightScoreBoard(Player1Score);
            functions.LeftScoreBoard(Player2Score);

            // Middle line
            functions.SetRetangle(0, ClientSize.Height / 2 - 30, 5, 30);
            functions.SetRetangle(0, ClientSize.Height / 2 - 75, 5, 30);
            functions.SetRetangle(0, ClientSize.Height / 2 - 120, 5, 30);
            functions.SetRetangle(0, ClientSize.Height / 2 - 165, 5, 30);
            functions.SetRetangle(0, ClientSize.Height / 2 - 210, 5, 30);
            functions.SetRetangle(0, -ClientSize.Height / 2 + 30 - 15, 5, 30);
            functions.SetRetangle(0, -ClientSize.Height / 2 + 75 - 15, 5, 30);
            functions.SetRetangle(0, -ClientSize.Height / 2 + 120 - 15, 5, 30);
            functions.SetRetangle(0, -ClientSize.Height / 2 + 165 - 15, 5, 30);
            functions.SetRetangle(0, -ClientSize.Height / 2 + 210 - 15, 5, 30);

            // Ball
            functions.SetRetangle(xBallPos, yBallPos, 10, 10, 1.0f, 1.0f, 0.0f);

            // Player 1
            functions.SetRetangle(ClientSize.Width / 2 - 5, yPlayer1Pos, 10, 60, 1.0f, 0.0f, 0.0f);

            // Player 2
            functions.SetRetangle(-ClientSize.Width / 2 + 5, yPlayer2Pos, 10, 60, 1.0f, 0.0f, 0.0f);

            SwapBuffers();
        }

        static void Main(string[] args)
        {
            new Program().Run();
            
            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
    }
}
