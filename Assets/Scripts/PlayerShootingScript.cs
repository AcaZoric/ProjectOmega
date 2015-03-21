using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour
{
    // uzimace se u odnosu na selektovano oruzije
    public int damage = 20;
    public float fireRate = 0.15f;//vreme izmenju ispaljivanja dva metka
    public float range = 100f;// i ostalo///

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer bulletLine;
    float effectsTime = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        bulletLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1") && timer>=fireRate)
        {
            Shoot();
        }

        if(timer>= fireRate*effectsTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        bulletLine.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        bulletLine.enabled = true;
        bulletLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealthScript enemy = shootHit.collider.GetComponent<EnemyHealthScript>();
            if(enemy!=null)
            {
                enemy.TakeDamage(damage, shootHit.point);
            }
            bulletLine.SetPosition(1,shootHit.point);
        }
        else
        {
            bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
