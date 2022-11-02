using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Gun : MonoBehaviour
{

    public BulletBehaviour BulletPrefab;
    public Transform LaunchOffset;

    public float magnitude;
    public float roughness;
    public float fadeInTime;
    public float fadeOutTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BulletPrefab, LaunchOffset.position, transform.rotation);
            CameraShaker.Instance.ShakeOnce(magnitude,roughness,fadeInTime,fadeOutTime);
        }
    }
}
