using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject pickUp;

    public float interval = 2.0f;

    public float destroyInterval = 5.0f;


    // Use this for initialization
    private void Start()
    {
        //Run the SpawnPickup function without blocking the game
        StartCoroutine(SpawnPickup());
    }

    private IEnumerator SpawnPickup()
    {
        // Run this loop forever 
        while (true)
        {
            //Wait for interval seconds
            yield return new WaitForSeconds(interval);

            //Determine the minimal position for the pickup to spawn
            Vector3 min = transform.position - transform.localScale / 2f;

            //Determine the maximal posiion for the spawn
            Vector3 max = transform.position + transform.localScale / 2f;

            //Fix the Y axis (not 0, 0.5)
            //For x and z axis, it is a random number between (-10 and 10)
            Vector3 position = new Vector3(Random.Range(min.x, max.x), transform.position.y, Random.Range(min.z, max.z));

            //Creat pickup object at position we just calculated
            GameObject newPickup = Instantiate(pickUp, position, pickUp.transform.rotation);

            //Destroy the newPickUp if not collected by the player within destroyInterval
            Destroy(newPickup, destroyInterval);
        }

        

    }
}
