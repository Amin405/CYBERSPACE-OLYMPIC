using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenScript : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            cameraFollow.SetNewTarget(gameObject);
        }
    }

}
