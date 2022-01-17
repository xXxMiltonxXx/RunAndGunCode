using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jugador"))
        {
            //hacemos que la pasar el personaje 
            //el sprite del item se oculte 
            GetComponent<SpriteRenderer>().enabled = false;
            //activamos feedback del item
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //destrimos los objetos 
            Destroy(gameObject, 0.3f);

        }

    }
    

}
