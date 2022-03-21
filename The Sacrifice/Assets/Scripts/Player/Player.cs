using System.Collections;
using System.Collections.Generic;

public class Player : EntityStats
{
    void Start()
    {
        maxhealth = 4;
        currenthealth = maxhealth;
        attack = 1;
        speed = 5;
        stamina = 3;
        atk_speed = 1;
    }
    public override int Health
    {
        get => currenthealth;
        set
        {
            if (value > maxhealth) { currenthealth = maxhealth; }
            currenthealth = value;
        }
    }
}
