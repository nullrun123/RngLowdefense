using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RoundWon : MonoBehaviour
{
    public TextMeshProUGUI roundstext;
     void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundstext.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round <PlayerState.Rounds) { 
           round++;
            roundstext.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
}
