using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    private bool canEnter;
    void Start()
    {
        canEnter = false;
        /* GameObject canvas = GameObject.Find("Canvas");
        InputManager im = canvas.GetComponent<InputManager>();
        im.Enter = new UnityEvent();
        im.Enter.AddListener(EnterPortal); */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) EnterPortal();
    }
    void EnterPortal()
    {
        Debug.Log("Hello");
        if (canEnter)
        {
            PlayerInventory pi = GameObject.Find("InvetoryManager").GetComponent<PlayerInventory>();
            if (pi.hasItem("i_Door key"))
            {
                GameController.GameOver(true);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.ToLower() == "player")
        {
            canEnter = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.ToLower() == "player")
        {
            canEnter = false;
        }
    }
}
