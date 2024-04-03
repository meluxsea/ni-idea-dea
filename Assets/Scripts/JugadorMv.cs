using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMv : MonoBehaviour
{

    Rigidbody rg;

    
    public float jumpFoce = 5.0f;
    public bool isGrounded = false;


    [Header("Ejes de movimiento")]
    private float horizontalinput;
    private float verticalinput;
    private Vector3 VectorMovement;

    [Header("Velocidad de movimiento")]
    public float speed;


    void Start()
    {
        rg = GetComponent<Rigidbody>();

       

    }

    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
        VectorMovement = new Vector3(horizontalinput, 0f, verticalinput);
        
        VectorMovement.Normalize(); 
        
        transform.Translate(VectorMovement * Time.deltaTime* speed);
        
        
        
        if (Input.GetButtonDown("Jump") && isGrounded)      
        { 
         rg.AddForce(new Vector3(0, jumpFoce, 0),ForceMode.Impulse);
            isGrounded = false;
        
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso")) ;
            isGrounded=true;
        
    }



}
