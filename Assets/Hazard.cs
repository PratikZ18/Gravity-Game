using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameManagerScript gameManager;
    //private playermovement pMovement;

    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        /*if(!pMovement){
            pMovement = GameObject.Find("Player").GetComponent<playermovement>();
        }*/
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            gameManager.EndGame();
            other.gameObject.GetComponent<SFPSC_PlayerMovement>().enabled = false;
        }
    }
}
