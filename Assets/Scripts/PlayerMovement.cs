using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Poscicion de Carriles")]
    public Transform posCarrilIzq;
    public Transform posCarrilCen;
    public Transform posCarrilDer;
    [Space]
    [Header("Variables de Salto")]
    public int carrilActual;
    public bool tocaSuelo;
    private Rigidbody rb;
    [Tooltip("Variable Fuerza de Salto")]
    public float jumpForce;
    public float bajar;
    public bool gameOver;
    public GameObject panelGameOver;
    public GameObject btn_Pause;
    static bool centinela = false;
    public bool centinela2 = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();    
    }

    private void Awake()
    {
        if(centinela == false)
        {
            carrilActual = 2;
            centinela = true;
        }
        
    }

    public void ActCarril(int carrilNuevo)
    {
        carrilActual = carrilNuevo;
        UnityEngine.Debug.Log("Carril Personaje Nuevo: " + carrilActual);
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(carrilActual);
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
            animator.SetBool("TocaSuelo", false);
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
        if (centinela2 == true && collision.gameObject.CompareTag("Road"))
        {
           
            tocaSuelo = true;
            animator.SetBool("TocaSuelo", tocaSuelo);
                      
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            tocaSuelo = false;
            animator.SetBool("TocaSuelo", tocaSuelo);
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
                Time.timeScale = 0;
                panelGameOver.SetActive(true);
                btn_Pause.SetActive(false);
                gameOver = true;
            }
            else if (other.gameObject.CompareTag("Candy"))
            {
                Destroy(other.gameObject);
            }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            tocaSuelo = true;
            animator.SetBool("TocaSuelo", tocaSuelo);
        }
    }

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        centinela2 = true;
    }
}
