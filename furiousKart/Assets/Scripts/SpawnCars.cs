using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;
using Photon.Pun; 




public class SpawnCars : MonoBehaviourPunCallbacks
{
    public GameObject[] vehicleFabs; // creating an array for the kart prefabs
    public Transform[] spawnPoint; // creating an array for the spawn points


    
    GameObject pKart = null;

    public GameObject startRace;

    int playerKart;
    public float waitSec = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // PhotonNetwork.AutomaticallySyncScene = true;
        playerKart = PlayerPrefs.GetInt("PlayerKart");
        int randomStartPos = Random.Range(0, spawnPoint.Length);
        Vector3 startPos = spawnPoint[randomStartPos].position;
        Quaternion startRot = spawnPoint[randomStartPos].rotation;



        
        startPos = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].position;
        startRot = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].rotation;

        StartCoroutine(delayInstantiation(startPos, startRot));

       /* if (PhotonNetwork.IsMasterClient)
        {

            StartCoroutine(delayInstantiation(startPos, startRot));
            //pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
        }
        else
        {
            StartCoroutine(delayInstantiation(startPos, startRot));
            //pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
        }
        */

        /*
        startRace.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            startPos = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].position;
            startRot = spawnPoint[PhotonNetwork.CurrentRoom.PlayerCount - 1].rotation;




            if (NetworkedPlayer.LocalPlayerInstance == null)
            {
                pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
                //NetworkedPlayer.LocalPlayerInstance = pKart;

            }


            if (PhotonNetwork.IsMasterClient)
            {
                startRace.SetActive(true);
            }
        }
        */

        //}
/*        else
        {
            pKart = Instantiate(vehicleFabs[playerKart]);
            pKart.transform.position = startPos;
            pKart.transform.rotation = startRot;


        }
*/
        //Camera kartCamera = pKart.GetComponentInChildren<Camera>();
        //pKart.GetComponent<CarController>().enabled = true;
        //pKart.GetComponentInChildren<Camera>().enabled = true;
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

    IEnumerator delayInstantiation(Vector3 startPos, Quaternion startRot)
    {

        yield return new WaitForSeconds(waitSec);
        pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
       // pKart = PhotonNetwork.Instantiate(vehicleFabs[playerKart].name, startPos, startRot, 0);
        Camera kartCamera = pKart.GetComponentInChildren<Camera>();
        pKart.GetComponent<CarController>().enabled = true;
        pKart.GetComponentInChildren<Camera>().enabled = true;

    }



    void Update()
    {
        
    }
}
