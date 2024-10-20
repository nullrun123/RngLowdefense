using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "menu";
    public string nextlevel = "map2";
    public int levelToUnlock = 2;
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);

}
public void Menu()
    {
       
    }
}
