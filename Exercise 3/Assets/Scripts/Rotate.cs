using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotationRate = -360f / 60f;

    [SerializeField]
    bool useDeltaTime;

    // Update is called once per frame
    void Update()
    {
        if (useDeltaTime)
        {
            transform.Rotate(0f, 0f, rotationRate * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, rotationRate);
        }
    }
}