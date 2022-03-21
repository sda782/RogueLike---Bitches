using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHeartsManager : MonoBehaviour
{
    private readonly int ActualMaxHearts = 10;
    private Player player;
    public Image[] heartImages;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        OnStart();
    }

    //public void IncreaseMaxHearts()
    //{
    //    if(player.MaxHealth < ActualMaxHearts)
    //    {
    //        player.MaxHealth++;
    //        player.Health = player.MaxHealth;
    //        ShowAllCurrentHearts();
    //    }
    //}

    public void IncreaseHearts()
    {
        if(player.Health < player.MaxHealth)
        {
            heartImages[player.Health].enabled = true;
        }
    }

    public void DecreaseHearts()
    {
        heartImages[player.Health].enabled = false;
    }

    public void ShowAllCurrentHearts()
    {
        if(player.MaxHealth >= ActualMaxHearts) { return; }
        player.Health = player.MaxHealth;

        for(int i = 0; i < player.MaxHealth; i++)
        {
            heartImages[i].enabled = true;
        }
    }

    //Used to disable the last 6 hearts at the start
    private void OnStart()
    {
        for(int i = ActualMaxHearts - 1; i >= player.MaxHealth; i--)
        {
            heartImages[i].enabled = false;
        }
    }

}
