using UnityEngine;

public class UITrackCamera : MonoBehaviour
{
    public Canvas canvas; // อ้างถึง Canvas ที่มี UI
    private Camera currentCamera; // กล้องที่ active อยู่

    void Start()
    {
        // ตรวจหากล้องตัวแรกที่ active
        currentCamera = Camera.main;

        // ตรวจสอบว่าตั้งค่า Canvas เป็น World Space แล้ว
        if (canvas.renderMode != RenderMode.WorldSpace)
        {
            canvas.renderMode = RenderMode.WorldSpace;
        }

        // ตั้งค่า Event Camera ใน Canvas เพื่อให้ Canvas ใน World Space ใช้การได้กับกล้องปัจจุบัน
        canvas.worldCamera = currentCamera;
    }

    void Update()
    {
        // ตรวจสอบว่ากล้องที่ใช้งานเป็นตัวไหน
        // ตรวจสอบว่ากล้องที่ใช้งานเป็นตัวไหน
        if (currentCamera == null || !currentCamera.gameObject.activeInHierarchy)
        {
            currentCamera = FindActiveCamera();
            canvas.worldCamera = currentCamera; // อัปเดตกล้องสำหรับ Canvas
        }

        // อัปเดตทิศทางของ UI Image ให้หันไปหากล้องที่ใช้งานอยู่
        if (currentCamera != null)
        {
            Vector3 cameraDirection = currentCamera.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(cameraDirection);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z);
        }
    }



    // ฟังก์ชันในการค้นหากล้องตัวที่ active อยู่
    private Camera FindActiveCamera()
    {
        Camera[] cameras = Camera.allCameras;
        foreach (Camera cam in cameras)
        {
            if (cam.gameObject.activeInHierarchy)
            {
                return cam;
            }
        }
        return Camera.main; // หากไม่เจอกล้อง active ใดๆ ให้คืนค่าเป็น Main Camera
    }
}
