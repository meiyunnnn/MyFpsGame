using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static event System.Action<GameObject> OnEnemyDied;

    public float hp = 50f;

    public void TakeDamage(float amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnEnemyDied?.Invoke(gameObject);  // ส่ง Event ไปให้ใครอยากรู้
        Destroy(gameObject);
    }
}