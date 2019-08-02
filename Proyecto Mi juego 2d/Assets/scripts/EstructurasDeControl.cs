using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstructurasDeControl : MonoBehaviour
{
    public int vida = 100 ;

    // Start is called before the first frame update
    void Start()
    {

        if (vida > 50)
        {

            //PONER ANIMACION DE JUGADOR SANO
            Debug.Log("El jugador tiene vida mayor a 50");
        }
        else if(vida < 30)
        {
            // PONER ANIMACION DE JUGADOR HERIDO

            Debug.Log("El jugador esta jodido");
        }
        else
        {
            // PONER ANIMACION DE JUGADOR MUERTO

            Debug.Log("El jugador esta muerto");
        }


     }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("PLAY GAME");
    }

    public void ShowCredits()
    {
        Debug.Log("CREDITS");
    }

    public void Exitgames()
    {
        Debug.Log("EXIT");
    }

}
