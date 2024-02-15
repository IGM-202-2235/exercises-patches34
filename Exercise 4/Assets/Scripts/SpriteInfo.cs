using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public Vector3 min, max;

    public float radius;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;

        radius = spriteRenderer.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if (spriteRenderer != null)
        {
            Gizmos.DrawWireCube(transform.position, spriteRenderer.bounds.size);
        }



        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
