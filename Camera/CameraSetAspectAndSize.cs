using UnityEngine;
using System.Collections;

/* ~~~~~~~~~~ Class Info ~~~~~~~~~~
 *  - It sets the aspect and camera size based on what platform game is running on.
 *  
 *  --
 *  ~ Code by Jordan Marx ~ (2016)
 */

public class CameraSetAspectAndSize : MonoBehaviour {


    // Stores current aspect
    private float currentAspect;


    void Start()
    {
        // Set camera aspect
        DetermineCameraAspectAndSize();
    }
    


    /*
     * Determine what the camera aspect is based on current device.
     * Then set the aspect and adjust the size to show entire screen.
     */
    void DetermineCameraAspectAndSize()
    {
        
        // Get the current aspect
        currentAspect = (float)Screen.width / (float)Screen.height;

        
        // 3:4 = 0.75
        if (currentAspect > 0.70)
        {
            // Set aspect
            GetComponent<Camera>().aspect = 3f / 4f;

            // Set size
            Camera.main.orthographicSize = 4.30f;
        }
        // 2:3 = 0.6666666667
        else if (currentAspect > 0.64)
        {
            // Set Aspect
            GetComponent<Camera>().aspect = 2f / 3f;

            // Set size
            Camera.main.orthographicSize = 4.82f;
        }
        // 10:16 = 0.625
        else if (currentAspect > 0.60)
        {
            // Set aspect
            GetComponent<Camera>().aspect = 10f / 16f;

            // Set size
            Camera.main.orthographicSize = 5.15f;
        }
        // 10:17 = 0.5882
        else if (currentAspect > 0.57)
        {
            // Set aspect
            GetComponent<Camera>().aspect = 10f / 17f;

            // Set size
            Camera.main.orthographicSize = 5.72f;
        }
        // 9:16 = 0.5625
        else if (currentAspect > 0.50)
        {
            // Set aspect
            GetComponent<Camera>().aspect = 9f / 16f;

            // Set size
            Camera.main.orthographicSize = 5.7f;
        }
        // Just incase
        else
        {
            // Set aspect
            GetComponent<Camera>().aspect = 9f / 16f;

            // Set size
            Camera.main.orthographicSize = 5.7f;
        }
         

    }
}
