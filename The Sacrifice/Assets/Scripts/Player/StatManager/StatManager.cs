using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public int currentPoints;
    private int pointsSpentThisSession;
    private Player player;

    public LoadStats statsLoad;

    //private Text statValue;
    //private PlayerHeartsManager heartsUI;

    //Used to prevent player from decreasing stats beyond points he has put into the current session
    private int healthPoints;
    private int staminaPoints;
    private int speedPoints;
    private int attackPoints;


    void Start()
    {
        currentPoints = 2;
        player = GetComponent<Player>();
        //heartsUI = GetComponent<PlayerHeartsManager>();
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
        Debug.Log($"Increase stat {stat.statName}");

        switch (stat.statName)
        {
            case "Health":
                if(player.MaxHealth + healthPoints < player.ActualMaxHearts)
                {
                    healthPoints++;
                    stat.statValue = player.MaxHealth + healthPoints;
                    statsLoad.UpdateValues();
                }
                break;
            case "stamina":
                staminaPoints++;
                break;
            case "speed":
                speedPoints++;
                break;
            case "damage":
                attackPoints++;
                break;
        }
    }

    public void DecreaseStat(string stat)
    {
        Debug.Log($"Decrease stat {stat}");

        switch (stat)
        {
            case "health":
                if(healthPoints > 0) { healthPoints--; }
                break;
            case "stamina":
                if (staminaPoints > 0) { staminaPoints--; }
                break;
            case "speed":
                if (speedPoints > 0) { speedPoints--; }
                break;
            case "damage":
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
