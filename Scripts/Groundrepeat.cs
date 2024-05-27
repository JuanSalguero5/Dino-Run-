using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundrepeat : MonoBehaviour
{
    private float spriteWidht;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidht = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidht)
        {
            transform.Translate(Vector2.right * 2f * spriteWidht);
        }
    }
}
