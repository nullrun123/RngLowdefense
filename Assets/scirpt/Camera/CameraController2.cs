using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3 : MonoBehaviour
{

    private bool doMovement = true;
    public float panspeed = 30f;
    public float panBorderThinkness = 10f;
    public Camera cam; 
    public float zoomSpeed = 9f;
    public float minFOV = 15f;  
    public float maxFOV = 90f;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("s"))
        {
            
            transform.Translate(Vector3.forward * panspeed * Time.deltaTime,Space.World);        
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a"))
        {

            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {

            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        //pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.y, minFOV, maxFOV);

        transform.position = pos;



    
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        cam.fieldOfView -= scrollInput * zoomSpeed;

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    }

}
