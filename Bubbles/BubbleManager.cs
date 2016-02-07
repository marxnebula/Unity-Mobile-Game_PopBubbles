using UnityEngine;
using System.Collections;

/* ~~~~~~~~~~ Class Info ~~~~~~~~~~
 *  - Manages the bubbles spawning.
 *  - A Timer is used for when to spawn a bubble below the camera, and
 *    randomly determines its horizontal position.
 *  - Currently only has a crab and seahorse bubble.
 *  
 *  --
 *  ~ Code by Jordan Marx ~ (2016)
 */

public class BubbleManager : MonoBehaviour {

    // The bubble prefabs
    public GameObject crabPrefab;
    public GameObject seahorsePrefab;

    // The position the bubble spawns
    private Vector3 vectorPosition;

    // Timers
    private float crabTimer = 0f;
    private float seahorseTimer = 0f;

    // Random number used for getting position
    private float randomXPosition = 0f;
    private float yPosition = -6f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        // Spawns a bubble based on timer
        CreateCrabBubble();

        CreateSeahorseBubble();
	}


    /*
     * Creates the crab prefab.
     */
    void CreateCrabBubble()
    {

        // If timer if greater than 5
        if (crabTimer > 2)
        {
            // Creates a bubble
            // Quaternion.identity means no rotation
            Instantiate(crabPrefab, GetRandomPosition(), Quaternion.identity);

            // Reset timer
            crabTimer = 0f;
        }

        // Increment timer
        crabTimer += Time.deltaTime;
    }

    /*
     * Creates the seahorse prefab.
     */
    void CreateSeahorseBubble()
    {

        // If timer if greater than 5
        if (seahorseTimer > 3)
        {
            // Creates a bubble
            // Quaternion.identity means no rotation
            Instantiate(seahorsePrefab, GetRandomPosition(), Quaternion.identity);

            // Reset timer
            seahorseTimer = 0f;
        }

        // Increment timer
        seahorseTimer += Time.deltaTime;
    }


    /*
     * Gets a random x position for the bubble.
     */
    Vector3 GetRandomPosition()
    {
        // Gets random float number within range
        randomXPosition = Random.Range(-2.30f, 2.30f);

        // Set new vector
        vectorPosition = new Vector3(randomXPosition, yPosition, 0f);

        // Return new vector
        return new Vector3(randomXPosition,yPosition,0f);
    }

}
