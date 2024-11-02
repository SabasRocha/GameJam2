using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Poscicion de Carriles")]
    [SerializeField] private Transform posCarrilIzq;
    [SerializeField] private Transform posCarrilCen;
    [SerializeField] private Transform posCarrilDer;
    [Space]
    [Header("Variables de Salto")]
    public int carrilActual;
    public bool tocaSuelo;
    private Rigidbody rb;
    [Tooltip("Variable Fuerza de Salto")]
    public float jumpForce;
    public float bajar;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        carrilActual = 2;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Izquierda") && carrilActual >= 2)
            {
                carrilActual--;
            transform.DOKill();
            ChangePosition();
                return;
            }
        if (Input.GetButtonDown("Derecha") && carrilActual < 3)
           {
                carrilActual++;
            transform.DOKill();
                ChangePosition();
                return;
            }
            
        if (Input.GetButtonDown("Jump") && tocaSuelo == true)
        {
            Jump();
        }
        if (tocaSuelo == false && Input.GetButtonDown("Bajar"))
        {
           GoDown();
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
                transform.DOMoveX(posIzq.x, 0.5f).SetEase(Ease.OutBack);
                break;
            case 2:
                transform.DOMoveX(posCen.x, 0.5f).SetEase(Ease.OutBack);
                break;
            case 3:
                transform.DOMoveX(posDer.x, 0.5f).SetEase(Ease.OutBack );
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
        if (collision.gameObject.CompareTag("Road"))
        {
            tocaSuelo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            tocaSuelo = false;
        }
    }
    private void GoDown()
    {
         rb.velocity = Vector3.zero;
         rb.AddForce(-transform.up * bajar , ForceMode.Impulse);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
        }
        else if (other.gameObject.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
        }
    }
}
