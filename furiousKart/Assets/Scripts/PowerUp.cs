using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour


{

    public GameObject afterEffect; // reference to effect.

    public GameObject playerCar; // reference to vehicle object

    [SerializeField]
    private GameObject powerupArt; // reference to art to disable later.

    

    
    [SerializeField]
    private float WaitSeconds = 5f;
    private float multiplier = 1.5f;

    //When another object is in the domain of the object set as the trigger earlier, unity will call this method.
    private void OnTriggerEnter(Collider other) // Checking information about triggered object; in this case the objects collider.
    {
        if (other.CompareTag("Player")) //checking the tag of collider defined earlier.
        {
            StartCoroutine(Pickup(other)); /* starting Pickup method as a coroutine
                                            * to allow pausing as certain points */
            
            // If so, powerup sequence initiated.
            // pass in a reference to the player to allow changes
        }
    }

    IEnumerator Pickup(Collider player) /* IEnumerator is a return type which is used for creating coroutines
                                         * as this method returns as a IEnumerator, it allows unity to treat it as a coroutine
                                         * allowing us to pause at certain points
                                         * these are called yield point
          
                                         * pass in the other variable which is now a reference to the player.*/
    {
        Debug.Log("powerup picked up"); // Checking if powerup sequence is working.

        Instantiate(afterEffect, transform.position, transform.rotation); // creating a copy of the gameobject afterEffect at the position and rotation of the powerup

        GameObject.FindGameObjectWithTag("GreenCar").GetComponent<CarController>().engineStrength *= multiplier;
        // note to self, apply collider onto parent car itself.

        //playerCar.GetComponent<CarController>().engineStrength *= multiplier;
        /* Now with the reference of the playerCar gameobject
                                                                               * it accesses the CarController component attached
                                                                               * then modifies the engineStrength property by the magnitude of the
                                                                               * multiplier. */


        //CarController returnedCar = GameObject.FindGameObjectWithTag("player").GetComponent<CarController>();

        powerupArt.GetComponent<MeshRenderer>().enabled = false; // Parent art disabled, making it disapear.
        GetComponent<Collider>().enabled = false; // disables collider on powerup therefore interactions cannot occur. 

        yield return new WaitForSeconds(WaitSeconds); /* Makes the coroutine wait the declared time of WaitSeconds,
                                                       * execution is paused at this point of code but everything else will continue to run. */


        playerCar.GetComponent<CarController>().engineStrength /= multiplier; // reversing multiplier effect.
        Destroy(gameObject); // make object disapear once picked up.
    }
}
