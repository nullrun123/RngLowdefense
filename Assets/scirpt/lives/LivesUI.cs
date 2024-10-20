using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerState.Lives.ToString() + " Lives";
    }
}
