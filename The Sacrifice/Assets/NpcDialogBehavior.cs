using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcDialogBehavior : MonoBehaviour
{
    [SerializeField]
    private RectTransform panelPos;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private StatManager stats;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.parent.position) > 1.5f)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerStats.Currency >= 3)
                {
                    PlayerStats.Currency -= 3;
                    stats.currentPoints += 1;
                }
            }
        }
        panel.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
