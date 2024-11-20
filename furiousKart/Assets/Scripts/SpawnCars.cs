using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject[] vehicleFabs; // creating an array for the kart prefabs
    public Transform[] spawnPoint; // creating an array for the spawn points


    int playerKart;

    // Start is called before the first frame update
    void Start()
    {
        playerKart = PlayerPrefs.GetInt("PlayerKart");
        GameObject pKart = Instantiate(vehicleFabs[playerKart]);
        int randomStartPos = Random.Range(0, spawnPoint.Length);  
        pKart.transform.position = spawnPoint[randomStartPos].position;
        pKart.transform.rotation = spawnPoint[randomStartPos].rotation;

        /*

        foreach (Transform t in spawnPoint) /* going through each spawn point in the array
                                           * t gives the spawn points transform
                                           * which allows us to set it equal to the vehicle
                                           * spawned in later*/
      /*
        {
            if(t == spawnPoint[randomStartPos]) continue;
            GameObject kart = Instantiate(vehicleFabs[Random.Range(0, vehicleFabs.Length)]); 
            //instantiating (creating a clone) random kart prefab to use
            kart.transform.position = t.position; // Setting clones position and rotation to match
            kart.transform.rotation = t.rotation; // position and rotation of spawnpoint.
        } */

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
