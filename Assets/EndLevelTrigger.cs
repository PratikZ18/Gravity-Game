
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter(){
        gameManager.CompleteLevel();
    }
}
