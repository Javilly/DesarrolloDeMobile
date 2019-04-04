using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapsInput : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;

    Renderer rn;

    void Awake()
    {
        width = (float)Screen.width/2;
        height = (float)Screen.height/2;

        position = new Vector3(0.0f, 0.0f, 0.0f);

        rn = GetComponent<Renderer>();
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(50, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                transform.position = position;
            }
            if (Input.touchCount == 1)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                rn.material.color = Color.yellow;
            }
            if (Input.touchCount == 2)
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                rn.material.color = Color.red;
            }
            if (Input.touchCount == 3)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                rn.material.color = Color.blue;

            }
            if (Input.touchCount == 4)
            {
                transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                rn.material.color = Color.green;
            }
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rn.material.color = Color.white;
        }
    }
}
