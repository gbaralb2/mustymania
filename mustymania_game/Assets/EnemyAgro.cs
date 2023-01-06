using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange) 
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
       // print("distToPlayer: " + distToPlayer);

 
    }

    void ChasePlayer()
    {
       // throw new NotImplementedException();
       if (transform.position.x < player.position.x) 
       {
            rb2d.velocity = new Vector2(moveSpeed, 0);  //left side so moove right
            transform.localScale = new Vector2(4, 4);
        }
       else //if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);//right side so move left
            transform.localScale = new Vector2(-4, 4);
        }
    }
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
