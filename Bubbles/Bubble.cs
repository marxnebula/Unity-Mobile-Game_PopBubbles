using UnityEngine;
using System.Collections;

/* ~~~~~~~~~~ Class Info ~~~~~~~~~~
 *  - Class that attaches to the bubble game object.
 *  - Gives bubble a positive vertical velocity.
 *  - If bubble is touched by user with finger then it unrenders, turns off collider,
 *    plays a sound, adds 1 bubble count to game control, and destroys game object
 *    after sound has played.
 *  
 *  --
 *  ~ Code by Jordan Marx ~ (2016)
 */


public class Bubble : MonoBehaviour {

    // Vertical speed
    public float verticalSpeed = 2f;

    // Game object of animal in bubble
    public GameObject animalGameObject;

	
	// Update is called once per frame
	void Update () {

        // Determine user input
        CheckUserInput();

        // Update the movement
        UpdateMovement();

	}

    /*
     * Checks users input based on which platform they are on.
     * It then calls a function to check if a certain button was pressed.
     */
    void CheckUserInput()
    {
        // If user is running on android
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                // TouchPhase.Began means a finger touched the screen
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    CheckButtonTouched(Input.GetTouch(0).position);
                }
            }
        }

        // If user is running the editor
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {

            if (Input.GetMouseButtonUp(0))
            {
                CheckButtonTouched(Input.mousePosition);
            }
        }
    }

    /*
     * Set the rigidbody velocity.
     */
    void UpdateMovement()
    {
        // Set velocity
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, verticalSpeed);
    }


    /*
     * Checks to see if the position parameter overlaps the bubbles collider.
     * If true then destroy it.
     */
    void CheckButtonTouched(Vector3 pos)
    {
        // Gets the point where user touched screen and converts it to world position
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(pos);

        // The spot where the user touched in world coordinates
        Vector2 touchPosition = new Vector2(worldPoint.x, worldPoint.y);

        // Check if a collider overlaps a point in space.
        Collider2D hit = Physics2D.OverlapPoint(touchPosition);


        // If you hit the collider of object this script is attached to
        if(hit == GetComponent<CircleCollider2D>() && hit)
        {
            // Function to destroy bubble
            BubbleHasBeenHit(hit);
        }
    }


    /*
     * Function for destroying the bubble.
     * Plays sound -> Turns off collider -> Unrenders -> Destroys game object after sound played.
     */
    void BubbleHasBeenHit(Collider2D h)
    {
        // Print that bubble was hit
        print("BUBBLE HIT");

        // Add 1 bubble pop to game control
        GameControl.control.AddOneBubblePop();

        // Play the audio
        GetComponent<AudioSource>().Play();

        // Turn off collider
        GetComponent<CircleCollider2D>().enabled = false;

        // Unrender
        GetComponent<SpriteRenderer>().enabled = false;

        // Destroy after sound has been played
        Destroy(h.gameObject, 5f);

        // Add the rigid body to animal so it falls
        animalGameObject.AddComponent<Rigidbody2D>();
    }
}
