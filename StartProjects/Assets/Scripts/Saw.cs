using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float Speed;
    public float moveTime;

    private bool dirRight = true; //direção inicial do saw (para direita)
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {
            //se verdadeiro, o saw vai pra direita
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            //se falso, o saw vai pra esquerda
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        
        //adiciona o tempo que passou desde o último frame ao timer
        if(timer >= moveTime)
        {
            //se o tempo de movimento for maior que o tempo definido, inverte a direção
            dirRight = !dirRight;
            timer = 0f; //reseta o timer
        }
        
    }
}
