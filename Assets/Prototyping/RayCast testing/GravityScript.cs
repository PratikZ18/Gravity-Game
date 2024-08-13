
using UnityEngine;

public class GravityScript : MonoBehaviour
{

    private bool hasGrav = true;
    public Rigidbody rb;
    public float antigravStrength = 100f;

    // Update is called once per frame
    void Update()
    {
        if(!hasGrav){
            rb.AddForce(0,antigravStrength, 0, ForceMode.VelocityChange);
        }
    }

    public void toggleGrav(){
        if(hasGrav){
            hasGrav = false;
            rb.useGravity = false;
        } else {
            hasGrav = true;
            rb.useGravity = true;
        }
    }
}
