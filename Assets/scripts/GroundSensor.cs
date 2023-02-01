using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3 )
        {
            isGrounded = false;
        }
        controller.anim.SetBool("ItsJumping", false);
    }
}
