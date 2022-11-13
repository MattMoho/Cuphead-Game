using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    public float dirY;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirY = 1f;;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirY * speed,rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlatWall")
        {
            // if the enemy hits an invisable wall change the direction of it
            dirY *= -1;
        }
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.transform.SetParent(transform);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision1)
    {


        if (collision1.gameObject.tag == "Player")
        {
            collision1.transform.SetParent(transform);
            print("h");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }


}
