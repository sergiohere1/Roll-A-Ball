///////////////////////////////////////////
// Práctica: Roll-a-ball
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: PlayerController.cs
///////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
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
            count += 100;
        }
    }
}
