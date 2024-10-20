using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string Name;
    public int change;

    public Loot(string Name,int change)
    {
        this.Name = Name;
        this.change = change;
    }
}
