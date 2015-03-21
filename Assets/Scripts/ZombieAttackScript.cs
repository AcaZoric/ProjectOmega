using UnityEngine;
using System.Collections;

public class ZombieAttackScript : MonoBehaviour
{

    public float attackSpeed = 0.5f;
    public int attackDmg = 10;

    EnemyHealthScript enemyHP;
    GameObject player;
    PlayerHealthScript playerHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthScript>();
        enemyHP = GetComponent<EnemyHealthScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=attackSpeed && playerInRange && enemyHP.currentHP>0)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

        if(playerHealth.currentHP>0)
        {
            playerHealth.TakeDamage(attackDmg);
        }
    }
}
