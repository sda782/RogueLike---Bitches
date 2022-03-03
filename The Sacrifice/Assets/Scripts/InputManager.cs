using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent ToggleInventory;
    [field: SerializeField]
    public UnityEvent PickUpItem;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) ToggleInventory?.Invoke();
        if (Input.GetKeyDown(KeyCode.F)) PickUpItem?.Invoke();
    }
}
