using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggProjectileBehavior : MonoBehaviour
{
    private int playerNum = -1;
    public PlayerStats player;
    void Start() {
        playerNum = player.playerNumber();
    }

    void Update() {
    }



    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("egg hit something");
        playerNum = player.playerNumber(); // this runs before start so add this into here too
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().playerNumber() != playerNum) { // basically if the player it hits is NOT itself
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            //Debug.Log("egg hit floor");
        }
    }

    
    
}
