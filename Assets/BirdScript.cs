using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        // Looks for the first gameobject in the hierachy with the "logic" tag. 
        // Be mindfull of the possibility of more gameobjects with the same tag.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        };

        // Check if the bird is out of bounds and is still alive before game over
        // This is to prevent the sound and GameOver function to be called multiple times
        if ((transform.position.y > 16 || transform.position.y < -16) && birdIsAlive)
        {
            Debug.Log("Out of bounds");
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            Debug.Log("Collision detected");
            logic.GameOver();
            birdIsAlive = false;
        }
    }
}
