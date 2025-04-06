using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D cicle;
    public GameObject collected;
    public int score;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cicle = GetComponent<CircleCollider2D>();
        
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cicle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;

            Destroy(gameObject, 0.3f);
        }
    }
}
