using System.Collections.Generic;
using UnityEngine;

public class slowobj11 : MonoBehaviour
{
    public float range = 5f; // ระยะการตรวจจับ
    public float rotationSpeed = 100f; // ความเร็วในการหมุน
    public string enemyTag = "Enemy"; // แท็กของศัตรูและอ็อบเจกต์ที่ต้องการหมุน
    public Vector3 customRotationAxis = Vector3.up; // แกนการหมุนที่สามารถปรับแต่งได้

    private List<Enemy> enemiesInRange = new List<Enemy>(); // รายการของศัตรูในระยะ

    void Update()
    {
        // ค้นหาศัตรูทั้งหมดในฉากที่มีแท็กตามที่กำหนด
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
                    Debug.Log($"Enemy {targetEnemy.name} is in range. Rotating object."); // ดีบัก
                }

                // หมุนศัตรูหรืออ็อบเจกต์ที่มีแท็กเดียวกับ enemyTag
                enemy.transform.Rotate(customRotationAxis * rotationSpeed * Time.deltaTime); // หมุนตามแกนที่กำหนด
            }
            else
            {
                if (enemiesInRange.Contains(targetEnemy)) // ถ้าออกจากระยะ
                {
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
