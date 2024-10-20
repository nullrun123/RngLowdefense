using UnityEngine;

public class CanvasController : MonoBehaviour
{ 
    public GameObject targetObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // สร้าง Ray จากตำแหน่งของเมาส์ในกล้อง
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ตรวจสอบว่า Ray โดน object ที่มี Collider หรือไม่
            if (Physics.Raycast(ray, out hit))
            {
                SoundManager1.instance.PlaySoundWithCooldown(0.23f);
                // ตรวจสอบว่าคลิก object ที่เรากำหนดไว้หรือไม่
                if (hit.collider.gameObject == targetObject)
                {
                    // แสดง Canvas
                    DestroyObject(targetObject);
                }
            }
        }
    }

    void DestroyObject(GameObject objectToDestroy)
    {
        // ตรวจสอบว่า object ไม่ได้ถูกทำลายไปก่อนแล้ว
        if (objectToDestroy != null)
        {
            string _name = objectToDestroy.name.Replace("(Clone)","");

            int c = PlayerPrefs.GetInt(_name);
            c++;
            PlayerPrefs.SetInt(_name,c);

            Debug.Log(objectToDestroy.name);

            Destroy(objectToDestroy);
        }
    }
}
