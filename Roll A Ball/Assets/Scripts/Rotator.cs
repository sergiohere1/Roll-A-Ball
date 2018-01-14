///////////////////////////////////////////
// Práctica: Roll-a-ball
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: Rotator.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	/// <summary>
    /// Metodo Update que es llamado cada frame.
    /// </summary>
	void Update () {
        // Método de transform encargado de rotarlo en un Gameobject en función a un Vector que le pasemos.
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
	}
}
