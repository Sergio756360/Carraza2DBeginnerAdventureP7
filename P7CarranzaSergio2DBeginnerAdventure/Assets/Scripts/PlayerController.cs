using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//Vector2 moveDirection = new Vector2(1, 0);
public class PlayerControllerTutorialUpdates : MonoBehaviour
{
    Animator animator;
    public InputAction MoveAction;

    Rigidbody2D rigidbody2d;
    Vector2 move;

    public float speed = 3.0f;

    public int maxHealth = 5;
    int currentHealth;

    // Variables related to temporary invincibility
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    public int health { get { return currentHealth; } }
    //int currentHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        //Vector2 position = (Vector2)transform.position + move * 0.1f * Time.deltaTime;
        //Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;

        MoveAction.Enable();
        //rigidbody2d = GetComponent<Rigidbody2D>();
        //currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            //if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                //moveDirection.Set(move.x, move.y);
                //moveDirection.Normalize();
            }

            //animator.SetFloat("Look X", moveDirection.x);
            //animator.SetFloat("Look Y", moveDirection.y);
            //animator.SetFloat("Speed", move.magnitude);

            rigidbody2d = GetComponent<Rigidbody2D>();
            //move = MoveAction.ReadValue<Vector2>();
            //Debug.Log(move);

           
           
        }

        if (isInvincible)
            damageCooldown -= Time.deltaTime;
        if (damageCooldown < 0)

        {
            isInvincible = false;

        }


        // FixedUpdate has the same call rate as the physics system

        //void FixedUpdate()
        {

            //Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime; 
            //rigidbody2d.MovePosition(position);

        }



         Vector2 move = MoveAction.ReadValue<Vector2>();
         Debug.Log(move);
         Vector2 position = (Vector2)transform.position + move * 3f * Time.deltaTime;
         transform.position = position;

        //public void ChangeHealth(int amount) 

        {

            //if (if (amount < 0))
            if (isInvincible)
                return;

            isInvincible = true;
            damageCooldown = timeInvincible;

        }

 
        {
            //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth); 
        }

       



    }
}      

