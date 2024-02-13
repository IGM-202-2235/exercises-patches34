using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> sprites = new List<SpriteInfo>();


    // Update is called once per frame
    void Update()
    {
        
    }

    bool AABBCollisionCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return false;
    }

    bool CircleCollisionCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return false;
    }
}
