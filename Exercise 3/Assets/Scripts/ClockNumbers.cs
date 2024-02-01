using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    TextMesh clockPrefab;

    [SerializeField]
    float clockRadius = 2.16f;

    // Start is called before the first frame update
    void Start()
    {
        TextMesh newClockNum = Instantiate(clockPrefab);

        //newClockNum.GetComponent<TextMesh>();

        newClockNum.text = "12";

        Vector3 position = new Vector3(0, clockRadius, 0);

        newClockNum.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
