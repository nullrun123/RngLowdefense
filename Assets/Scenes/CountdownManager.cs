using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    public Text countdownText; 
    public float countdownTime = 3f; 
    public string sceneToLoad; 

    private void Start()
    {
        StartCoroutine(CountdownToScene());
    }

    private IEnumerator CountdownToScene()
    {
        float timeRemaining = countdownTime;

        while (timeRemaining > 0)
        {
            countdownText.text = Mathf.Ceil(timeRemaining).ToString(); 
            timeRemaining -= Time.deltaTime;
            yield return null; 
        }

        // หลังจากหมดเวลา เปลี่ยน Scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
