using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 5.5f;
    public float jumpForce = 3f;
    string texto = "Hello World";
    public SpriteRenderer spriteRender;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
   public  Animator anim;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();

        playerHealth = 10;
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime; 

        //transform.position +=

        if(horizontal < 0) 
        {
            spriteRender.flipX = true;
             anim.SetBool("IsRunning", true);
        }  
        else if(horizontal > 0) 
        {
            spriteRender.flipX = false;
             anim.SetBool("IsRunning", true);
        }
        else
        {
             anim.SetBool("IsRunning", false);
        }
    
          if(Input.GetButtonDown("Jump") && sensor.isGrounded)
          {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("ItsJumping",true);
          }
    }

    public void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);

    }
        
}
