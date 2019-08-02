using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float jumpSpeed = 5F;
    float runSpeed = 5F;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        flipSprite();
        Jump();
    }

    void Run()
    {

        //OBTENER EL FLOAT(DECIMAL) DEL CONTROL QUE VA DE -1 A 1
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //INICIALIZAR UN VECTOR DE DOS DIMENSIONES QUE SOLO MODIFICA EL COMPONENTE X
        Vector2 playerVelocity = new Vector2(controlThrow*runSpeed,myRigidbody.velocity.y);

        //ASIGNAR LA NUEVA VELOCIDAD A MI RIGID BODY
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > 0;

        //APLICAR ANIMACION DE CORRER SETEANDO LA CONDICION DE "RUNNING" DEL ANIMATOR

        if (playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("Running", true);
        }

       else
        {
            myAnimator.SetBool("Running", false);
        }
    }

    void flipSprite()

        //VERIFICAR SI EXITE VELOCIDAD EN X INDEPENDIENTEMENTE DEL SIGNO (POR ESO USAMOS VALOR ABSOLUTO)
        // GUARDAMOS ESTA VERIFICACION 
    {
        bool playerHasHorizontalSpeed = Mathf.Abs (myRigidbody.velocity.x) > 0;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }


    }

    void Jump()
    {

        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))

        {
            return;
        }

        //OBTENER EL BOLEANO (TRUE/FALSE) DEL BOTON REPRESENTADO POR EL TAG "JUMP"
        bool isJumpButtonPressed = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isJumpButtonPressed)

        {

            Vector2 junpVelocity = new Vector2(0, jumpSpeed);
            //SUMARLE A LA VELOCIDAD QUE YA TIENE MI NUEVO VECTOR DE VELOCIDAD
            myRigidbody.velocity += junpVelocity;
        }

    }
}
