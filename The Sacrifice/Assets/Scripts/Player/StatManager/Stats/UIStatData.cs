using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(fileName = "UIStatData", menuName = "Stats/NewStatData")]
public class UIStatData : ScriptableObject
{
    public int id;
    public Sprite image;
    public new string name;
    public int value;


    public void Print()
    {
        Debug.Log($"{name}, {value}");
    }

    
}
