using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject npc;
    [SerializeField]
    private GameObject portal_pre;
    [SerializeField]
    private GameObject chest_pre;
    [SerializeField]
    private Sprite keyChestSprite;

    void Awake()
    {
        if (PlayerStats.KeepInventory == null)
        {
            PlayerStats.KeepInventory = new List<string>();
        }
    }
    void Start()
    {
        Text lxl_cl_txt = GameObject.Find("LevelStats").GetComponent<Text>();
        lxl_cl_txt.text = "level cleared: " + PlayerStats.LevelsCleared;
        RoomFirst rf = GameObject.Find("RoomFirst").GetComponent<RoomFirst>();
        GameObject portal = Instantiate(portal_pre);
        portal.transform.position = rf.RoomList.LastOrDefault();
        player.transform.position = rf.RoomList.FirstOrDefault();
        if (PlayerStats.LevelsCleared != 1){
            npc.transform.position = rf.RoomList.FirstOrDefault() + new Vector2(0, 2);
        }
        bool setKeyChest = false;
        for (int i = 1; i < rf.RoomList.Count - 1; i++)
        {
            if (i != 1 || i != rf.RoomList.Count - 1)
            {
                if (i % 4 == 0)
                {
                    GameObject chest = Instantiate(chest_pre);
                    chest.transform.SetParent(GameObject.Find("LootContainer").transform);
                    chest.transform.position = rf.RoomList[i];
                    if (!setKeyChest)
                    {
                        chest.tag = "KeyChest";
                        chest.GetComponent<SpriteRenderer>().sprite = keyChestSprite;
                        setKeyChest = true;
                    }
                }
            }
        }
    }
    public static void GameOver(bool didWin)
    {
        if (didWin)
        {
            Debug.Log("You win");
            PlayerStats.EnemiesPrRoom++;
            PlayerStats.LevelsCleared++;
            PlayerInventory pi = GameObject.Find("InvetoryManager").GetComponent<PlayerInventory>();
            PlayerStats.KeepInventory = new List<string>();
            foreach (var item in pi.GetBag) if (item.name != "i_Door key") PlayerStats.KeepInventory.Add(item.name.Substring(2));
        }
        else
        {
            Debug.Log("You lose");
            PlayerStats.LevelsCleared = 0;
            PlayerStats.EnemiesPrRoom = 0;
        }
        SceneManager.LoadScene(0);
    }
}
