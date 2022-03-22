using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UIStatData", menuName = "Stats/NewStatData")]
public class UIStatData : ScriptableObject
{
    public int id;
    public new string name;
    //public Sprite image;
    public int value;


    public void Print()
    {
        Debug.Log($"{name}, {value}");
    }

    
}
