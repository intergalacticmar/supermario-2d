using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;

    sfxmanager sfxmanager;
    soundmanager soundmanager;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();  

        sfxmanager = GameObject.Find("sfxmanager").GetComponent<sfxmanager>();
        soundmanager = GameObject.Find("soundmanager").GetComponent<soundmanager>();
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
        sfxmanager.GoombaDeath();
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer==3)
        {
          isGrounded = true;     
          controller.anim.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer==3)
        {
         isGrounded = false;
         controller.anim.SetBool("IsJumping", true);     
        }
    }
}
