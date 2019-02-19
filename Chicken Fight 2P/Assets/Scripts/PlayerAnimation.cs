using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public GameObject p;
    private PlayerStats player;
    private SpriteRenderer render;

    void Start()
    {
        player = p.GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getX() < 0)
        {
            render.flipX = false;
        }
        else if (player.getX() > 0){
            render.flipX = true;
        }
        anim.SetFloat("Speed", player.getAbsSpeed());
        anim.SetBool("inAir", player.getInAir());
    }
}
