using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    public int startingHP = 100;
    public int currentHP;
    public Slider healthSlider;
    public Image dmgImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    PlayerMovementScript playerMovement;
    bool isDead;
    bool damaged;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
        currentHP = startingHP;
    }

    void Update()
    {
        if (damaged)
        {
            dmgImage.color = flashColour;
        }
        else
        {
            dmgImage.color = Color.Lerp(dmgImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int x)
    {
        damaged = true;
        currentHP -= x;
        healthSlider.value = currentHP;

        if (currentHP <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        playerMovement.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponentInChildren<PlayerShootingScript>().enabled = false;
        transform.localEulerAngles = new Vector3(0f, 0f, 90f);
    }
}
