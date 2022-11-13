using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyController : MonoBehaviour
{

    public PickupBehaviour Pickup;
    public float dirX;
    public float speed;
    private Rigidbody2D rb;
    private bool isFacingLeft = false;
    private Vector3 localScale;
    public float health;
    public float flashTime;
    Color originalColor;
    Color collideColor;

    public float magnitude;
    public float roughness;
    public float fadeInTime;
    public float fadeOutTime;

    public Transform SpawnPoint;
    public killPlayer killPlayer;



    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
        speed = 3f;
        originalColor = GetComponent<Renderer>().material.color;
        collideColor = Color.blue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // moves the enemmies
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (health <= 0)
        {
            // create the pick ups when the enemy is destroyed 
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(colorChange());

            // Destroy the Turret when it has been hit by a bullet
            health -= 30;

            
            

            

        }


    }

    IEnumerator colorChange()
    {
        GetComponent<Renderer>().material.color = collideColor;
        yield return new WaitForSeconds(flashTime);
        GetComponent<Renderer>().material.color = originalColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            // if the enemy hits an invisable wall change the direction of it
            dirX *= -1;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = SpawnPoint.position;
        }
    }
}
