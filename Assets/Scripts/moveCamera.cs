using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public float _newcamposx = 0;
    public float _newcamposy = 0;
    public float _newcamposz = -10;



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

        Camera.main.transform.position = new Vector3(_newcamposx, _newcamposy, _newcamposz);
    }
}