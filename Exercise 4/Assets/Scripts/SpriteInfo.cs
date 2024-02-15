using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Vector3 min, max;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;

        radius = spriteRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, radius);


        Gizmos.color = Color.cyan;

        if (spriteRenderer != null)
        {
            Gizmos.DrawWireCube(transform.position, spriteRenderer.bounds.size);
        }
    }
}
