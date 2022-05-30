using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMove : MonoBehaviour
{

    public GameObject player;
    public int followThreshold;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 2)
        {
            animator.SetBool("AttackPlayer", true);
            animator.SetBool("PlayerNearby", false);
        }
        if (dist > 2 && dist <= followThreshold)
        {
            animator.SetBool("AttackPlayer", false);
            animator.SetBool("PlayerNearby", true);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05f);
            transform.LookAt(player.transform);
        }
        if (dist > followThreshold)
        {
            animator.SetBool("AttackPlayer", false);
            animator.SetBool("PlayerNearby", false);
            if (!transform.position.Equals(startPosition))
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.05f);
            }
        }
    }
}
