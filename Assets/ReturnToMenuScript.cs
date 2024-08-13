
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuScript : MonoBehaviour
{
    public void returnToMainMenu(){
        SceneManager.LoadScene(0);
        //Debug.Log("Hi!");
    }
}
