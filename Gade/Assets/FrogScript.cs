using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = 1.0f;
    public bool lockRotation = true;
    private float time;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInFigureEight();
    }

    void MoveInFigureEight()
    {
        time += Time.deltaTime * speed;

        float x = radius * Mathf.Sin(time);
        float y = radius * Mathf.Sin(time) * Mathf.Cos(time);

        Vector3 figureEightOffset = new Vector3(x, y, 0);
        transform.position = initialPosition + figureEightOffset;

        if (lockRotation)
        {
            transform.rotation = initialRotation;
        }
    }
}