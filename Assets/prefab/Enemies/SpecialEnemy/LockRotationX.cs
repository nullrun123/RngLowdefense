using UnityEngine;

public class LockRotationX : MonoBehaviour
{
    void Update()
    {
        // ล็อคแกน X
        transform.rotation = Quaternion.Euler(85, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        
    }
}