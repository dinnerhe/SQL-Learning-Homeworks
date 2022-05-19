namespace ColorBall;

public class Color
{
    private int Red, Green, Blue, Alpha;
    
    public Color(int r, int g, int b, int a)
    {
        Red = r;
        Green = g;
        Blue = b;
        Alpha = a;
    }
    
    public Color(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
        Alpha = 255;
    }

    public void SetRed(int r){Red = r;}
    public void SetGreen(int g){Green = g;}
    public void SetBlue(int b){Blue = b;}
    public void SetAlpha(int a){Alpha = a;}

    public int GetRed(){return Red;}
    public int GetGreen(){return Green;}
    public int GetBlue(){return Blue;}
    public int GetAlpha(){return Alpha;}

    public int GetGreyScale()
    {
        return (Red + Green + Blue) / 3;
    }


}