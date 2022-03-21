using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent ToggleInventory;
    [field: SerializeField]
    public UnityEvent PickUpItem;
    /* [field: SerializeField]
    public UnityEvent Enter; */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) ToggleInventory?.Invoke();
        if (Input.GetKeyDown(KeyCode.F)) PickUpItem?.Invoke();
        //if (Input.GetKeyDown(KeyCode.E)) Enter?.Invoke();
    }
}
