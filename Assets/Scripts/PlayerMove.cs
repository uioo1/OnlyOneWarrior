using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6;
    public Collider2D attackTrigger;
    public Joystick joystick;
    private Rigidbody2D rb2d;
    private Vector2 moveVelocity;
    private Animator anim;
    private Quaternion quaternion;
    private bool attacking = false;
    private bool real_attackMotion = false;
    private bool attack_button_Pressed = false;
    private bool hited = false;
    private float attackTimer = 0;
    private float attackCd = 0.5f;

    


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        attackTrigger.enabled = false;
        quaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetBool("Attacking", attacking);

        if(attack_button_Pressed == true && attacking == false)
        {
            attacking = true;
            attackTimer = attackCd;            
        }

        if(real_attackMotion == false)
        {
            attackTrigger.enabled = false;
        }

        if(real_attackMotion == true && attacking == true)
        {
            attackTrigger.enabled = true;
            if(hited == false)
                SwordSoundManager.instance.PlaySwordAirSound();
        }

        if(attacking == true)
        {  
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        Vector2 moveInput = new Vector2(0f, 0f);

        if(joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f || joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        else
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        

        /* 
        if(moveInput.y <= -0.5 || moveInput.y >= 0.5) 
        {
            //moveVelocity = moveInput.normalized * (speed + 1.75f);
            moveVelocity = moveInput * (speed + 1.75f);
            Debug.Log("Speed boost");
        }
        else
        {
            //moveVelocity = moveInput.normalized * speed;
            moveVelocity = moveInput * speed;
        }
        */

        moveVelocity = moveInput * speed;

        float cur_speed = Mathf.Abs(moveVelocity.x) + Mathf.Abs(moveVelocity.y);

        anim.SetFloat("Speed", cur_speed);

        if(moveVelocity.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(moveVelocity.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);            
        }

        transform.rotation = quaternion;
        if(cur_speed <= 0.001)
        {
            moveVelocity = new Vector3(0f, 0f, 0f);
            rb2d.angularVelocity = 0;
        }
        attack_button_Pressed = false;
        real_attackMotion = false;
        hited = false;
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Hit()
    {
        hited = true;
        Debug.Log("hit");
        SwordSoundManager.instance.PlaySwordPersonSound();
    }

    public void PressAttack()
    {
        attack_button_Pressed = true;
    }

    public void RealAttackMotoin()
    {
        real_attackMotion = true;
    }

    public void EndRealAttack()
    {
        real_attackMotion = false;
    }
}
