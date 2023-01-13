using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private bool isFacing = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        bool facingRight = false;
        bool facingLeft = false;
        //bool isFacing = false;


        if ((Input.GetKey("d") || Input.GetKey("right")) )
        {
            transform.localScale = new Vector3(-2, 2, 2);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //isFacing = false;
            facingRight = true;

        }
        if ((Input.GetKey("a") || Input.GetKey("left")) )
        {
            transform.localScale = new Vector3(2, 2, 2);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isFacing = true;
            facingLeft = true;

        }
        if (Input.GetKeyDown("w") || Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (transform.rotation.y > 0f && facingRight)
            {
                //Debug.Log("facingR = " + facingRight);
                //Debug.Log("facingL = " + facingLeft);
                //Debug.Log("isFacing = " + isFacing);

                transform.localScale = new Vector3(-1 * transform.localScale.x , 2, 2);
            }
            if (transform.rotation.y > 0f && facingLeft)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x , 2, 2);
            }

        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
