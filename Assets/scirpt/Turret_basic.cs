using UnityEngine;
using System.Collections;

public class Turret_basic : MonoBehaviour
{
    public float audiotime = 1f;
    public float audiocount = 1f;

    public AudioSource shootSound;

    public ParticleSystem stuneffect;

    public bool Isstunning = false;
    public float cdstun = 5f;
    public float timestun = 3f;
    public float countstunning = 0f;

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Laser")]
    public bool useLaser = true; // Laser is now always enabled

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public string specialEnemyTag = "SpecialEnemy"; // Tag for special enemies

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // Find SpecialEnemies first
        GameObject[] specialEnemies = GameObject.FindGameObjectsWithTag(specialEnemyTag);
        float shortestDistanceToSpecialEnemy = Mathf.Infinity;
        GameObject nearestSpecialEnemy = null;

        foreach (GameObject enemy in specialEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToSpecialEnemy)
            {
                shortestDistanceToSpecialEnemy = distanceToEnemy;
                nearestSpecialEnemy = enemy;
            }
        }

        // If a SpecialEnemy is found within range, target it
        if (nearestSpecialEnemy != null && shortestDistanceToSpecialEnemy <= range)
        {
            target = nearestSpecialEnemy.transform;
            targetEnemy = nearestSpecialEnemy.GetComponent<Enemy>();
            return;
        }

        // If no SpecialEnemy is found, find regular enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If a regular enemy is found within range, target it
        if (nearestEnemy != null && shortestDistanceToEnemy <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null || Isstunning)
        {
            if (lineRenderer != null && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                if (impactEffect != null) impactEffect.Stop();
                if (impactLight != null) impactLight.enabled = false;
            }
            return;
        }

        if (!Isstunning)
        {
            LockOnTarget();

            Laser(); // Use laser for all targets

            if (audiocount <= 0)
            {
                shootSound.Play();
                audiocount = audiotime;
            }
            audiocount -= Time.deltaTime;

            countstunning -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        // Deal damage to target enemy
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slownew(slowAmount);

        if (lineRenderer != null)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
                if (impactEffect != null) impactEffect.Play();
                if (impactLight != null) impactLight.enabled = true;
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            Vector3 dir = firePoint.position - target.position;

            if (impactEffect != null)
            {
                impactEffect.transform.position = target.position + dir.normalized;
                impactEffect.transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void stunning()
    {
        if (!Isstunning && countstunning <= 0)
        {
            Isstunning = true;
            stuneffect.Play();
            Invoke("reset", timestun);
        }
    }

    public void reset()
    {
        Isstunning = false;
        stuneffect.Stop();
        countstunning = cdstun;
    }
}
