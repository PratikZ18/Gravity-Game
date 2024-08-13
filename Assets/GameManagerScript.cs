using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    bool gameHasEnded = false;
    //public GameObject completeLevelUI;
    public float restartDelay = 1f;

    public void CompleteLevel(){
        //completeLevelUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame(){
        if(gameHasEnded == false){
            gameHasEnded = true;
        }
        Invoke("Restart", restartDelay);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
