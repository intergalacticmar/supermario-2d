using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    void Awake() 
    {
        controller = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        controller.anim.SetBool("ItsJumping", false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
        controller.anim.SetBool("ItsJumping", false);
    }
}
