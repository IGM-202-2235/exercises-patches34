using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracker : MonoBehaviour
{
    [SerializeField]
    PhysicsObject physicsObject;

    public Vector3 mousePos, mouseForce;

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = transform.position.z;

        mouseForce = mousePos - transform.position;

        physicsObject.ApplyForce(mouseForce);
    }
}
