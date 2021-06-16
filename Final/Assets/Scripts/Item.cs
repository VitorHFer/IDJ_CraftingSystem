using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class only provides the variables to identify the item itself. 
/// </summary>
[CreateAssetMenu(fileName ="New item", menuName ="Item Manager/New Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    public string description;
}
