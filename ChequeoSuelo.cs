using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChequeoSuelo : MonoBehaviour
{
    //variable tipo public estatic
    //para usar en otra clase
    public static bool estaSuelo;
    //si esta dentro de alguna geometria
    //hace colision 
    private void OnTriggerEnter2D(Collider2D other)
    {
        estaSuelo = true;
        
    }
    //si no esta dentro de una geometria
    private void OnTriggerExit2D(Collider2D collision)
    {
        estaSuelo = false;   
    }
}
