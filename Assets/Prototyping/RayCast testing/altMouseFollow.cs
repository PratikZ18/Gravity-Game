using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altMouseFollow : MonoBehaviour
{

    public float mousesensitivityX = 100f;
    public float mousesensitivityY = 200f;
    public Transform playerBody;
    public float maxCamSpeed = 200f;
    

    // Start is called before the first frame update
    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;  
            transform.localEulerAngles = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivityY * Time.deltaTime;

        
        Vector3 rotateValue = new Vector3(-1*mouseY, 0, 0);
        transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, transform.localEulerAngles + rotateValue, maxCamSpeed);


       //IMP: Taking 80 and 280 as the limits of camera rotation
        if(transform.localEulerAngles.x > 80 && transform.localEulerAngles.x < 95){
            transform.localEulerAngles = new Vector3(80, transform.localEulerAngles.y, 0);
        } else if (transform.localEulerAngles.x >= 270 && transform.localEulerAngles.x < 280){
            transform.localEulerAngles = new Vector3(280, transform.localEulerAngles.y, 0);
        }

        playerBody.eulerAngles = Vector3.MoveTowards(playerBody.eulerAngles, playerBody.eulerAngles + new Vector3(0,mouseX,0), maxCamSpeed);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
