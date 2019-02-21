using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggProjectileBehavior : MonoBehaviour
{
    private int playerNum = -1;
    void Start() {
    }

    void Update() {
        
    }



    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().playerNumber() != playerNum) { // basically if the player it hits is NOT itself
            other.gameObject.GetComponent<PlayerStats>().takeDamage();
            Destroy(gameObject);
            // Debug.Log("I hit em");
        }
        if (other.gameObject.tag == "Floor")
        {
            //Debug.Log("egg hit floor");
            Destroy(gameObject);

        }

    }

    public void setPlayerNum(int p) {
        playerNum = p;
    }
    
}
