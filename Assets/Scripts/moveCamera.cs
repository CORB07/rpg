using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj); 
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //TODO: make sure it triggers with PLAYER only
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }
}
