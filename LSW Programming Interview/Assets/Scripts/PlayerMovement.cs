using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.localScale = new Vector3(-2, 2, 2);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.localScale = new Vector3(2, 2, 2);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            //transform.localScale = new Vector3(-1 * transform.localScale.x , 2, 2);

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
