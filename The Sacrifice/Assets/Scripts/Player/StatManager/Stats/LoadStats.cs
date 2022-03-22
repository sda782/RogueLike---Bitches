using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    public UIStatData stat;

    public Text statName;
    public Text statValue;


    void Start()
    {
        statName.text = stat.name;
        statValue.text = $"{stat.value}";
    }

    public void UpdateValues()
    {
        statValue.text = $"{stat.value}";
    }
}
