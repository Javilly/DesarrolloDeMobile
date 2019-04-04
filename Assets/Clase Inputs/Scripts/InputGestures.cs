using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGestures : MonoBehaviour
{
    float validInputThresold = 5f;

    public float thrust = 5f;
    private Rigidbody rb;
    Renderer rn;

    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rn = GetComponent<Renderer>();
    }

    enum Gestures
    {
        None,
        Stationary,
        SwipeRight,
        SwipeLeft,
        SwipeUp,
        SwipeDown,
        SwipeUpRight,
        SwipeDownRight,
        SwipeDownLeft,
        SwipeUpLeft
    }

    Gestures currentGesture;

    public void Update()
    {
        currentGesture = Gestures.None;
        if (Input.touchCount > 0)
        {
            HandleTouch(Input.GetTouch(0));
        }
        HandleCharacterMovement(currentGesture);
    }

    Vector2 originalPosition;

    void HandleTouch(Touch touch)
    {

        if (Input.touchCount == 0) return;

        switch (touch.phase)
        {
            case TouchPhase.Began:
                originalPosition = touch.position;
                break;
            case TouchPhase.Moved:
                Vector3 delta = touch.position - originalPosition;
                if (delta.magnitude > validInputThresold) Moved(touch, delta);
                break;
            case TouchPhase.Stationary:
                currentGesture = Gestures.Stationary;
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                currentGesture = Gestures.None;
                break;
        }
    }

    public float gestureThresold = 10f;

    void Moved(Touch touch, Vector3 delta)
    {
        if (delta.x > gestureThresold) currentGesture = Gestures.SwipeRight;
        else if (delta.x < -gestureThresold) currentGesture = Gestures.SwipeLeft;
        else if (delta.y > gestureThresold) currentGesture = Gestures.SwipeUp;
        else if (delta.y < -gestureThresold) currentGesture = Gestures.SwipeDown;
        else if (delta.x > gestureThresold && delta.y > gestureThresold) currentGesture = Gestures.SwipeUpRight;
        else if (delta.x > gestureThresold && delta.y < -gestureThresold) currentGesture = Gestures.SwipeUpLeft;
        else if (delta.x < -gestureThresold && delta.y < -gestureThresold) currentGesture = Gestures.SwipeUpRight;
        else if (delta.x < -gestureThresold && delta.y > gestureThresold) currentGesture = Gestures.SwipeUpRight;
    }


    void HandleCharacterMovement(Gestures gesture)
    {
        switch (gesture)
        {

            default:
            case Gestures.None:
            case Gestures.Stationary:
                return;

            case Gestures.SwipeRight:
                MoveRight();
                return;
            case Gestures.SwipeLeft:
                MoveLeft();
                return;
            case Gestures.SwipeUp:
                MoveUp();
                return;
            case Gestures.SwipeDown:
                MoveDown();
                return;
            case Gestures.SwipeUpRight:
                MoveUpRight();
                return;
            case Gestures.SwipeDownRight:
                MoveDownRight();
                return;
            case Gestures.SwipeDownLeft:
                MoveDownLeft();
                return;
            case Gestures.SwipeUpLeft:
                MoveUpLeft();
                return;
        }
    }

    void MoveRight()
    {
        rb.AddForce(transform.forward * thrust);
        if(direction != 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        direction = 0;
    }
    void MoveLeft()
    {
        rb.AddForce(-transform.forward * thrust);
        if (direction != 1)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        direction = 1;
    }
    void MoveUp()
    {
        rb.AddForce(transform.up * thrust);
        if (direction != 2)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        direction = 2;
    }
    void MoveDown()
    {
        rb.AddForce(-transform.up * thrust);
        if (direction != 3)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        direction = 3;
    }


    void MoveUpRight()
    {
        rn.material.color = Color.yellow;
    }
    void MoveDownRight()
    {
        rn.material.color = Color.red;
    }
    void MoveDownLeft()
    {
        rn.material.color = Color.blue;
    }
    void MoveUpLeft()
    {
        rn.material.color = Color.green;
    }
}
