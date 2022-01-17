using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoPersonaje : MonoBehaviour
{
    //Variables para correr y saltar
    public float velocidadCorrer = 1.5f;
    public float velocidadSalto = 3;
    //ferencia a la herramienta
    Rigidbody2D rb2D;

    //Mejora el salto 
    public bool MejoraSalto=false;
    public float multiplicadoCaida=0.5f;
    public float multiplicadoCaidaCorto = 1f;
    //volvemos la variable publica se puede usar desde el editor
    //se puede usar en otros metodos
    public  SpriteRenderer renderizadoSprite;
    //variable booleane para animacion de correr 
    public Animator animador;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //el personaje se mueve a la derecha con la velocidad asignada
            rb2D.velocity = new Vector2(velocidadCorrer, rb2D.velocity.y);
            //el giro de la animacion del personaje este desactivado
            renderizadoSprite.flipX = false;
            //la animacion hacia la derecha se activa
            animador.SetBool("Correr", true);



        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //el personaje se mueve hacia la izquierda con la velocidad asignada
            rb2D.velocity = new Vector2(-velocidadCorrer, rb2D.velocity.y);
            //el giro de la animacion del personaje este activado
            renderizadoSprite.flipX = true;
            animador.SetBool("Correr", true);
        }
        else
        {
            //el personaje se queda quieto cuando no se pulsa ningun boton
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animador.SetBool("Correr", false);
        }
        if ((Input.GetKey("space") ||Input.GetKey("up"))&&ChequeoSuelo.estaSuelo)
        {
            //Sata el personaje si box collider esta sobre otro box collinder
            //el personaje tiene 2 box collider 1 de ellos es quien 
            //comprueba que este en el suelo 
            rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadSalto);
        }
        //animacion de saltar 
        if (ChequeoSuelo.estaSuelo == false)
        {
            //cuando este en el cielo
            //esta santando 
            //no corre en el cielo
            animador.SetBool("Salto", true);
            animador.SetBool("Correr", false);
        }
        if (ChequeoSuelo.estaSuelo == true)
        {
            //cuando esta en el suelo
            //no puede estar saltando
            animador.SetBool("Salto", false);
        }

        if (MejoraSalto)
        {
            //si la velocidad en en eje y 
            //es mejor a 0 cae mas lento
            if (rb2D.velocity.y<0)
            {
                //velocidad * el multiplicador*el tiempo de cada frame 

                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadoCaida) * Time.deltaTime;
            }
            //es mayor a 0 cae mas rapido
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadoCaidaCorto) * Time.deltaTime;
            }

        }
            
    }
}
