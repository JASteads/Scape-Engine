using System;

public class DieRoll
{
    int maxValue;

    public DieRoll(int sides)
    {
        maxValue = sides;
    }

    public int Roll()
    {
        Random r = new Random();

        return r.Next(maxValue);
    }
}