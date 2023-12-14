using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rb;
    public SpriteRenderer characterSR;
    public Animator animator;

    public Vector3 moveInput;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        if(moveInput.x != 0)
        {
            if (moveInput.x < 0)
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(1, 1, 0);
        }
    }
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDam(damage);
    }
}
