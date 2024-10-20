using UnityEngine;
using System.Collections;

public class SoundManager_win : MonoBehaviour
{
    public static SoundManager_win instance;  // Singleton ของ SoundManager
  
    private AudioSource audioSource;
    private Coroutine soundCoroutine; // เก็บ Coroutine เพื่อให้สามารถหยุดได้
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ไม่ทำลาย GameObject เมื่อเปลี่ยน Scene
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // ฟังก์ชันสำหรับเล่นเสียงเป็นเวลา 2 วินาที
    public void PlaySoundWithCooldown(float duration)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(StopSoundAfterTime(duration)); // เรียก Coroutine เพื่อหยุดเสียงหลังจากเวลาที่กำหนด
        }
    }

    // Coroutine สำหรับหยุดเสียงหลังจากเวลา 2 วินาที
    private IEnumerator StopSoundAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration); // รอเวลาที่กำหนด
        audioSource.Stop();  // หยุดเสียง
    }
    // ฟังก์ชันสำหรับหยุดเสียงทันที
    public void StopSoundStop()
    {
        if (audioSource.isPlaying)
        {
            // ถ้ามี Coroutine ทำงานอยู่ให้หยุดมันก่อน
            if (soundCoroutine != null)
            {
                StopCoroutine(soundCoroutine);
                soundCoroutine = null;
            }
            audioSource.Stop();  // หยุดเสียงทันที
        }
    }
}
