using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return; 
        }
        //check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }
        
        //add to the player's score
        GameManager.inst.IncrementScore();
        //destroy this coin object 
        Destroy(gameObject);
    }

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0,0,turnSpeed * Time.deltaTime);
        
    }
}
