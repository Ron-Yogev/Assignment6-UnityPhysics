using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallingScoreAdder : MonoBehaviour
{
    [SerializeField] TextMeshPro score;
    bool fell;
    // Start is called before the first frame update
    public void Start()
    {
        fell = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if ((other.tag == "floor"|| other.tag == "wine" || other.tag=="underfloor") && !fell)
        {
            fell = true;
            score.GetComponent<ScoreAdder>().addScore();
            StartCoroutine(DestroyAfterTwoSec());
        }
    }

    private IEnumerator DestroyAfterTwoSec()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }


}
