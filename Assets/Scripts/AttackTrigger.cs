using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", damage);
            gameObject.SendMessageUpwards("Hit");
        }
    }
}
