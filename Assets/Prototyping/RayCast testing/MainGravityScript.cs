using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGravityScript : MonoBehaviour
{
    private bool glow = false;
    private bool grav = true;
    //private Rigidbody targetMass = null;
    private Rigidbody thisBody = null;

    // Start is called before the first frame update
    void Start()
    {
        thisBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(!grav){
            //Vector3 dirn = targetMass.transform.position - thisBody.transform.position;
            //thisBody.AddForce(dirn);
        }
    }

    public void glowOn(){
        if(!glow){
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            glow = true;
        }
    }

    public void glowOff(){
        if(glow){
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            glow = false;
        }
    }

    public void gravOn(){
        //targetMass = null;
        thisBody.useGravity = true;
        grav = true;
    }

    public void gravOff(){
        //targetMass = target;
    
        thisBody.useGravity = false;
        
        grav = false;
    }
}
