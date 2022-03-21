using System.Collections;
using System.Collections.Generic;

public static class Player
{
    private const int _MaxHealth = 4;
    private static int _Health = 4;

    public static int MaxHealth
    {
        get => _MaxHealth;
    }
    public static int Health
    {
        get => _Health;
        set
        {
            if(value > _MaxHealth) { _Health = _MaxHealth; }
            _Health = value;
        }
    }
}
