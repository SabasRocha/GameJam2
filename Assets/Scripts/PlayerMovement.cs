using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public enum Carril
    {
        carrilIzquierdo,
        carrilCental,
        carrilDerecho
    }

    public Transform posCarrilIzq;
    public Transform posCarrilCen;
    public Transform posCarrilDer;
    public int carrilActual;
    public bool puedeMoverse;
    public bool tocaSuelo;
    private Rigidbody rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        carrilActual = 2;
        puedeMoverse = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeMoverse) 
        {
            if (Input.GetKeyDown(KeyCode.A) && carrilActual >= 2)
            {
                carrilActual--;
                ChangePosition();
                puedeMoverse = false;
                UnityEngine.Debug.Log("Izquierda" + carrilActual);
                return;
            }
            if (Input.GetKeyDown(KeyCode.D) && carrilActual < 3)
            {
                carrilActual++;
                ChangePosition();
                puedeMoverse = false;
                return;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && tocaSuelo == true)
        {
            Jump();
        }
    }

    public void ChangePosition()
    {
        Vector3 posIzq = new Vector3 (posCarrilIzq.position.x,transform.position.y ,0 );
        Vector3 posCen = new Vector3(posCarrilCen.position.x, transform.position.y, 0);
        Vector3 posDer = new Vector3(posCarrilDer.position.x, transform.position.y, 0);

        switch (carrilActual)
        {
            case 1:
                transform.DOMoveX(posIzq.x, 0.3f).OnComplete(() =>
                {
                    puedeMoverse = true;
                });
                break;
            case 2:
                transform.DOMoveX(posCen.x, 0.3f).OnComplete(() =>
                {
                    puedeMoverse = true;
                });
                break;
            case 3:
                transform.DOMoveX(posDer.x, 0.3f).OnComplete(() =>
                {
                    puedeMoverse = true;
                });
                break;
        }
    }

    public void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        tocaSuelo = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = false;
        }
    }
}
