using System.Collections;
using System.Collections.Generic;

public class Player : EntityStats
{
    void Start()
    {
        maxHealth = 4;
        currentHealth = maxHealth;
        attack = 1;
        speed = 5;
        stamina = 3;
        atk_speed = 1;
    }
    public override int Health
    {
        get => currentHealth;
        set
        {
            if (value > maxHealth) { currentHealth = maxHealth; }
            currentHealth = value;
        }
    }
}
