using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        //controller.PlaySound(collectedClip);
        //PlayerController controller = other.GetComponent<PlayerController>();
        //controller.ChangeHealth();
        Destroy(gameObject);
       
    }

    //if (controller != null && controller.health < controller.maxHealth)



    // Update is called once per frame



}
