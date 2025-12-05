using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemyController : MonoBehaviour
{
    Animator animator;

    //Public Variables
    public bool vertical;
    public float speed;
    public float changeTime = 3.0f;


    //Private varibales
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();

    }

    //Update is called every frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    // FixedUpdate has the same cell rate as the physics system   
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + speed * Time.deltaTime * direction;
        }
        else
        {
            position.x = position.x + speed * Time.deltaTime * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2d.MovePosition(position);

      //void OnTriggerEnter2D(Collider2D other)
      {
        //PlayerController player = other.gameObject.GetComponent<PlayerController>();

         //if (player!= null)
         {
           //player.ChangeHealth(-1);
         }

      }
    }
  


}
