using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrency : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{Player.Currency.ToString()}";
    }
}
