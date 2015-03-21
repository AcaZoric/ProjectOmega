using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour
{
    public int startingHP = 100;
    public int currentHP;
    public int value = 10;

    bool isDead;

    void Awake()
    {
        currentHP = startingHP;
    }

    public void TakeDamage(int x, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHP -= x;

        if (currentHP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        GetComponent<CapsuleCollider>().isTrigger = true;
        Destroy(gameObject);
    }
}
