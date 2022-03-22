using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UIStatData", menuName = "Stats/NewStatData")]
public class UIStatData : ScriptableObject
{
    public string statName;
    //public Sprite image;
    public int statValue;


    public void Print()
    {
        Debug.Log($"{statName}, {statValue}");
    }

    
}
