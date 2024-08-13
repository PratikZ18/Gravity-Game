using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousec : MonoBehaviour
{

    public float mousesensitivity = 100f;
    public Transform playerBody;
    

    // Start is called before the first frame update
    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.right * -mouseY);
     
    }
}
