using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Vector3 position, direction, velocity, acceleration;

    public Vector3 Direction
    {
        get
        {
            return direction;
        }
    }

    [SerializeField]
    float mass, maxSpeed;


    //  things that might go away
    public bool useFriction, useGravity;
    public float frictionCoef = 0f;
    Vector2 screenSize = Vector2.zero;
    public float gravScale = 10f;

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
        if (useFriction)
        {
            ApplyFriction(frictionCoef);
        }

        if (useGravity)
        {
            ApplyGravity(Vector3.down * gravScale);
        }


        // Calculate the velocity for this frame - New
        velocity += acceleration * Time.deltaTime;

        CheckForScreenEdgeBounce();

        position += velocity * Time.deltaTime;

        // Grab current direction from velocity  - New
        direction = velocity.normalized;

        

        transform.position = position;

        // Zero out acceleration - New
        acceleration = Vector3.zero;
    }


    //  Force Methods
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="coeff">Must be above zero!</param>
    public void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();

        friction = friction * coeff;

        ApplyForce(friction);
    }

    public void ApplyGravity(Vector3 gravForce)
    {
        acceleration += gravForce;
    }


    void CheckForScreenEdgeBounce()
    {
        if (position.x > screenSize.x ||
            position.x < -screenSize.x)
        {
            velocity.x *= -1f;
            //acceleration.x *= -1f;
        }

        if (position.y > screenSize.y ||
            position.y < -screenSize.y)
        {
            velocity.y *= -1f;
            //acceleration.y *= -1f;
        }
    }
}
