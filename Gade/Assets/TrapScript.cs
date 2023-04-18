using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public float speed = 2f; // Geschwindigkeit der Bewegung
    public float distance = 3f; // Distanz der Bewegung
    public float rotationSpeed = 50f; // Drehgeschwindigkeit in Grad pro Sekunde

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Hin- und Herbewegung
        float movementOffset = Mathf.Sin(Time.time * speed) * distance;
        Vector3 newPosition = initialPosition + new Vector3(0f, movementOffset, 0f);
        transform.position = newPosition;

        // Drehung um die Z-Achse
        float rotationAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, rotationAngle));
    }
}