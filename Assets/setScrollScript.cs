using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScrollScript : MonoBehaviour
{
    public MainShoot shootscript;
    public float maxY = 59f;
    public float minY = -141f;
    public float xPos = -349f;
    private RectTransform rectTransform;
    private float midPos;
    private float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        midPos = (maxY + minY)/2;
        deltaY = maxY - midPos;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = new Vector2(xPos, midPos + shootscript.getGravMultiplier()*deltaY);
    }
}
