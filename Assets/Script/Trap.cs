using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator ani;
    private SpriteRenderer spriteRend;
    private bool trigger;
    private bool active;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!trigger)
            {
                StartCoroutine(ActiveTrap());
            }
            if (active)
            {
                collision.GetComponent<PlayerHealth>().TakeDam(damage);
            }
                
        }
    }
    private IEnumerator ActiveTrap()
    {
        trigger = true;
        yield return new WaitForSeconds(activationDelay);
        active = true;
        ani.SetBool("Active",true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        trigger = false;
        ani.SetBool("Active", false);
    }
}
