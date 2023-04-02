using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaningMenScript : MonoBehaviour
{
    [SerializeField] private float throwForce = 10f; // throwing force applied to GameObject
    [SerializeField] private float torque = 5f; // The rotational force applied to GameObject
    private bool isDragging; // Set to true when  mouse is dragging GameObject
    private Vector2 startPosition;
    public Vector2 initialPosition { get; private set; } 
    private Rigidbody2D rb;
    private Collider2D col;
    public GameObject player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        initialPosition = transform.position; 
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("checkPoint"))
        {
            float playerHeight = player.GetComponent<Collider2D>().bounds.size.y;
            float checkpointHeight = collision.transform.GetComponent<Collider2D>().bounds.size.y;
            Vector3 checkpointPosition = collision.transform.position;
            Vector3 newPosition = new Vector3(checkpointPosition.x, checkpointPosition.y + checkpointHeight / 2 + playerHeight / 2, checkpointPosition.z);
            transform.position = newPosition;
            
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
            rb.bodyType = RigidbodyType2D.Dynamic;

        }

        if (collision.collider.CompareTag("Goal"))
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = collision.transform.position;
            FindObjectOfType<WinCondition>().Win();
                        
        }
    }
    
    void OnBecameInvisible()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
    private void ThrowObject(Vector2 start, Vector2 end)
    {
        Vector2 direction = (end - start).normalized;
        float distance = Vector2.Distance(start, end);

        rb.AddForce(new Vector2(direction.x * throwForce * distance, direction.y * throwForce * distance));
        rb.AddTorque(torque * distance, ForceMode2D.Impulse);
    }
    }