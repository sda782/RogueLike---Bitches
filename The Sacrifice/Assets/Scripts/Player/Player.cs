using System.Collections;
using System.Collections.Generic;

public class Player
{
    private const float _MaxHealth = 100;
    private float _Health;

    public float MaxHealth
    {
        get => _MaxHealth;
    }
    public float Health
    {
        get => _Health;
        set
        {
            if(value > _MaxHealth) { _Health = _MaxHealth; }
            _Health = value;
        }
    }
}
