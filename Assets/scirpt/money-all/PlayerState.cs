using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int money;
    public int startMoney = 99999999;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public List<Loot> lootList = new List<Loot>();

    public List<Loot> startlootList = new List<Loot>();

    public int startcount = 1;

    void Start()
    {

        money = startMoney;
        Lives = startLives;
        Rounds = 0;

        foreach(Loot item in lootList)
        {
            PlayerPrefs.SetInt(item.Name,0);
        }

        foreach(Loot startitem in startlootList)
        {
            PlayerPrefs.SetInt(startitem.Name,startcount);
        }
    }
}
