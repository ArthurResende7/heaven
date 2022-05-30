using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    private Transform trans;
    private float speed = 5.0f;
    private Vector3 inPos;
    private bool justTurned;

    public string direction;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        inPos = trans.position;
    }

    private void FixedUpdate() 
    {
        if (direction == "forward")
        {
            trans.position += Vector3.forward * speed * Time.deltaTime;
            if ((trans.position.z > inPos.z + 10 || trans.position.z < inPos.z - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.z < inPos.z + 1 && trans.position.z > inPos.z - 1)
            {
                justTurned = false;
            }
        }

        if (direction == "back")
        {
            trans.position -= Vector3.forward * speed * Time.deltaTime;
            if ((trans.position.z > inPos.z + 10 || trans.position.z < inPos.z - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.z < inPos.z + 1 && trans.position.z > inPos.z - 1)
            {
                justTurned = false;
            }
        }

        if (direction == "right")
        {
            trans.position += Vector3.right * speed * Time.deltaTime;
            if ((trans.position.x > inPos.x + 10 || trans.position.x < inPos.x - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.x < inPos.x + 1 && trans.position.x > inPos.x - 1)
            {
                justTurned = false;
            }
        }

        if (direction == "left")
        {
            trans.position -= Vector3.right * speed * Time.deltaTime;
            if ((trans.position.x > inPos.x + 10 || trans.position.x < inPos.x - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.x < inPos.x + 1 && trans.position.x > inPos.x - 1)
            {
                justTurned = false;
            }
        }

        if (direction == "up")
        {
            trans.position += Vector3.up * speed * Time.deltaTime;
            if ((trans.position.y > inPos.y + 10 || trans.position.y < inPos.y - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.y < inPos.y + 1 && trans.position.y > inPos.y - 1)
            {
                justTurned = false;
            }
        }

        if (direction == "down")
        {
            trans.position -= Vector3.up * speed * Time.deltaTime;
            if ((trans.position.y > inPos.y + 10 || trans.position.y < inPos.y - 10) && !justTurned)
            {
                speed *= -1;
                justTurned = true;
            }
            if (trans.position.y < inPos.y + 1 && trans.position.y > inPos.y - 1)
            {
                justTurned = false;
            }
        }
    }
}
