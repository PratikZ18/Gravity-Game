using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityScript : MonoBehaviour
{
    private bool glow = false;
    public bool grav = true;

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
        //thisBody.useGravity = true;
        grav = true;
    }

    public void gravOff(){
        //targetMass = target;
    
        //thisBody.useGravity = false;
        
        grav = false;
    }
}
