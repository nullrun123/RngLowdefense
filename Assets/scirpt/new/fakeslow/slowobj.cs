using System.Collections.Generic;
using UnityEngine;

public class slowobj : MonoBehaviour
{
    public float range = 5f; // ระยะการตรวจจับ
    public float damageOverTimexd = 10f; // ดาเมจต่อวินาที
    public float slowPct = 0.7f; // เปอร์เซ็นต์การชะลอ
    public string enemyTag = "Enemy"; // แท็กของศัตรูที่ต้องการตรวจจับ

    private List<Enemy> enemiesInRange = new List<Enemy>(); // รายการของศัตรูในระยะ

    void Update()
    {
        // ค้นหาศัตรูทั้งหมดในฉาก
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position); // คำนวณระยะทาง
            Enemy targetEnemy = enemy.GetComponent<Enemy>();

            if (distance <= range) // ถ้าศัตรูอยู่ในระยะ
            {
                if (!enemiesInRange.Contains(targetEnemy)) // ถ้ายังไม่อยู่ในลิสต์
                {
                    enemiesInRange.Add(targetEnemy); // เพิ่มศัตรูในลิสต์
                    targetEnemy.Slow(slowPct); // ชะลอศัตรู
                    Debug.Log($"Slowing enemy: {targetEnemy.name}"); // ดีบัก
                }

                // ทำดาเมจต่อเนื่อง
                targetEnemy.TakeDamage(damageOverTimexd * Time.deltaTime);
            }
            else
            {
                if (enemiesInRange.Contains(targetEnemy)) // ถ้าออกจากระยะ
                {
                    targetEnemy.StopSlowing(); // หยุดการชะลอและคืนความเร็ว
                    enemiesInRange.Remove(targetEnemy); // ลบศัตรูออกจากลิสต์
                    Debug.Log($"Enemy {targetEnemy.name} has exited range."); // ดีบัก
                }
            }
        }
    }

   
    void OnDrawGizmos()
    {
        // กำหนดสีของ Gizmo เป็นสีเขียว
        Gizmos.color = Color.green;
        // วาดเส้นรอบวงที่ตำแหน่งของอ็อบเจกต์นี้โดยมีรัศมีเท่ากับค่า range
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
