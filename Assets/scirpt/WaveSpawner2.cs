using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner2 : MonoBehaviour
{
    public float plus = 0.2f;

    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform SpawnPoint;

    public static bool win = false;

    public float multi = 1f;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public List<TextMeshProUGUI> waveCountdownTexts;

    private int waveIndex = 0;

    void Update()
    {
        if (waveIndex == waves.Length && EnemiesAlive == 0)
        {
            win = true;
            this.enabled = false;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        foreach (TextMeshProUGUI text in waveCountdownTexts)
        {
            text.text = countdown.ToString("00.00");
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerState.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
        
            GameObject randomEnemy = wave.GetRandomEnemy();
            SpawnEnemy(randomEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        multi += plus;
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject prefab = Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
        Enemy enemyprefab = prefab.GetComponent<Enemy>();

        enemyprefab.speed *= multi;
        enemyprefab.speed2 *= multi;
        enemyprefab.startHealth *= multi;
        enemyprefab.health *= multi;
        enemyprefab.radius *= multi;

        EnemiesAlive++;
    }
}
