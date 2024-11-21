using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;
using Photon.Pun; 




public class SpawnCars : MonoBehaviourPunCallbacks
{
    public GameObject[] vehicleFabs; // creating an array for the kart prefabs
    public Transform[] spawnPoint; // creating an array for the spawn points


    public GameObject StartRace;
    GameObject pKart = null;


    int playerKart;

    // Start is called before the first frame update
    void Start()
    {
        playerKart = PlayerPrefs.GetInt("PlayerKart");
        int randomStartPos = Random.Range(0, spawnPoint.Length);
        Vector3 startPos = spawnPoint[randomStartPos].position;
        Quaternion startRot = spawnPoint[randomStartPos].rotation;

        if (PhotonNetwork.IsConnected) 
        {
            startPos = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].position;
            startRot = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].rotation;

            if(NetworkedPLayer.LocalPlayerInstance == null)
            {
                pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
            }


            if (PhotonNetwork.IsMasterClient)
            {
                
            }        
        }
        else
        {
            pKart = Instantiate(vehicleFabs[playerKart]);
            pKart.transform.position = startPos;
            pKart.transform.rotation = startRot;


        }

        Camera kartCamera = pKart.GetComponentInChildren<Camera>();
        pKart.GetComponent<CarController>().enabled = true;
        pKart.GetComponentInChildren<Camera>().enabled = true;
        //kartCamera.GetComponent<CameraController>().enabled = true;



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
