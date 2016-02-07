using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


/* ~~~~~~~~~~ Class Info ~~~~~~~~~~
 *  - Class for storing variables to be saved.
 *  - Class does not delete when you change the scenes.
 *  - Saves/loads user data to/from a file in all platforms except the web
 *  - MUST put this class once in each scene.
 *  
 *  --
 *  ~ Code by Jordan Marx ~ (2016)
 */
public class GameControl : MonoBehaviour {

    public static GameControl control;

    /* Variables for saving */
    // Total number of popped bubbles
    public int numberOfPoppedBubbles;

    // Booleans for drawing which GUI
    private bool isMainMenu = false;
    private bool isGamePlay = false;
    private bool isGameOver = false;
    private bool isUpgradeMenu = false;
    private bool isSelectCharMenu = false;
    private bool isBeatHightestHeight = false;

    // Textures for everything
    public Texture playImage;
    public Texture replayImage;
    public Texture upgradeImage;
    public Texture selectCharacterImage;
    public Texture backImage;
    public Texture upgradePopUpImage;
    public Texture selectCharacterPopUpImage;

    // GUI style
    public GUIStyle style;

    

	// Awake happens before Start()
	void Awake () {

        /*
         * So there can only be 1 control.(singleton)
         */
        // If control doesn't exist
        if(control == null)
        {
            // Doesn't destroy the game object when you change scenes
            DontDestroyOnLoad(gameObject);

            // Set control to this
            control = this;
        }
        // If control does exist but it is not this
        else if(control != this)
        {
            // Destroy gameobject because one already exists
            Destroy(gameObject);
        }
        
	}


   /*
    * Adds one bubble to total number of bubble pops.
    */
    public void AddOneBubblePop()
    {
        numberOfPoppedBubbles++;
    }

    /*
     * Gets the total number of bubbles popped.
     */
    public int GetTotalAmountOfBubblesPopped()
    {
        return numberOfPoppedBubbles;
    }


    /*
     * Turns on Game over display.
     */
    public void SetGameOverDisplay()
    {
        isGameOver = true;
    }
    
	
	
    /*
     * Saves data out into a file. This works on all platforms except the web.
     * You could save file as playerInfo.anything or just playerInfo
     */
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        // Create the file.
        // Application.persistentDataPath is the folder its going to and
        // "/playerInfo.dat" is the file name.
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        // Set the variables
        PlayerData data = new PlayerData();
        data.numberOfBubblesPopped = numberOfPoppedBubbles;

        // Save the data to the file
        bf.Serialize(file, data);

        file.Close();
    }


    /*
     * Loads data from a file.  Make sure to check if file exist.
     * This works on all platforms except the web.
     */
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            // Need to cast meaning specify that this is a player data object.
            // So it pulls the PlayerData data out of the file
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();

            // Set your variables to the loaded data
            numberOfPoppedBubbles = data.numberOfBubblesPopped;
        }
    }

}

/* 
 * This class needs to be serializable... meaning this data can be written to a file.
 */
[Serializable]
class PlayerData
{
    public int numberOfBubblesPopped;
}
