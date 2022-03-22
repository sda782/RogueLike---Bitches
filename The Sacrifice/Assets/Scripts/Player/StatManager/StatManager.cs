using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public int currentPoints;
    private int pointsSpentThisSession;
    private Player player;

    public LoadStats[] statsLoad;

    //Used to prevent player from decreasing stats beyond points he has put into the current session
    private int healthPoints;
    private int staminaPoints;
    private int speedPoints;
    private int attackPoints;


    void Start()
    {
        currentPoints = 2;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Confirm()
    {
        if(pointsSpentThisSession > 0)
        {
            player.MaxHealth += healthPoints;
            player.MaxStamina += staminaPoints;
            player.Speed += speedPoints;
            player.Attack += attackPoints;

            EndSession();
        }
    }

    public void IncreaseStat(UIStatData stat)
    {
        if(currentPoints <= 0) { return; }
        Debug.Log($"Increase stat {stat.name}");

        int id = stat.id;

        switch (stat.name)
        {
            case "Health":
                if(player.MaxHealth + healthPoints < player.ActualMaxHearts)
                {
                    healthPoints++;
                    stat.value = player.MaxHealth + healthPoints;
                }
                break;
            case "Stamina":
                staminaPoints++;
                stat.value = player.MaxStamina + staminaPoints;
                break;
            case "Speed":
                speedPoints++;
                stat.value = player.Speed + speedPoints;
                break;
            case "Damage":
                attackPoints++;
                stat.value = player.Attack + attackPoints;
                break;
        }

        statsLoad[id].UpdateValues();
    }

    public void DecreaseStat(string stat)
    {
        Debug.Log($"Decrease stat {stat}");

        switch (stat)
        {
            case "Health":
                if(healthPoints > 0) { healthPoints--; }
                break;
            case "Stamina":
                if (staminaPoints > 0) { staminaPoints--; }
                break;
            case "Speed":
                if (speedPoints > 0) { speedPoints--; }
                break;
            case "Damage":
                if (attackPoints > 0) { attackPoints--; }
                break;
        }
    }

    private void EndSession()
    {
        healthPoints = 0;
        staminaPoints = 0;
        speedPoints = 0;
        attackPoints = 0;
    }
}
