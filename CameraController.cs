using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation;
    public GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector2(transform.rotation.x, transform.rotation.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Rotation
        rotation.x += Input.GetAxisRaw("Mouse X");
        rotation.y += Input.GetAxisRaw("Mouse Y");
        transform.rotation = Quaternion.Euler(0, rotation.x, 0);
        mainCamera.transform.rotation = Quaternion.Euler(-rotation.y, rotation.x, 0);
    }
}
 