using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eggBasketSprite;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    [Range(1,10)] public float jumpForce = 1f;

    public float speed= 1f;
    private float x;
    private Rigidbody2D rb;
    private bool airborne;
    private Transform trans;
    private float reloadTime;
    public float reloadDelay = 1f;
    public GameObject eggPrefab;
    public Transform eggSpawn;

    public int player;
    private string[] axes = {"HorizontalP" , "JumpP" , "FireP" }; // 0 is horizontal, 1 is jump, 2 is fire.
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

    public PlayerDeath deathCheck;

    private bool hasEggBakset;

    public float reloadBuff = 2f;
    public float ammoFireBuff = .5f;
    public float moveSpdDebuff = 2f;
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
        // Debug.Log(ammoTime + " player: " + player);
        // adding on amount of ammo.
        eggBasketSprite.SetActive(hasEggBakset);

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
            deathCheck.playerDied(player);
            gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        x = Input.GetAxisRaw(axes[0]);
        Vector2 playerMovement = Vector2.right * x * speed;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (x == 0) {
            playerMovement = Vector2.zero;
        }

        rb.AddForce(playerMovement);
       
        float y = Input.GetAxisRaw(axes[1]);

        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // basically makes the fall smoother, more parabolic
        }
        
        if (y == 1f && airborne == false) {
            airborne = true;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
        setHasEggBasket(false);
    }
    public void setHasEggBasket(bool i) {
        bool orig = hasEggBakset;
        hasEggBakset = i;

        if (hasEggBakset)
        {
            ammoTime -= reloadBuff;
            maxSpeed -= moveSpdDebuff;
            ammoDelay -= ammoFireBuff;
        }
        if (orig) // if it originally had an egg, now not, then add back these.
        {
            ammoTime += reloadBuff;
            maxSpeed += moveSpdDebuff;
            ammoDelay += ammoFireBuff;
        }
    }
    public bool getHasEggBasket() {
        return hasEggBakset;
    }
}
