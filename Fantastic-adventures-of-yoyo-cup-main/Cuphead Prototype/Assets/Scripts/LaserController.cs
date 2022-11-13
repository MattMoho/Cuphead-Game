using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController: MonoBehaviour
{
    public float timeToToggleLaser = 2f;
    public float currentTime = 0f;
    public bool enabled = true;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToToggleLaser)
        {
            currentTime = 0;
            ToggleLaser();
        }
    }

    void ToggleLaser()
    {
        enabled = !enabled;
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(enabled);
        }
    }


}
