using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform SpawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnPlayer();
            print("h00");
        }
    }

    public void SpawnPlayer()
    {
        Player.transform.position = SpawnPoint.transform.position;
    }
}
