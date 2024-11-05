using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    public bool gameOver;
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
        }
        else if (other.gameObject.CompareTag("Candy"))
        {
            Debug.Log("Candy");
            Destroy(other.gameObject);
        }
    }

}
