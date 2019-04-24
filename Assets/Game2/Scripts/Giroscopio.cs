using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour
{
    Gyroscope gyro;
    public GameObject cube;
    public float speedMod;
    //private Rigidbody rb;

    private void Start()
    {
        Input.gyro.enabled = true;
        gyro = Input.gyro;
        //rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(cube.transform);
        print(Input.gyro.rotationRate);


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
    }
}
