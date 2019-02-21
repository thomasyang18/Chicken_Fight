using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed= 1f;
    public float jumpForce = 1f;
    private float x;
    private Rigidbody2D rb;
    private bool airborne;
    private Transform trans;
    private float reloadTime;
    public float reloadDelay = 1f;
    public GameObject eggPrefab;
    public Transform eggSpawn;

    public int player;
    private string[] axes = {"HorizontalP" , "VerticalP" , "FireP" }; // 0 is horizontal, 1 is vertical, 2 is fire.
    public float maxSpeed = 10f;
    public AudioSource eggShot;

    public float ammoTime = 2f;
    private int ammoLimit = 5;
    private int maxHealth = 5;
    private int curHealth;
    private float ammoDelay;
    private int curAmmoCount;

    public GameObject playerHealth;
    public GameObject playerAmmo;

    private Transform[] playerHealthHearts;
    private Transform[] playerAmmoEggs;


    void Start()
    {
        for (int i = 0; i < axes.Length; i++) {
            axes[i] += player;
        }
        x = 0f;
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        airborne = true;
        curAmmoCount = ammoLimit;

        playerHealthHearts = playerHealth.GetComponentsInChildren<Transform>();
        playerAmmoEggs = playerAmmo.GetComponentsInChildren<Transform>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        // adding on amount of ammo.
        if (curAmmoCount < ammoLimit) {
            ammoDelay += Time.deltaTime;
        }
        if (ammoDelay > ammoTime) {
            ammoDelay = 0;
            if (curAmmoCount < ammoLimit) {
                curAmmoCount++;
            }
        }
        // display current ammo
        for (int i = 1; i <= ammoLimit; i++) {
            if (curAmmoCount >= i)
            {
                // this means that we should display ammo
                playerAmmoEggs[i].gameObject.SetActive(true);
            }
            else {
                playerAmmoEggs[i].gameObject.SetActive(false);
            }
        }

        // display current health

        for (int i = 1; i <= maxHealth; i++)
        {
            if (curHealth >= i)
            {
                // this means that we should display ammo
                playerHealthHearts[i].gameObject.SetActive(true);
            }
            else
            {
                playerHealthHearts[i].gameObject.SetActive(false);
            }
        }

        // death
        if (curHealth <= 0) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        
        x = Input.GetAxisRaw(axes[0]);

        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        rb.AddForce(Vector2.right * x * speed);
       
        float y = Input.GetAxisRaw(axes[1]);
        if (y == 1f && airborne == false) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            airborne = true;
        }
        reloadTime += Time.deltaTime;
        if (reloadTime > reloadDelay && Input.GetAxisRaw(axes[2]) == 1 && curAmmoCount > 0) {
            reloadTime = 0;
            GameObject egg = Instantiate(eggPrefab, eggSpawn.position, transform.rotation) as GameObject;
            egg.GetComponent<EggProjectileBehavior>().setPlayerNum(player);
            eggShot.Play();
            curAmmoCount--;
        }
        // Debug.Log("reloadTime: " + reloadTime);

    }

    public bool getInAir() {
        return airborne;
    }

    public float getAbsSpeed() {
        return Mathf.Abs(x);
    }
    public float getX() {
        return x;
    }
    public int playerNumber() {
        return player;
    }
    public void setAirborne(bool input) {
        airborne = input;
    }

    public void takeDamage() {
        curHealth--;
    }
}
