using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Bird : MonoBehaviour
{

    [Header("Player settings")]
    [InspectorName("Jump force")]
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        // Left click check
        if (Input.GetMouseButtonDown(0))
        {
            // Reset velocity speed
            rb2d.velocity = Vector2.zero;
            // Let it jump with our speed
            rb2d.AddForce(new Vector2(0, upForce));
            // Lets animate it
            anim.SetTrigger("Flap");
        }
    }

    // OnCollisionEnter2D вызывается, когда данный элемент collider2D или rigidbody2D
    // касается другого элемента rigidbody2D или collider2D (только двухмерная физика)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameManager.instance.BirdDied();
    }




}
