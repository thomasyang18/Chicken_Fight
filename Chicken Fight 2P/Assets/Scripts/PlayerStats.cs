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
    
    void Start()
    {
        x = 0f;
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        airborne = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("HorizontalP1");
        rb.AddForce(Vector2.right * x * speed);
       
        float y = Input.GetAxisRaw("VerticalP1");
        if (y == 1f && airborne == false) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            airborne = true;
        }
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            airborne = false;
            Debug.Log("We collide with the floor ");
        }
        Debug.Log("We Collided");
    }
}
