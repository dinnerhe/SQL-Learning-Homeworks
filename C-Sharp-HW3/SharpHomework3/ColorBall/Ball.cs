namespace ColorBall;

public class Ball
{
    private int Size;
    private Color Color;
    private int NumThrown;

    public Ball(int size)
    {
        Size = size;
        Color = new Color(255, 255, 255);
        NumThrown = 0;
    }

    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
        NumThrown = 0;
    }

    public void Pop()
    {
        Size = 0;
    }

    public void Throw()
    {
        if(Size!=0) NumThrown++;
    }

    public int GetThrownTime()
    {
        return NumThrown;
    }
    

}