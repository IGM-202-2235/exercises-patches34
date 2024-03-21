using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Vector3 position, direction, velocity, acceleration;

    [SerializeField]
    float mass = 1f, maxSpeed;

    //  Things that might go away
    public bool useFriction, useGravity;
    public float coeff, gravityScalar;

    Vector2 screenSize = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (useGravity)
        {
            ApplyGravity(Vector3.down * gravityScalar);
        }
        if (useFriction)
        {
            ApplyFriction();
        }

        // Calculate the velocity for this frame - New
        velocity += acceleration * Time.deltaTime;

        position += velocity * Time.deltaTime;

        // Grab current direction from velocity  - New
        direction = velocity.normalized;

        CheckForScreenEdgeBounce();

        transform.position = position;


        // Zero out acceleration - New
        acceleration = Vector3.zero;
    }


    //  Force Methods
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    public void ApplyGravity(Vector3 gravity)
    {
        acceleration += gravity;
    }

    public void ApplyFriction()
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;

        ApplyForce(friction);
    }


    void CheckForScreenEdgeBounce()
    {
        if (position.x > screenSize.x ||
            position.x < -screenSize.x)
        {
            velocity.x *= -1f;
        }

        if (position.y > screenSize.y ||
            position.y < -screenSize.y)
        {
            velocity.y *= -1f;
        }
    }
}
