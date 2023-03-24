using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class LeaningMenScript : MonoBehaviour
{
    [SerializeField] private float throwForce = 10f; // throwing force applied to GameObject
    [SerializeField] private float torque = 5f; // rotational force applied to  GameObject
    private Vector2 startPosition; // starting position of mouse when clicking
    private bool isDragging; // set to true when mouse is dragging the GameObject

    private Rigidbody2D rb; 
    private Collider2D col; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (col.OverlapPoint(mousePosition))
            {
                startPosition = mousePosition;
                isDragging = true;
            }
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ThrowObject(startPosition, endPosition);
            isDragging = false;
        }
    }

    // Method to throw the GameObject with mouse movement
    private void ThrowObject(Vector2 start, Vector2 end)
    {
        Vector2 direction = (end - start).normalized;
        float distance = Vector2.Distance(start, end);

        rb.AddForce(new Vector2(direction.x * throwForce * distance, direction.y * throwForce * distance));
        rb.AddTorque(torque * distance, ForceMode2D.Impulse);
    }

    // Event handler to detect collision with the "MenTwo" GameObject
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MenTwo"))
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = collision.transform.position;
        }
    }

    // When GameObject is outside of camera viewport becomes invisible
    void OnBecameInvisible()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
