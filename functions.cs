using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;
using System.Media;

class functions
{
    // Acess the directory of the sound
    public static string SoundLocal(string nome)
    {
        string local = Directory.GetCurrentDirectory();
        local = $@"{local.Substring(0, local.IndexOf(@"\bin\Debug"))}\sounds\{nome}";
        return local;
    }

    // Set value positive or negative randomlly
    public static int NegOrPos(int val)
    {
        int[] a = { 1, -1 };
        return val * a[new Random().Next(0, 2)];
    }

    // Function to easely make a square/retangle
    public static void SetRetangle(int x, int y, int w, int h, float r = 9.9f, float g = 9.9f, float b = 9.9f)
    {
        if (!((r == 9.9f) || (g == 9.9f) || (b == 9.9f))) GL.Color3(r, g, b);
        else GL.Color3(0.470f, 0.470f, 0.470f);


        GL.Begin(PrimitiveType.Quads);
        GL.Vertex2(-0.5f * w + x, -0.5f * h + y);
        GL.Vertex2(0.5f * w + x, -0.5f * h + y);
        GL.Vertex2(0.5f * w + x, 0.5f * h + y);
        GL.Vertex2(-0.5f * w + x, 0.5f * h + y);
        GL.End();
    }

    // Forces number be positive
    public static int Absolute(int val)
    {
        if (val < 0) val *= -1;
        return val;
    }

    // Please, just ignore it 
    public static void RightScoreBoard(int n)
    {
        switch (n){
            case (0):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);
                SetRetangle(125, 75, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (1):

                // Vertical lines

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (2):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines
                SetRetangle(125, 75, 5, 50);

                // Right
                SetRetangle(175, 125, 5, 50);
                break;
            case (3):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (4):
                // Horizontal lines
                SetRetangle(150, 100, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (5):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                break;
            case (6):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);
                SetRetangle(125, 75, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                break;
            case (7):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);

                // Vertical lines

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (8):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);
                SetRetangle(125, 75, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;
            case (9):
                // Horizontal lines
                SetRetangle(150, 150, 50, 5);
                SetRetangle(150, 100, 50, 5);
                SetRetangle(150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(125, 125, 5, 50);

                // Right
                SetRetangle(175, 75, 5, 50);
                SetRetangle(175, 125, 5, 50);
                break;

        }

    }

    public static void LeftScoreBoard(int n)
    {
        switch (n)
        {
            case (0):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 75, 5, 50);
                SetRetangle(-175, 125, 5, 50);
                break;

            case (1):

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);
                break;

            case (2):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);

                // Right
                SetRetangle(-175, 75, 5, 50);
                break;

            case (3):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);
                break;

            case (4):
                // Horizontal lines
                SetRetangle(-150, 100, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 125, 5, 50);
                break;

            case (5):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 125, 5, 50);
                break;

            case (6):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 75, 5, 50);
                SetRetangle(-175, 125, 5, 50);
                break;

            case (7):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);
                break;

            case (8):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 75, 5, 50);
                SetRetangle(-175, 125, 5, 50);
                break;

            case (9):
                // Horizontal lines
                SetRetangle(-150, 150, 50, 5);
                SetRetangle(-150, 100, 50, 5);
                SetRetangle(-150, 50, 50, 5);

                // Vertical lines

                // Left
                SetRetangle(-125, 125, 5, 50);
                SetRetangle(-125, 75, 5, 50);

                // Right
                SetRetangle(-175, 125, 5, 50);
                break;

        }
    }
}
