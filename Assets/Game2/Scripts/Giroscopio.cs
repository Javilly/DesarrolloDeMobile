using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour
{
    Gyroscope gyro;
    public GameObject cube;
    public float speedMod;
    //private Rigidbody rb;

    Vector2 startPos;
    float minSwipeDist = -100f;

    Ray ray;
    RaycastHit hit;
    GameObject touchedObject;

    private void Start()
    {
        Input.gyro.enabled = true;
        gyro = Input.gyro;
        //rb = GetComponent<Rigidbody>();
    }

    private void MoveAndDestroy(GameObject objectToMove)
    {
        if(touchedObject.tag == "Stick")
        {
            objectToMove.transform.Translate(-touchedObject.transform.right * 8);
            Destroy(objectToMove, 2f);
        }
    }

    private void Update()
    {
        transform.LookAt(cube.transform);
        //print(Input.gyro.rotationRate);
        //print(Input.touchCount);

        if (Input.touchCount == 0)
        {
            if (gyro.rotationRate.y > 0.05)
            {
                transform.RotateAround(cube.transform.position, Vector3.up, -Time.deltaTime * speedMod);
            }
            if (gyro.rotationRate.y < -0.05)
            {
                transform.RotateAround(cube.transform.position, Vector3.up, Time.deltaTime * speedMod);
            }
        }
        else if (Input.touchCount == 2)  //&& Input.GetTouch(1).phase == TouchPhase.Began
        {
            bool moveObject = false;

            switch (Input.GetTouch(1).phase)
            {
                case TouchPhase.Began:
                    startPos = Input.GetTouch(1).position;

                    ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                    break;


                case TouchPhase.Ended:
                    float swipeDist = Input.GetTouch(1).position.y - startPos.y;

                    print(swipeDist);

                    if (swipeDist < minSwipeDist)
                    {
                        // It's a swiiiiiiiiiiiipe!
                        //var swipeDirection = Mathf.Sign(Input.GetTouch(1).position.y - startPos.y);
                        moveObject = true;
                        print("ME MUEVOOOOOOO");
                        // Do something here in reaction to the swipe.
                    }
                    break;
            }

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null && moveObject)
                {
                    touchedObject = hit.transform.gameObject;
                    Debug.Log("Touched " + touchedObject.transform.name);

                    MoveAndDestroy(touchedObject);
                }
            }
        }
    }
}
