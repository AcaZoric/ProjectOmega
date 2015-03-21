using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 10f;

    Vector3 movement;
    Rigidbody player;
    int floor;
    float RayLength = 100f;

    void Awake()
    {
        player = GetComponent<Rigidbody>();
        floor = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");// GetAxisRaw: -1,0,1; digitalno da igrac ne bi polako ubrzavao nego odmah ide punom brzinom
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized*speed*Time.deltaTime; //da se igrac ne bi brze kretao diagonalno

        player.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit,RayLength,floor))
        {
            Vector3 playerMouse = floorHit.point - transform.position;
            playerMouse.y = 0f;

            Quaternion playerRotation = Quaternion.LookRotation(playerMouse);
            player.MoveRotation(playerRotation);

        }
    }
}
