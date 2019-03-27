using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MyTextureAtlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas textureAtlas;
    [SerializeField] private SpriteRenderer wall;
    private Sprite[] spriteArray = new Sprite[14];
    private int randomNum;
    private bool ultraSecretCode = false;
          
    // Start is called before the first frame update
    void Start()
    {
        textureAtlas.GetSprites(spriteArray);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !ultraSecretCode)
        {
            ultraSecretCode = true;
        }
        else if (Input.GetKeyDown(KeyCode.J) && ultraSecretCode)
        {
            ultraSecretCode = false;
        }

        if (ultraSecretCode)
        {
            randomNum = Random.Range(0, 13);

            wall.sprite = spriteArray[randomNum];
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                wall.sprite = textureAtlas.GetSprite("Concrete1");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                wall.sprite = textureAtlas.GetSprite("Grass1");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                wall.sprite = textureAtlas.GetSprite("Grass2");
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                wall.sprite = textureAtlas.GetSprite("Wood1");
            }
        }
    }
}
