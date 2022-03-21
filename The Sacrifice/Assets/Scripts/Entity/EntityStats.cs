using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    protected int maxHealth;
    protected int currentHealth;
    protected int attack;
    protected int speed;
    protected int maxStamina;
    protected int stamina;
    protected int atk_speed;
    public virtual int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public virtual int Health { get => currentHealth; set => currentHealth = value; }
    public virtual int Attack { get => attack; set => attack = value; }
    public virtual int Speed { get => speed; set => speed = value; }
    public virtual int MaxStamina { get => maxStamina; set => maxStamina = value; }
    public virtual int Stamina { get => stamina; set => stamina = value; }
    public virtual int Atk_Speed { get => atk_speed; set => atk_speed = value; }

}
