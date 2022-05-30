using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;

    private Vector3 startPosition;

    private float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    
    private float jumpAmount = 15.0f;
    private bool jumping;
    private int jumpTimes;

    public float gravityScale = 5.0f;

    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        startPosition = new Vector3(0, 4, 0);
        jumping = false;
        jumpTimes = 0;

        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed * -1;
        verticalInput = Input.GetAxis("Vertical") * speed;
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes < 2)
        {
            jumping = true;
            jumpTimes++;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(verticalInput, rb.velocity.y, horizontalInput);
        if (jumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
            jumping = false;
        }
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void OnCollisionEnter(Collision other)
    {
        jumpTimes = 0;
        if (!other.gameObject.CompareTag("Checkpoint") && !other.gameObject.CompareTag("Key"))
        {
            transform.SetParent(other.transform);
        }
        if (other.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish") && hasKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        transform.SetParent(null);
    }

}
