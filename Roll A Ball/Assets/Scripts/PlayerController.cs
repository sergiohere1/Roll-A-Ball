///////////////////////////////////////////
// Práctica: Roll-a-ball
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: PlayerController.cs
///////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// <summary>
    /// Variable referente a la velocidad de la fuerza, y que nosotros asignaremos.
    /// </summary>
    public float speed;
    /// <summary>
    /// Variable referente al texto que llevará la cuenta de las monedas recogidas.
    /// </summary>
    public Text countText;
    /// <summary>
    /// Variable referente al Texto que nos aparecerá una vez el jugador gane la partida.
    /// </summary>
    public Text winText;
    /// <summary>
    /// Variable referente al RigidBody del jugador.
    /// </summary>
    private Rigidbody rb;
    /// <summary>
    /// Variable referente a la cuenta de las monedas recogidas por el jugador.
    /// </summary>
    private int count;

    /// <summary>
    /// Método que se ejecutará nada más comenzar, con el cual obtendremos el rigidbody del jugador,
    /// estableceremos a 0 la cuenta de monedas recogidas, daremos un valor al texto encargado de llevar
    /// la cuenta de las mismas y daremos valor vacío al texto en caso de victoria para que no aparezca
    /// antes de tiempo.
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    /// <summary>
    /// FixedUpdate se llama antes de realizar cualquier cálculo de físicas. Aquí irán nuestros
    /// cálculos de físicas
    /// </summary>
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Añadimos una fuerza a nuestro cuerpo que equivaldrá al vector resultante del movimiento horizontal
        // y vertical multiplicado por la velocidad que le hayamos asignado desde el Editor. 
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioClip audio;

        if (other.gameObject.CompareTag("Pick Up"))
        {           
            audio = other.GetComponent<AudioSource>().clip;
            AudioSource.PlayClipAtPoint(audio, transform.position);
            Destroy(other.gameObject);
            count += 1;
            SetCountText();

        }
    }

    /// <summary>
    /// Método encargado de sumar al marcador las monedas que hayamos recogido. Una vez lleguemos
    /// a la cifra objetivo, aparecerá un mensaje de victoria al usuario.
    /// </summary>
    void SetCountText()
    {
        countText.text = string.Format("Count: {0}", count.ToString());
        if(count >= 16)
        {
            winText.text = "You win!";
        }
    }
}
