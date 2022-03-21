using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    protected int maxhealth;
    protected int currenthealth;
    protected int attack;
    protected int speed;
    protected int stamina;
    protected int atk_speed;
    public virtual int MaxHealth { get => maxhealth; }
    public virtual int Health { get => currenthealth; set => currenthealth = value; }
    public virtual int Attack { get => attack; set => attack = value; }
    public virtual int Speed { get => speed; set => speed = value; }
    public virtual int Stamina { get => stamina; set => stamina = value; }
    public virtual int Atk_Speed { get => atk_speed; set => atk_speed = value; }

}
