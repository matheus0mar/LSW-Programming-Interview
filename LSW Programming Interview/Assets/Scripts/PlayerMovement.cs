using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        bool facingRight = false;
        bool facingLeft = false;

        //Change player directions deppending on the button pressed -------------------------
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            facingRight = true;

        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            facingLeft = true;
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (transform.rotation.y > 0f && facingRight)
            {   
                transform.localScale = new Vector3(-1 * transform.localScale.x , 1, 1);
            }
            if (transform.rotation.y > 0f && facingLeft)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x , 1, 1);
            }
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Play movement animations-----------------
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        //Change player position----------------------------------------------------
        transform.position = transform.position + movement * speed * Time.deltaTime;

    }
}
