using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{

    private Animator animator;
    private Rigidbody player;

    private Vector3 targetRot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = transform.parent.gameObject.GetComponent<Rigidbody>();

        targetRot = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey("space"))
        {
            animator.SetBool("isJumping", true);
        }
        if (player.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            targetRot.y = -90;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            targetRot.y = 90;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            targetRot.y = 0;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            targetRot.y = 180;
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0)
        {
            targetRot.y = 45;
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0)
        {
            targetRot.y = -45;
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0)
        {
            targetRot.y = 135;
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0)
        {
            targetRot.y = -135;
        }

        transform.eulerAngles = targetRot;
    }
    
}
