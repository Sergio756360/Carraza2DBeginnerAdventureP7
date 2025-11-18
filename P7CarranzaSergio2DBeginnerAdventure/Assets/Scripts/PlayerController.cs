using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControllerTutorialUpdates : MonoBehaviour
{
    public InputAction LeftAction;
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

        LeftAction.Enable();
        if (LeftAction.IsPressed())
        {
            //Horizontal = -1.0;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        {

            rigidbody2d = GetComponent<Rigidbody2D>();
            Debug.Log(move);

        } 

        float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f; 
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }

        Debug.Log(horizontal);

        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }
        Debug.Log(vertical);

        Vector2 position = transform.position;
        position.x = position.x + 5.0f * horizontal * Time.deltaTime;
        position.y = position.y + 5.0f * vertical * Time.deltaTime;
        transform.position = position;

        {
            Vector2 move = MoveAction.ReadValue<Vector2>();
            Debug.Log(move);
            //Vector2 position = (Vector2)transform.position + move * 0.1f;
            transform.position = position;
        }
       

    }
}      

