using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool Isstun;
    public bool Isparent;

    public float speed = 10f;
    public float speed2 = 10f;
    public float originalSpeed;
    public Coroutine slowCoroutine;
    public float startHealth = 100;
    public float health;
    public int worth = 50;
    private bool isDead = false;

    [Header("Unity stuff")]
    public List<Image> healthBars;

    public List<Loot> lootList = new List<Loot>();

    void Start()
    {
        originalSpeed = speed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

       
        foreach (Image healthBar in healthBars)
        {
            healthBar.fillAmount = health / startHealth;
        }

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void StopSlowing()
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
            slowCoroutine = null;
        }
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        speed = speed2;
        Debug.Log($"Speed reset to original: {speed}");
    }

    IEnumerator SlowEffect(float slowPct)
    {
        speed = originalSpeed * (1f - slowPct);
        yield return new WaitForSeconds(1f);
    }

    public void Slow(float slowPct)
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        slowCoroutine = StartCoroutine(SlowEffect(slowPct));
    }

    public void Slownew(float pct)
    {
        originalSpeed = speed * (1.5f - pct);
    }

    void Die()
    {
        isDead = true;
        GetDroppedItem();
        PlayerState.money += worth;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    Loot GetDroppedItem()
    {
        int randomNumber = UnityEngine.Random.Range(1,101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.change)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            int r = UnityEngine.Random.Range(0,possibleItems.Count);
            int c = PlayerPrefs.GetInt(possibleItems[r].Name);
            c++;
            PlayerPrefs.SetInt(possibleItems[r].Name,c);
            Debug.Log("drop");
        }
        Debug.Log("notdrop");
        return null;
    }

    public float radius = 10f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        if(Isstun)
        {
            Vector3 position = transform.position;

            Collider[] hitColliders = Physics.OverlapSphere(position, radius);

            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("tower"))
                {
                    Turret turret = hitCollider.GetComponent<Turret>();
                    Turret_basic turret1 = hitCollider.GetComponent<Turret_basic>();
                    turret.stunning();
                    turret1.stunning();
                }
            }
        }
        
    }
}
