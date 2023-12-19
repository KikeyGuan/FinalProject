using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove1 : MonoBehaviour
{
    public float speed = 25;
    public float jumppower = 4;
    float xMove;
    Rigidbody2D rb;
    public SpriteRenderer sr;
    private bool jump;
    public LayerMask Floor;
    public Transform[] points;
    public int jumpcount;

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f*Time.deltaTime*speed,0,0);
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f*Time.deltaTime*speed,0,0);
            sr.flipX = false;
        }
        Debug.DrawRay(points[0].position, Vector2.down * 0.2f,Color.red);
        Debug.DrawRay(points[1].position, Vector2.down * 0.2f, Color.red);
        Debug.DrawRay(points[2].position, Vector2.down * 0.2f, Color.red);
        //Debug.DrawRay(points[3].position, Vector2.right * 0.1f, Color.red);
        //Debug.DrawRay(points[4].position, Vector2.left * 0.1f, Color.red);
        //Debug.Log(floorcheck());
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpcount<2)
        {
            jumpcount++;
            jump = true;
            //Debug.Log(jumpcount);
        }
        if (floorcheck())
        {
            jumpcount = 0;
        }
        /*
        if (wallcheckR())
        {
            jumpcount = 0;
        }
        if (wallcheckL())
        {
            jumpcount = 0;
        }*/
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
        return Physics2D.Raycast(points[0].position, Vector2.down, 0.2f, Floor);
    }
    /*private bool wallcheckR()
    {
        return Physics2D.Raycast(points[3].position, Vector2.right * 0.1f, Floor);
    }
    private bool wallcheckL()
    {
        return Physics2D.Raycast(points[4].position, Vector2.left * 0.1f, Floor);
    }
*/
}

