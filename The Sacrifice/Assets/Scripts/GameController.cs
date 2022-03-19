using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject portal_pre;
    [SerializeField]
    private GameObject chest_pre;
    void Start()
    {
        RoomFirst rf = GameObject.Find("RoomFirst").GetComponent<RoomFirst>();
        GameObject portal = Instantiate(portal_pre);
        portal.transform.position = rf.RoomList.LastOrDefault();
        player.transform.position = rf.RoomList.FirstOrDefault();
        for (int i = 1; i < rf.RoomList.Count - 1; i++)
        {
            if (i != 1 || i != rf.RoomList.Count - 1)
            {
                GameObject chest = Instantiate(chest_pre);
                chest.transform.SetParent(GameObject.Find("LootContainer").transform);
                chest.transform.position = rf.RoomList[i];
            }
        }
    }
}
