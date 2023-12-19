using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove2 : MonoBehaviour
{
    public float speed = 25;
    public float jumppower = 4;
    float xMove;
    Rigidbody2D rb;
    public SpriteRenderer sr;
    private bool jump;
    public LayerMask Floor;
    public Transform[] points2;
    public int jumpcount1 =0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //xMove =Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f*Time.deltaTime*speed,0,0);
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f*Time.deltaTime*speed,0,0);
            sr.flipX = false;
        }
        Debug.DrawRay(points2[0].position, Vector2.down * 0.2f,Color.red);
        Debug.DrawRay(points2[1].position, Vector2.down * 0.2f, Color.red);
        Debug.DrawRay(points2[2].position, Vector2.down * 0.2f, Color.red);
        //Debug.DrawRay(points2[3].position, Vector2.right * 0.1f, Color.red);
        //Debug.DrawRay(points2[4].position, Vector2.left * 0.1f, Color.red);
        Debug.Log(floorcheck());
        if (Input.GetKeyDown(KeyCode.W) && jumpcount1<2)
        {
            jumpcount1++;
            jump = true;
        }
        if (floorcheck())
        {
            jumpcount1 = 0;
        }
        /*
        if (wallcheckR())
        {
            jumpcount1 = 0;
        }
        if (wallcheckL())
        {
            jumpcount1 = 0;
        }
        */
    }

    private void FixedUpdate() //skips some frames, dont want key presses here but physics 
    {
        rb.velocity = new Vector2(Time.deltaTime * speed * xMove, rb.velocity.y);
        if (jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            jump = false;
        }
     
    }

    private bool floorcheck()
    {
        return Physics2D.Raycast(points2[0].position, Vector2.down, 0.2f, Floor);
    }
    /*
    private bool wallcheckR()
    {
        return Physics2D.Raycast(points2[3].position, Vector2.right * 0.1f, Floor);
    }
    private bool wallcheckL()
    {
        return Physics2D.Raycast(points2[4].position, Vector2.left * 0.1f, Floor);
    }
    */

}
