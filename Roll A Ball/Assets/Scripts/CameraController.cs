///////////////////////////////////////////
// Práctica: Roll-a-ball
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: CameraController.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    /// <summary>
    /// Variable que hará referencia al jugador, y que asignaremos en el Editor de Unity.
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Variable que representará la distancia entre el jugador y la cámara.
    /// </summary>
    private Vector3 offset;

	/// <summary>
    /// Método que se inicializa al comenzar y que en este caso calculará la distancia entre la 
    /// cámara y el jugador.
    /// </summary>
	void Start () {
        // Calculamos la distancia entre la cámara y el jugador
        offset = transform.position - player.transform.position;
	}
	
    /// <summary>
    /// En el LateUpdate iremos asignando la nueva posición a una equivalente a la posición actual del
    /// jugador a medida que se vaya moviendo más la distancia que haya calculado en el método Start.
    /// </summary>
	void LateUpdate() {
        //Colocamos la cámara en una posición equivalente a la del jugador más la distancia que los separa.
        transform.position = player.transform.position + offset;
	}
}
