using System.Collections;
using System.Collections.Generic;

public class Player : EntityStats
{
    public readonly int ActualMaxHearts = 10;

    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        attack = 1;
        speed = 1;
        stamina = 1;
        atk_speed = 1;
    }
    public void TakeDamage(int dmg)
    {
        Health -= dmg;
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
    public override int MaxHealth
    {
        get => maxHealth;
        set
        {
            if (value + maxHealth > ActualMaxHearts) { maxHealth = ActualMaxHearts; }
            else
            {
                maxHealth = value;
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
