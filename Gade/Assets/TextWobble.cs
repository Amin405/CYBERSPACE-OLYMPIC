using UnityEngine;

public class TextWobble : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;
    
    private Vector3 startPosition;
    private float elapsedTime;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        Vector3 newPos = startPosition;
        newPos.y += Mathf.Sin(elapsedTime * frequency) * amplitude;
        transform.position = newPos;
    }
}