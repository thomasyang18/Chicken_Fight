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
    public Collider2D groundCheck;
    private float reloadTime;
    public float reloadDelay = 1f;
    public Rigidbody2D egg;
    public Transform eggSpawn;

    public int player;
    private string[] axes = {"HorizontalP" , "VerticalP" , "FireP" }; // 0 is horizontal, 1 is vertical, 2 is fire.

    public AudioSource eggShot;
    
    void Start()
    {
        for (int i = 0; i < axes.Length; i++) {
            axes[i] += player;
        }
        x = 0f;
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        airborne = false;
        reloadTime = reloadDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw(axes[0]);
        rb.AddForce(Vector2.right * x * speed);
       
        float y = Input.GetAxisRaw(axes[1]);
        if (y == 1f && airborne == false) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            airborne = true;
        }
        reloadTime += Time.deltaTime;
        if (reloadTime > reloadDelay && Input.GetAxisRaw(axes[2]) == 1) {
            reloadTime = 0;
            Instantiate(egg, eggSpawn.position, transform.rotation);
            eggShot.Play();
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            airborne = false;
        }
        //Debug.Log("We Collided");
    }
}
