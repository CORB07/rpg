using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocation : MonoBehaviour
{

    public float _newplayposx = 0;
    public float _newplayposy = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: make sure it triggers with PLAYER only
        GameObject otherObj = other.gameObject;
        Debug.Log("Triggered with: " + otherObj);


        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(_newplayposx, _newplayposy, 0);
        }
    }
}