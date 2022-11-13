using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public float timeToTogglePlatform = 2f;
    public float currentTime = 0f;
    public bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(currentTime >= timeToTogglePlatform)
        {
            currentTime = 0;
            TogglePlatfrom();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("H");
        if(collision.gameObject.tag == "Player")
        {
            currentTime += Time.deltaTime;
            
               
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        currentTime = 0;
    //    }
    //}

    void TogglePlatfrom()
    {
        
        enabled = !enabled;
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(enabled);
        }
    }
}
