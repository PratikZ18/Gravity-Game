using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisibilityScript : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //show bar
    public void show(){
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //hide bar
    public void hide(){
        canvasGroup.alpha = 0f; 
        canvasGroup.blocksRaycasts = false;
    }
}
