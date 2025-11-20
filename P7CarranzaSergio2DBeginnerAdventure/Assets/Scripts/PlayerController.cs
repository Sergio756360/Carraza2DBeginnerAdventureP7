using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControllerTutorialUpdates : MonoBehaviour
{
    public InputAction MoveAction;

    Rigidbody2D rigidbody2d;
    Vector2 move;


    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        //Vector2 position = (Vector2)transform.position + move * 0.1f * Time.deltaTime;
        //Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;

        MoveAction.Enable();

        
    }

    // Update is called once per frame
    void Update()
    {
        {
            
           rigidbody2d = GetComponent<Rigidbody2D>();
        }

        //void FixedUpdate()
        {

            //Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.delttatime; 
            //rigidbody2d.MovePosition(position);

        }



         Vector2 move = MoveAction.ReadValue<Vector2>();
         Debug.Log(move);
         Vector2 position = (Vector2)transform.position + move * 3f * Time.deltaTime;
         transform.position = position;
        
       

    }
}      

