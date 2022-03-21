using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int currentPoints;
    private int pointsSpentThisSession;
    private Player player;
    private PlayerHeartsManager heartsUI;


    void Start()
    {
        currentPoints = 2;
        player = GetComponent<Player>();
        heartsUI = GetComponent<PlayerHeartsManager>();
    }

    public void IncreaseStat(string stat)
    {
        if(currentPoints <= 0) { return; }
        Debug.Log($"Increase stat {stat}");

        switch (stat)
        {
            case "health":
                player.MaxHealth++;
                heartsUI.ShowAllCurrentHearts();
                break;
            case "stamina":
                player.MaxStamina++;
                break;
            case "speed":
                player.Speed++;
                break;
            case "damage":
                player.Attack++;
                break;
        }
    }

    public void DecreaseStat(string stat)
    {
        Debug.Log($"Decrease stat {stat}");

        switch (stat)
        {
            case "health":
                player.MaxHealth--;
                break;
            case "stamina":
                player.MaxStamina--;
                break;
            case "speed":
                player.Speed--;
                break;
            case "damage":
                player.Attack--;
                break;
        }
    }
}
