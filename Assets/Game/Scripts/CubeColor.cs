using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    [SerializeField] private float[,] pinkDegrade = new float[5, 3] { { 221, 62, 73 }, { 226, 81, 90 }, { 243, 95, 106 }, { 252, 115, 127 }, { 255, 136, 147 } };
    [SerializeField] private float[,] blueDegrade = new float[5, 3] { { 42, 67, 89 }, { 70, 108, 140 }, { 96, 133, 166 }, { 156, 193, 217 }, { 206, 228, 242 } };
    [SerializeField] private float[,] cyanDegrade = new float[5, 3] { { 0, 56, 64 }, { 0, 90, 91 }, { 0, 115, 105 }, { 0, 140, 114 }, { 2, 166, 118} };
    public int cubeState = 0;
    Renderer rn;

    float minAngle = 0.0f;
    float maxAngle = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        rn = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rn.material.color = new Color(cyanDegrade[cubeState, 0] / 255f, cyanDegrade[cubeState, 1] / 255f, cyanDegrade[cubeState, 2] / 255f);

        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateLeft(angle);
        }
    }

    void RotateLeft(float angle)
    {
        
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}
