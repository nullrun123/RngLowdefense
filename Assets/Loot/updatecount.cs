using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class updatecount : MonoBehaviour
{
    public TMP_Text Text;
    public Loot lootList;
    
    void Update()
    {
        int count = PlayerPrefs.GetInt(lootList.Name);
        Text.text = count.ToString();
    }
}
