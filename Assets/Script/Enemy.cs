using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTF;
    public int minDamage;
    public int maxDamage;
    PlayerHealth health;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    public GameObject player;
    public float distanceBetween;
    private float distance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        Vector2 force = direction * speed * Time.deltaTime;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (force.x != 0){
                if (force.x < 0)
                    transform.localScale = new Vector3(-1, 1, 0);
                else
                    transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health = collision.gameObject.GetComponent<PlayerHealth>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        health = collision.GetComponent<PlayerHealth>();
    //        InvokeRepeating("DamagePlayer",0,0.1f);
    //    }
    //}

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        health.TakeDam(damage);
    }
    public void TakeDamage(int damage)
    {
        health.TakeDam(damage);
    }
}
