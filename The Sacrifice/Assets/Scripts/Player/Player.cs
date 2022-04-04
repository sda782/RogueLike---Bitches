using System.Collections;
using System.Collections.Generic;

public class Player : EntityStats
{
    public readonly int ActualMaxHearts = 10;
    public float RunSpeed;

    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        attack = 1;
        speed = 5;
        stamina = 1;
        atk_speed = 1;
        RunSpeed = 7;
    }
    public override int Health
    {
        get => currentHealth;
        set
        {
            if (value > maxHealth) { currentHealth = maxHealth; }
            else
            {
                currentHealth = value;
            }
        }
    }

    public override int Stamina
    {
        get => stamina;
        set
        {
            if (value > maxStamina) { stamina = maxStamina; }
            else
            {
                stamina = value;
            }
        }
    }
}
