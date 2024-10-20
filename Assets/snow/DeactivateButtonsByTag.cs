using UnityEngine;

public class DeactivateButtonsByTag : MonoBehaviour
{
    public string targetTag = "textme";
    public void DeactivateAllButtonsWithTag()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject button in buttons)
        {
            button.SetActive(false); 
        }
    }
}
