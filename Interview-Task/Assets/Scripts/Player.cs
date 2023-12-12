using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    Rigidbody2D playerRig;
    Animator playerAnimator;
    float horizontal;
    float vertical;

    void Start()
    {
        playerRig = this.GetComponent<Rigidbody2D>();
        playerAnimator = this.GetComponent<Animator>();
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        Movement();
        FlipPlayer();
    }

    void Movement()
    {
        playerRig.velocity = new Vector2(horizontal, vertical) * speed;
        if (horizontal == 0 && vertical == 0)
        {
            playerAnimator.SetBool("Walking", false);
        }
        else
        {
            playerAnimator.SetBool("Walking", true);
        }
    }
    void FlipPlayer()
    {
        if (horizontal < 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if(horizontal > 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
