using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //movement part
    public CharacterController controller;
    public Transform cam;
    public float speed = 12f;

    //gravity part
    public float gravity =-9.81f;
    Vector3 velocity;

    //ground check part
    //Please set layer of objects to groundc if you want them to act as ground or potentional 0
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGrounded;
    //A - to handle antigrav
    private PlayerGravityScript playerGravScript;
    private bool usingPlayerGravScript = false;

    //jumping
    public float jumpheight = 3f;

    //restarting level if falling too much
    private GameManagerScript gameManagerScript;
    private Transform playerTransform;

    //A - handling antigrav
    void Start(){
        if(GetComponent<PlayerGravityScript>()){
            playerGravScript = GetComponent<PlayerGravityScript>();
            usingPlayerGravScript = true;
        }
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        playerTransform = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //movement part
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //gravity part
        
        //A - checking if gravity is enabled for player
        if((usingPlayerGravScript && playerGravScript.grav) || !usingPlayerGravScript){
            velocity.y += gravity * Time.deltaTime;
        }

       controller.Move(velocity * Time.deltaTime);


        //ground check part
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0f )
        {
            velocity.y =0f;
        }

        //jump function
        if (   Input.GetButton("Jump") && isGrounded    )
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        //check if player falls too much
        if(playerTransform.position.y < -5){
            gameManagerScript.EndGame();
        }




    }
    
}