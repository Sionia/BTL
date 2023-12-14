using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHealth : MonoBehaviour
{
    public int point;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Health(point);
            Destroy(gameObject);
        }
    }
}
