using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EggBasketBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerStats curPlayer;
    private SpriteRenderer sprite;
    private Collider2D trigger;
    private Transform trans;
    private float cd_time;
    public float cooldown = 2f;
    private bool startCD;
    private int curNumber = -1;
    void Start()
    {
        trans = GetComponent<Transform>();
        trigger = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        cd_time = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (curPlayer != null) {
            if (!curPlayer.getHasEggBasket())
            {
                trans.position = curPlayer.GetComponent<Transform>().position;
                curPlayer = null;
                sprite.enabled = true;
                trigger.enabled = true;
                cd_time = 0f;
                startCD = true;
            }
        }
        


        if (startCD) {
            cd_time += Time.deltaTime;
        }
        Debug.Log("cd time: " + cd_time + ", cooldown: "  + cooldown + ", cd_time < cooldown: " + (cd_time < cooldown));
     }

    void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("cooldown vs cd: " + cd_time + " " + cooldown);
        if (cd_time < cooldown && other.gameObject.GetComponent<PlayerStats>().playerNumber() == curNumber) {
            return;
        }
        if (other.gameObject.tag == "Player") {
            curPlayer = other.gameObject.GetComponent<PlayerStats>();
            curPlayer.setHasEggBasket(true);
            curNumber = curPlayer.playerNumber();
            trigger.enabled = false;
            sprite.enabled = false;
            startCD = false;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        // Debug.Log("cooldown vs cd: " + cd_time + " " + cooldown);
        if (cd_time < cooldown && other.gameObject.GetComponent<PlayerStats>().playerNumber() == curNumber)
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            curPlayer = other.gameObject.GetComponent<PlayerStats>();
            curPlayer.setHasEggBasket(true);
            curNumber = curPlayer.playerNumber();
            trigger.enabled = false;
            sprite.enabled = false;
            startCD = false;
        }
    }
}
