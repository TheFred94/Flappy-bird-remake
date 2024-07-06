using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        { logic.addScore(1); }
    }
}
