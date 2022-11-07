using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;


    public float speed;
    private float destroyTime = 1f;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the bullet along the screen
        // transform.position += transform.right * Time.deltaTime * speed;
        Destroy(gameObject, destroyTime);
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroies the bullet once it has collided with another Game Object
        Destroy(gameObject);
    }
}
