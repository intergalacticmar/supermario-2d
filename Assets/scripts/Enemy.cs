using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    float horizontal = 1;

    Animator anim;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;
    sfxmanager sfxmanager;
    soundmanager soundmanager;

    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rBody = GetComponent<Rigidbody2D>();

        sfxmanager = GameObject.Find("sfxmanager").GetComponent<sfxmanager>();
        soundmanager = GameObject.Find("soundmanager").GetComponent<soundmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    public void Die()
    {
        anim.SetBool("IsDead", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Mario muerto");
            Destroy(other.gameObject);
            soundmanager.StopBGM();
            sfxmanager.MarioDeath();
        }

        if(other.gameObject.tag == "CollisionGoomba")
        {
            if(horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;
            }
        }
    }
}