using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTutorialUpdates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        
        Vector2 position = transform.position;
             
        position.x = position.x + 0.1f;

        transform.position = position;
    }
}

