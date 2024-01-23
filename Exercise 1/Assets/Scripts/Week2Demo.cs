using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    public string name;

    public int rand = 347;

    [SerializeField]
    int favNumber = 34;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    GameObject thing;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hello there!");

        //meshRenderer.materials = null;

        for(int i = 0; i < 10; i++)
        {
            Instantiate(thing);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hey!");
        Debug.Log(favNumber);
     }
}
