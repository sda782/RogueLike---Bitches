using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenStatMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject statMenu;

    private bool currentlyActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        statMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            statMenu.SetActive(currentlyActive);

            currentlyActive = !currentlyActive;
        }
    }
}
