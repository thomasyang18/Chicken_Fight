using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggProjectileBehavior : MonoBehaviour
{
    private int player;
    void Update() {
    }

    

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("egg hit something");

        if (other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            //Debug.Log("egg hit floor");
        }
    }

    
}
