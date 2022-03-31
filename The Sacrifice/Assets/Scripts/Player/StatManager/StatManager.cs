using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public int currentPoints;
    public Text currentPointsUI;
    private int pointsSpentThisSession;
    private Player player;
    public PlayerHeartsManager heartManager;

    public LoadStats[] statsLoad;

    //Used to prevent player from decreasing stats beyond points he has put into the current session
    private int healthPoints;
    private int staminaPoints;
    private int speedPoints;
    private int attackPoints;


    void Start()
    {
        currentPoints = 10;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Confirm()
    {
        if(pointsSpentThisSession > 0)
        {
            if(healthPoints > 0)
            {
                for(int i = 1; i <= healthPoints; i++)
                {
                    player.MaxHealth += 1;
                    heartManager.IncreaseMaxHearts();
                }
            }
            player.MaxStamina += staminaPoints;
            player.RunSpeed += speedPoints;
            player.Attack += attackPoints;

            EndSession();
        }
    }

    public void IncreaseStat(UIStatData stat)
    {
        if(currentPoints <= 0) { return; }

        switch (stat.name)
        {
            case "Health":
                if(player.MaxHealth + healthPoints < player.ActualMaxHearts)
                {
                    healthPoints++;
                    stat.value = player.MaxHealth + healthPoints;
                }
                else if(player.MaxHealth + healthPoints >= player.ActualMaxHearts)
                {
                    currentPoints++;
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

        currentPoints--;
        pointsSpentThisSession++;
        currentPointsUI.text = "" + currentPoints;
        statsLoad[stat.id].statValue.color = Color.magenta;
        statsLoad[stat.id].UpdateValues();
    }

    public void DecreaseStat(UIStatData stat)
    {
        switch (stat.name)
        {
            case "Health":
                if(healthPoints > 0) { healthPoints--; currentPoints++; pointsSpentThisSession--; }
                if (healthPoints == 0) { statsLoad[stat.id].statValue.color = Color.black; }
                stat.value = player.MaxHealth + healthPoints;
                break;
            case "Stamina":
                if (staminaPoints > 0) { staminaPoints--; currentPoints++; pointsSpentThisSession--; }
                if (staminaPoints == 0) { statsLoad[stat.id].statValue.color = Color.black; }
                stat.value = player.MaxStamina + staminaPoints;
                break;
            case "Speed":
                if (speedPoints > 0) { speedPoints--; currentPoints++; pointsSpentThisSession--; }
                if (speedPoints == 0) { statsLoad[stat.id].statValue.color = Color.black; }
                stat.value = player.Speed + speedPoints;
                break;
            case "Damage":
                if (attackPoints > 0) { attackPoints--; currentPoints++; pointsSpentThisSession--; }
                if (attackPoints == 0) { statsLoad[stat.id].statValue.color = Color.black; }
                stat.value = player.Attack + attackPoints;
                break;
        }
        
        currentPointsUI.text = "" + currentPoints;
        statsLoad[stat.id].UpdateValues();
    }

    private void EndSession()
    {
        healthPoints = 0;
        staminaPoints = 0;
        speedPoints = 0;
        attackPoints = 0;
    }
}
