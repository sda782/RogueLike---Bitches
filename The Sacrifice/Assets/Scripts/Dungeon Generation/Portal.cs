using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool canEnter;
    private void Start()
    {
        canEnter = false;
        InputManager im = GameObject.Find("Canvas").GetComponent<InputManager>();
        im.Enter.AddListener(EnterPortal);
    }
    public void EnterPortal()
    {
        if (canEnter) SceneManager.LoadScene(1);
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
