using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    public string name;

    [SerializeField]
    int favNumber = 34;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    GameObject thingPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello There");

        //meshRenderer.enabled = false;

        for(int i = 0; i < 10; i++)
        {
            Instantiate(thingPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(favNumber);
    }

    private void OnEnable()
    {
        
    }
}
