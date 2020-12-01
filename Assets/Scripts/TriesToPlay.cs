using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This class responsible for updating the tries text and moving between turns and levels(between scenes)
 */
public class TriesToPlay : MonoBehaviour
{
    [Tooltip("How many tries you have in this level")]
    [SerializeField] int tries = 2;
    [Tooltip("TextMeshPro object of the tries")]
    [SerializeField] TextMeshPro triesText;
    [Tooltip("TextMeshPro object of the score")]
    [SerializeField] TextMeshPro score;
    [Tooltip("How many bottles have this level")]
    [SerializeField] int bottles = 6;
    [Tooltip("The level of the game(scene)")]
    [SerializeField] int level;
    
    int triesLeft = 2;
    
    // keeping the original position of the ball in order to put it back
    Vector3 originBallPos;

    // Start is called before the first frame update
    void Start()
    {
        originBallPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        //if the ball fell out of the track
        if (other.tag == "underfloor")
        {
            switch (triesLeft)
            {
                /*
                 * the first shot, you can move to the next level if succeed,
                 * or move to next turn if not
                */
                case 2:
                    nextLevelSceneCheck();
                    // tries computing
                    triesLeft--;
                    triesText.SetText("Tries: "+triesLeft+"/"+tries);
                    transform.position = originBallPos;
                    // inital the velocity in order that the ball will not move in the next turn
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                    GetComponent<Bowlling>().setThrown(false); //this turn throw ends, initial it for the next turn 
                    break;
                case 1:
                    triesLeft--;
                    triesText.SetText("Tries: " + triesLeft + "/" + tries);
                    // checking if the player needs to pass this level or to stay
                    nextLevelSceneCheck();
                    sameLevelSceneCheck();
                    break;
            }        

        }
    }

    // epsilon in order to the decide from what velocity of the ball we get to the next turn/level
    float epsilon = 0.05f;

    // call every frame
    private void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        if (velocity != new Vector3(0, 0, 0))
        {
            //if the ball is almost not moving at all
            if (velocity.x < epsilon && velocity.y < epsilon && velocity.z < epsilon)
            {
                switch (triesLeft)
                {
                    /*
                     * the first shot, you can move to the next level if succeed,
                     * or move to next turn if not
                    */
                    case 2:
                        nextLevelSceneCheck();
                        // tries computing
                        triesLeft--;
                        triesText.SetText("Tries: " + triesLeft + "/" + tries);
                        transform.position = originBallPos;
                        // inital the velocity in order that the ball will not move in the next turn
                        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                        GetComponent<Bowlling>().setThrown(false);//this turn throw ends, initial it for the next turn 
                        break;
                    /*
                     * the secaond shot, you can move to the next level if succeed,
                     * or repeat this level if not
                     */
                    case 1:
                        triesLeft--;
                        triesText.SetText("Tries: " + triesLeft + "/" + tries);
                        // checking if the player needs to pass this level or to stay
                        nextLevelSceneCheck();
                        sameLevelSceneCheck();
                        break;
                }
            }
        }
    }

    // this function checks if the player pass to next level(scenes loading)
    private void nextLevelSceneCheck()
    {
        if (score.text == "Bottles left: 0/" + bottles)
        {
            if (level == 3)
            {
                SceneManager.LoadScene("YouWin");
            }
            else
            {
                SceneManager.LoadScene("Level" + (level + 1));

            }
        }
    }

    // this function checks if the player not pass the current level and needs to repeat it(scene loading)
    private void sameLevelSceneCheck()
    {
        if (score.text != "Bottles left: 0/" + bottles)
        {
            SceneManager.LoadScene("Level"+level);
        }
    }

}
