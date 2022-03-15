using System.Collections;
using System.Collections.Generic;

public static class Player
{
    private const float _MaxHealth = 4;
    private static float _Health = 4;

    public static float MaxHealth
    {
        get => _MaxHealth;
    }
    public static float Health
    {
        get => _Health;
        set
        {
            if(value > _MaxHealth) { _Health = _MaxHealth; }
            _Health = value;
        }
    }
}
