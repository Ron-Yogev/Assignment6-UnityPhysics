using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component lets the player push the Bowlly ball.
 */
public class BasketballBall : MonoBehaviour
{
    [SerializeField] float forceSize = 30f;
    [SerializeField] float timeFromHittingTheFloorToRestart = 2f;

    private Rigidbody rb;
    private Vector3 endPosition;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        rb.isKinematic = true;
        startPosition = GetMouseAsWorldPoint();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint();
    }

    void OnMouseUp()
    {
        rb.isKinematic = false;
        endPosition = GetMouseAsWorldPoint();
        Vector3 forceDirection = (endPosition - startPosition).normalized;
        rb.AddForce(forceDirection * forceSize, ForceMode.Impulse);
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = transform.position.z;
        return mousePoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundery")
        {
            RestartLevel();
        }
        else if (other.tag == "Platform")
        {
            StartCoroutine(HitTheFloor());
            print("Platform");
        }
    }

    IEnumerator HitTheFloor()
    {
        yield return new WaitForSeconds(timeFromHittingTheFloorToRestart);
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}