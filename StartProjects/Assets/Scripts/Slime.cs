using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slime : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = new Vector2(speed, rig.linearVelocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
            
        }
    }


    bool playerDestroyed = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            Debug.Log(height);

            if (height > 0f && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                //boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.05f);
                
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
            
        }
    }
}
