
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float range = 100f;
    public Camera playerCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            shoot();
        }
        
    }

    void shoot(){
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            if(hit.collider.tag == "interactable"){
                hit.collider.gameObject.GetComponent<GravityScript>().toggleGrav();
            } else {
                Debug.Log(hit.collider.tag);
            }
        } else {
            Debug.Log("Miss");
        }
    }
}
