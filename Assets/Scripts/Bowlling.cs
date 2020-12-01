using UnityEngine;


/**
 * This component lets the player drag its object while clicking the left mouse button,
 * and drop it by releasing the mouse.
 */
[RequireComponent(typeof(Rigidbody))]
public class Bowlling : MonoBehaviour
{

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 positionMinusMouse;
    [SerializeField] private float screenYCoordinate;
    Vector3 Svelocity;
    Vector3 Evelocity;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // This function is called when the player clicks the collider of this object.
    void OnMouseDown()
    {
        if (!rb.IsSleeping()) return;  // Do not allow the player to drag the object when it is moving.
        rb.isKinematic = true; // ignore forces, since the player now moves the object.
        screenYCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
        positionMinusMouse = transform.position - MousePositionOnWorld();
    }

    // This function is called when the player drags the mouse.
    void OnMouseDrag()
    {
        if (!rb.IsSleeping()) return;  // Do not allow the player to drag the object when it is moving.
        transform.position = positionMinusMouse + MousePositionOnWorld();
        Svelocity = MousePositionOnWorld();
    }

    // This function is called when the player releases the mouse button.
    void OnMouseUp()
    {
        if (!rb.IsSleeping()) return;
        Evelocity = MousePositionOnWorld();
        Vector3 velocityf= Evelocity - Svelocity;
        velocityf *= 10f;
        //velocityf.y = 0;
        rb.velocity = velocityf;
        rb.isKinematic = false;
    }

    private Vector3 MousePositionOnWorld()
    {
        Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x/45f, screenYCoordinate, Input.mousePosition.y / 45f);
        mouseOnScreen.y = screenYCoordinate;
        return mouseOnScreen;
    }
}