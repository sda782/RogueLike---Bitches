using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIInput : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent ToggleInventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory?.Invoke();
        }
    }
}
