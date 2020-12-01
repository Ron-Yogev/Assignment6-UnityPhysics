using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/**
 * This class adding score(removing one bottle from bottles left) if the bottle fell
 */
public class FallingScoreAdder : MonoBehaviour
{
    [Tooltip("TextMeshPro object of the score")]
    [SerializeField] TextMeshPro score;

    // bool represanting if the bottle fell or not
    bool fell;


    // Start is called before the first frame update
    public void Start()
    {
        fell = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        //if the the ball collider hit by other wine bottle, floor or under floor it saying that he fell
        if ((other.tag == "floor"|| other.tag == "wine" || other.tag=="underfloor") && !fell)
        {
            fell = true;
            score.GetComponent<ScoreAdder>().addScore();
            // destroying the fallen bottle after two sec
            StartCoroutine(DestroyAfterTwoSec());
        }
    }

    private IEnumerator DestroyAfterTwoSec()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }


}
