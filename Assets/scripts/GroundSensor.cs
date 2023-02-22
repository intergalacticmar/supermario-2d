using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
<<<<<<< HEAD
    private PlayerController controller;
    public bool isGrounded;

    SFXManager SFXManager;
    SoundManager SoundManager;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();  

        SFXManager = GameObject.Find("SFXMnager").GetComponent<SFXManager>();
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = true;     
         controller.anim.SetBool("IsJumping", false);
        } else if(other.gameObject.layer==6)
        {
            Debug.Log("Goomba muerto");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "DeadZone"){
            Debug.Log("Estoy muerto");
        }
        SFXManager.GoombaDeath();
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer==3)
        {
          isGrounded = true;     
          controller.anim.SetBool("IsJumping", false);
=======
    private playercontroler controller;
    public bool isGrounded;


    void Awake() 
    {
        controller = GetComponentInParent<playercontroler>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controller.anim.SetBool("ItsJumping", false);
        }
         else if(other.gameObject.layer == 3 )

         {
            Debug.Log("Goomba muerto");
            Destroy(other.gameObject);
         }
         

        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estoy muerto");
>>>>>>> 3acf1a6691127e75d54199de0c6ba66de8a6b3b8
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
<<<<<<< HEAD
        if(other.gameObject.layer==3)
        {
         isGrounded = false;
         controller.anim.SetBool("IsJumping", true);     
        }
=======
        if(other.gameObject.layer == 3 )
        {
            isGrounded = false;
        }
        controller.anim.SetBool("ItsJumping", false);
>>>>>>> 3acf1a6691127e75d54199de0c6ba66de8a6b3b8
    }
}
