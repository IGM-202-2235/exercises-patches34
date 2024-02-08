using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition;

    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed;

    public Vector3 Diretion
    {
        set { direction = value.normalized; }
    }


    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        objectPosition += velocity;

        // Validate new calculated position

        // �Draw� this vehicle at that position
        transform.position = objectPosition;



        // Set the vehicle�s rotation to match the direction
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }

    }
}
