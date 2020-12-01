using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriesToPlay : MonoBehaviour
{
    [SerializeField] int tries = 2;
    [SerializeField] TextMeshPro triesText;
    [SerializeField] TextMeshPro score;
    [SerializeField] int bottles = 6;
    int triesLeft = 2;
    
    Vector3 originBallPos;

    // Start is called before the first frame update
    void Start()
    {
        originBallPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "underfloor")
        {
            switch (triesLeft)
            {
                case 2:
                    if (score.text == "Bottles left: 0/" + bottles)
                    {
                        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                    }
                    triesLeft--;
                    triesText.SetText("Tries: "+triesLeft+"/"+tries);
                    transform.position = originBallPos;
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                    break;
                case 1:
                    LevelProccedCheck();
                    triesLeft--;
                    triesText.SetText("Tries: " + triesLeft + "/" + tries);
                    break;
            }        

        }
        else if (other.tag == "floor")
        {
            if(GetComponent<Rigidbody>().velocity==new Vector3(0, 0, 0))
            {
                switch (triesLeft)
                {
                    case 2:
                        if (score.text == "Bottles left: 0/" + bottles)
                        {
                            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                        }
                        triesLeft--;
                        triesText.SetText("Tries: 1/2");
                        transform.position = originBallPos;
                        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                        break;
                    case 1:
                        triesLeft--;
                        triesText.SetText("Tries: 0/2");
                        LevelProccedCheck();
                        break;
                }
            }
        }
    }

    private void LevelProccedCheck()
    {
        if (score.text == "Bottles left: 0/" + bottles)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
