using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHeartsManager : MonoBehaviour
{
    private Player player;
    public Image[] heartImages;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        OnStart();
    }

    public void IncreaseMaxHearts()
    {
        heartImages[player.MaxHealth - 1].enabled = true;
        heartImages[player.MaxHealth - 1].color = Color.gray;
    }

    public void IncreaseHearts()
    {
        if(player.Health <= player.MaxHealth)
        {
            heartImages[player.Health - 1].color = Color.white;
        }
    }

    public void DecreaseHearts()
    {
        heartImages[player.Health].color = Color.gray;
    }

    public void ShowAllCurrentHearts()
    {
        if(player.MaxHealth >= player.ActualMaxHearts) { return; }
        player.Health = player.MaxHealth;

        for(int i = 0; i < player.MaxHealth; i++)
        {
            heartImages[i].enabled = true;
        }
    }

    //Used to disable the last 6 hearts at the start
    private void OnStart()
    {
        for(int i = player.ActualMaxHearts - 1; i >= player.MaxHealth; i--)
        {
            heartImages[i].enabled = false;
        }
    }

}
