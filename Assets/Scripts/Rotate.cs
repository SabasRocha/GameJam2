using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody candyRB;
    // Start is called before the first frame update
    void Start()
    {
        candyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        candyRB.AddTorque(0, 0.2f, 0, ForceMode.Force);
    }
}
