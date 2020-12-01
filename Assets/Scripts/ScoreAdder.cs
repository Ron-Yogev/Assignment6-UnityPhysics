using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 * this class represant the score of the player, how bottles he has to strike and hoe much left
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("How mant bottles we need to strike this level")]
    [SerializeField] int numOfBottles = 6;
    //Score text
    TextMeshPro scoreText;

    int bottlesLeft;

    // Start is called before the first frame update
    public void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        //in the begining the left bottles = num of bottles
        bottlesLeft = numOfBottles;
        // update the text
        scoreText.SetText("Bottles left: " + bottlesLeft + "/" + numOfBottles);
    }

    // Update is called once per frame
    public void Update()
    {
        // always update the score text to know if one of the bottles fell
        scoreText.SetText("Bottles left: " + bottlesLeft + "/" + numOfBottles);
    }

    // function that add score(remove from left bottles)
    public void addScore()
    {
        bottlesLeft--;
    }

    // get for bottles left
    public int getScore()
    {
        return bottlesLeft;
    }
}
