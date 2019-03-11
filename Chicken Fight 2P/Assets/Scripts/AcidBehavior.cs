using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBehavior : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerStats>().takeDamage();
        }
    }
}
