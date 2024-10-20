using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float waitBeforeFade = 1f;

    void Start()
    {
        Time.timeScale = 1f;

        fadeImage.gameObject.SetActive(true);

       StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        color.a = 1;
        fadeImage.color = color;

        while (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    // ฟังก์ชันสำหรับการ Fade และเปลี่ยน Scene
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // ฟังก์ชันสำหรับการ Fade และปิดเกม (Exit)
    public void FadeToExit()
    {
        StartCoroutine(FadeAndExit());
    }

    private IEnumerator FadeOut(string sceneName)
    {
        Color color = fadeImage.color;
        fadeImage.gameObject.SetActive(true);
        color.a = 0;
        fadeImage.color = color;

        // Fade In
        while (color.a < 1)
        {
            color.a += Time.deltaTime / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeFade);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeAndExit()
    {
        Color color = fadeImage.color;
        fadeImage.gameObject.SetActive(true);
        color.a = 0;
        fadeImage.color = color;

        // Fade In
        while (color.a < 1)
        {
            color.a += Time.deltaTime / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeFade);

        // ปิดเกม
        Application.Quit();

        // สำหรับการทดสอบใน Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
