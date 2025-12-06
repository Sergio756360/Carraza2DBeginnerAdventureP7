using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//Vector2 moveDirection = new Vector2(1, 0);
public class PlayerController : MonoBehaviour
{
    public InputAction talkAction;
    AudioSource audioSource;

    bool broken = true;
    Animator animator;
    public InputAction MoveAction;
    public GameObject projectilePrefab;

    Rigidbody2D rigidbody2d;
    Vector2 move;
    Vector2 moveDirection = new Vector2(1, 0);

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
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        currentHealth = maxHealth;

        talkAction.Enable();

        audioSource = GetComponent<AudioSource>(); 


    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();


        {
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                moveDirection.Set(move.x, move.y);
                moveDirection.Normalize();
            }

            animator.SetFloat("Look X", moveDirection.x);
            animator.SetFloat("Look Y", moveDirection.y);
            animator.SetFloat("Speed", move.magnitude);


            if (Input.GetKeyDown(KeyCode.X))
            {
                FindFriend();
            }

            void FindFriend()
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                    NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                    if (character != null)
                    {
                        UIHandler.instance.DisplayDialogue();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Launch();
            }



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



         move = MoveAction.ReadValue<Vector2>();
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

            //animator.SetTrigger("Hit");

        }

 
        {
            //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth); 
        }

        void Launch()
        {
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(moveDirection, 300);
            animator.SetTrigger("Launch");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (!broken)
        {
            return;
        }

        //public void Fix ()
        {
            broken = false;
            rigidbody2d.simulated = false;
        }

        

        //if (hit.collider != null)
        {
            //Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}      

