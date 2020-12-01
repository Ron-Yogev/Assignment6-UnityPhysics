using UnityEngine;


/**
 * This component lets the player drag the ball while clicking the left mouse button,
 * and flick it in order to shoot the ball.
 */
[RequireComponent(typeof(Rigidbody))]
public class Bowlling : MonoBehaviour
{

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 positionMinusMouse;
    [SerializeField] private float screenYCoordinate;

    //start vector for calculationg velocity
    Vector3 Svelocity;
    //end vector for calculationg velocity
    Vector3 Evelocity;
    //1 throw each turn
    bool thrown = false;

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
        // dragging the object via mouse position
        Vector3 next_point = positionMinusMouse + MousePositionOnWorld();
        // drag boundaries 
        transform.position = mouseDragAround(next_point);
        // always the mouse is moving update the potential start vector in order to calculating the velocity
        Svelocity = MousePositionOnWorld();
    }

    //drag boundaries
    Vector3 mouseDragAround(Vector3 pos)
    {
        if (pos.x < -1.7f) pos.x = -1.7f;
        if (pos.x > 1.7f) pos.x = 1.7f;
        if (pos.z < -8f) pos.z = -8f;
        if (pos.z > -6.5f) pos.z = -6.5f;
        return pos;
    }

    // This function is called when the player releases the mouse button.
    void OnMouseUp()
    {
        // if the ball not thrown yet in this turn
        if (!thrown)
        { 
            Evelocity = MousePositionOnWorld();
            // computing the velocity by to vectors(end - start)
            Vector3 velocityf = Evelocity - Svelocity;
            velocityf *= 6f;
            velocityf.y = 0;

            // initial the ball velocity
            rb.velocity = velocityf;
            rb.isKinematic = false;
            thrown = true;
        }
    }

    // this function returns the position of the mouse on the track
    private Vector3 MousePositionOnWorld()
    {
        Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x/45f, screenYCoordinate, Input.mousePosition.y / 45f);
        mouseOnScreen.y = screenYCoordinate;
        return mouseOnScreen;
    }

    // set for thrown var
    public void setThrown(bool thrown)
    {
        this.thrown = thrown;
    }
}