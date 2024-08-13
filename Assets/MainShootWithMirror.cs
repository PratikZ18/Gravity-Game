
using UnityEngine;

public class MainShootWithMirror : MonoBehaviour
{
    public float range = 100f;
    public float maxGravStrength = 10f;
    public Camera playerCam;
    private MainGravityScript script1 = null;
    private MainGravityScript script2 = null;
    private PlayerGravityScript pScript = null;
    private CharacterController controller;
    private bool firstTar = false;
    private bool secondTar = false;
    private Rigidbody rb1 = null;
    private Rigidbody rb2 = null;
    private float gravMultiplier = 0f;
    private float scrollScale = 0.02f;
    public BarVisibilityScript gravBarScript;
    private Vector3 upV = new Vector3(0f,1f,0f);
    public float pMoveCompensation = 1f;
    private Transform playerTransform;

    public float getGravMultiplier(){
        return gravMultiplier;
    }

    void Start(){
        controller = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
    }

    void setGravMultiplier(float val){
        //check for val in correct range
        if(val > 1f){
            val = 1f;
        } else if (val < -1f){
            val = -1f;
        }
        gravMultiplier = val;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetButtonDown("Fire1")){
            shoot();
        }
        //Debug.Log(Input.mouseScrollDelta.y);
        setGravMultiplier(gravMultiplier + scrollScale*Input.mouseScrollDelta.y);
    }

    void FixedUpdate(){
         //handle the antigrav forces on objects
        if(script1 && script2){
            if(script1 != script2){ //two objects
                Vector3 dirn = rb2.transform.position - rb1.transform.position;
                rb1.AddForce(dirn*gravMultiplier);
                rb2.AddForce(dirn*gravMultiplier*-1);
            } else { //single object - straight antigrav
                rb1.AddForce(0,maxGravStrength*gravMultiplier,0);
            }
        } else if(script1 && pScript){
            Vector3 dirn = playerTransform.position - rb1.transform.position;
            rb1.AddForce(dirn*gravMultiplier);
            controller.Move(dirn*gravMultiplier*pMoveCompensation);
        } else if(firstTar && secondTar && pScript){
            controller.Move(gravMultiplier*maxGravStrength*pMoveCompensation*upV);
        }
    }

    void shoot(){
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)){
            //Debug.Log(hit.transform.name);
            if(hit.collider.tag == "interactable"){
                MainGravityScript script = hit.collider.gameObject.GetComponent<MainGravityScript>();
                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                //Add object as target1 if null
                if(firstTar == false){
                    script1 = script;
                    rb1 = rb;
                    script1.glowOn();
                    firstTar = true;
                } else if (secondTar == false){ // else add to target2
                    script2 = script;
                    rb2 = rb;
                    script2.glowOn();
                    secondTar = true;
                } else if(firstTar && secondTar){ //else, if there are already two targets, then deselect both
                    if(script1 && script2){
                        script1.glowOff();
                        script1.gravOn();
                        script2.glowOff();
                        script2.gravOn();
                        script1 = null;
                        script2 = null;
                        rb1 = null;
                        rb2 = null;
                        gravBarScript.hide();
                        firstTar = false;
                        secondTar = false;
                    } else if(script1 && pScript){ 
                        script1.glowOff();
                        script1.gravOn();
                        script1 = null;
                        rb1 = null;
                        firstTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        secondTar = false;
                        pScript = null;
                    } else if(script2 && pScript){
                        script2.glowOff();
                        script2.gravOn();
                        script2 = null;
                        rb2 = null;
                        firstTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        secondTar = false;
                        pScript = null;
                    } else if (pScript){
                        firstTar = false;
                        secondTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        pScript = null;
                    }
                }
                if(firstTar && secondTar){ //if shooting the same object two times, antigrav it (straight up)
                    if(script1 != null && script1 == script2){ //same object
                        //script1.glowOn();
                        script1.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    } else if (script1 != script2 && pScript == null){ //2 distinct objects, not including player
                        script1.gravOff();
                        script2.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    } else if (script1 != script2 && pScript != null){ //1 object and the player
                        pScript.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                        if(script1 != null){
                            script1.gravOff();
                        } else {
                            script2.gravOff();
                        }
                    } else if (pScript != null && script1 == null && script2 == null){ //only player
                        pScript.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    }
                }
            } else if(hit.collider.tag == "Mirror"){ //handle mirrors
                PlayerGravityScript script = GetComponent<PlayerGravityScript>();
                //Rigidbody rb = GetComponent<Rigidbody>();
                if(!firstTar){
                    firstTar = true;
                    pScript = script;
                    pScript.glowOn();
                } else if (!secondTar){ // else add to target2
                    secondTar = true;
                    pScript = script;
                    pScript.glowOn();
                } else if(firstTar && secondTar){ //else, if there are already two targets, then deselect both
                   if(script1 && script2){
                        script1.glowOff();
                        script1.gravOn();
                        script2.glowOff();
                        script2.gravOn();
                        script1 = null;
                        script2 = null;
                        rb1 = null;
                        rb2 = null;
                        gravBarScript.hide();
                        firstTar = false;
                        secondTar = false;
                    } else if(script1 && pScript){ 
                        script1.glowOff();
                        script1.gravOn();
                        script1 = null;
                        rb1 = null;
                        firstTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        secondTar = false;
                        pScript = null;
                    } else if(script2 && pScript){
                        script2.glowOff();
                        script2.gravOn();
                        script2 = null;
                        rb2 = null;
                        firstTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        secondTar = false;
                        pScript = null;
                    } else if (pScript){
                        firstTar = false;
                        secondTar = false;
                        pScript.glowOff();
                        pScript.gravOn();
                        pScript = null;
                    }
                }
                if(firstTar && secondTar){ //if shooting the same object two times, antigrav it (straight up)
                    if(script1 != null && script1 == script2){ //same object
                        //script1.glowOn();
                        script1.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    } else if (script1 != script2 && pScript == null){ //2 distinct objects, not including player
                        script1.gravOff();
                        script2.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    } else if (script1 != script2 && pScript != null){ //1 object and the player
                        pScript.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                        if(script1 != null){
                            script1.gravOff();
                        } else {
                            script2.gravOff();
                        }
                    } else if (pScript != null && script1 == null && script2 == null){ //only player
                        pScript.gravOff();
                        gravMultiplier = 0f;
                        gravBarScript.show();
                    }
                }
            } else {
                Debug.Log(hit.collider.tag);
                if(script1 && script2){ //else, if there are already two targets, then deselect both
                    script1.glowOff();
                    script1.gravOn();
                    script2.glowOff();
                    script2.gravOn();
                    script1 = null;
                    script2 = null;
                    rb1 = null;
                    rb2 = null;
                    gravBarScript.hide();
                }
            }
        } else {
            Debug.Log("Miss");
             /*if(script1 && script2){ //else, if there are already two targets, then deselect both
                    script1.glowOff();
                    script1.gravOn();
                    script2.glowOff();
                    script2.gravOn();
                    script1 = null;
                    script2 = null;
                    rb1 = null;
                    rb2 = null;
                    gravBarScript.hide();
             }*/
        }
    }
}
