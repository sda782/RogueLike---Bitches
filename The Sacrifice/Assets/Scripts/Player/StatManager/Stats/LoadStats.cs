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
        statName.text = stat.statName;
        statValue.text = $"{stat.statValue}";
    }

    public void UpdateValues()
    {
        statValue.text = $"{stat.statValue}";
    }
}
