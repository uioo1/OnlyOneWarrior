using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public Animator animator;
    public BoxCollider2D collider2D;
    private bool IsDied;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        collider2D = gameObject.GetComponent<BoxCollider2D>();
        curHealth = maxHealth;
        IsDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(curHealth <= 0)
            Die();
        animator.SetBool("Died", IsDied);
    }

    public void Damage(int damage)
    {
        if(IsDied == false)
        {
            curHealth -= damage;
            SoundManager.instance.PlayScream1Sound();
            gameObject.GetComponent<Animation>().Play("Red_Flash");
        }
    }

    public void Die()
    {
        IsDied = true;
        collider2D.isTrigger = true;
    }
}
