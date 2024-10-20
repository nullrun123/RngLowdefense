using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchcam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;

    // ฟังก์ชันสำหรับสลับกล้องตามปุ่มที่กด
    public void SwitchCamera(int camNumber)
    {
        // ตรวจสอบค่า camNumber แล้วสลับกล้องตามที่เลือก
        switch (camNumber)
        {
            case 1:
                Cam1();
                break;
            case 2:
                Cam2();
                break;
            case 3:
                Cam3();
                break;
            case 4:
                Cam4();
                break;
            case 5:
                Cam5();
                break;
        }
    }

    void Cam1()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
    }

    void Cam2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
    }

    void Cam3()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        cam4.SetActive(false);
        cam5.SetActive(false);
    }

    void Cam4()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(true);
        cam5.SetActive(false);
    }

    void Cam5()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(true);
    }
}
