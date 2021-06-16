using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New formula", menuName ="Item Manager/New Formula")]
public class Formula : ScriptableObject 
{
    public Item[] topGrid = new Item[3];
    public Item[] midGrid= new Item[3];
    public Item[] botGrid = new Item[3];

    public Item output;
}
