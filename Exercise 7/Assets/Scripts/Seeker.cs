using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        physicsObject.ApplyForce(Seek(Vector3.zero));
    }
}
