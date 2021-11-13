using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Vector2 pos = this.transform.parent.transform.position;
            pos.x += 240;
            this.transform.parent.transform.position = pos;
        }
    }
}
