using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float playerSpeed = 50f;
    public float maxSpeed = 3;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if(rb2d.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(rb2d.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);            
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.75f;
        easeVelocity.y *= 0.75f;
        easeVelocity.z = 0f;

        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb2d.velocity = easeVelocity;


        rb2d.AddForce((Vector2.right * playerSpeed) * horizon);
        rb2d.AddForce((Vector2.up * playerSpeed) * vertical);

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.y > maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);
        }

        if(rb2d.velocity.y < -maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -maxSpeed);
        }
        
    }
}
