using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Gun : MonoBehaviour
{

   // public BulletBehaviour BulletPrefab;
    //public LeftBB Leftbullet;
    //public Transform LaunchOffset;
    //public Transform LaunchOffsetL;

    public float magnitude;
    public float roughness;
    public float fadeInTime;
    public float fadeOutTime;

   // public bool movingRight = true;
   // public bool movingLeft;


    // Start is called before the first frame update


    // Update is called once per frame
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}
