using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Playgame ()
   {

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   }
   public void Playtutorial ()
   {

        SceneManager.LoadScene(6);
   }

    public void QuitGame ()
    {
        
        Debug.Log("QUIT!");

        Application.Quit();

    }

}

