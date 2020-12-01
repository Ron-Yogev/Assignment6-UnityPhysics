using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    [SerializeField] int numOfBottles = 6;
    TextMeshPro scoreText;
    [SerializeField]int bottlesLeft=6;

    // Start is called before the first frame update
    public void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        bottlesLeft = numOfBottles;
        scoreText.SetText("Bottles left: " + bottlesLeft + "/" + numOfBottles);
    }

    // Update is called once per frame
    public void Update()
    {
        scoreText.SetText("Bottles left: " + bottlesLeft + "/" + numOfBottles);
    }

    public void addScore()
    {
        bottlesLeft--;
    }

    public int getScore()
    {
        return bottlesLeft;
    }
}
