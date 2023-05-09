using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCollision : MonoBehaviour
{
    public GameObject player;
    public AudioClip collisionSound1;
    public AudioClip collisionSound2;
    public AudioClip collisionSound3;
    [SerializeField] private LeaningMenScript dudeScript;

    private AudioSource audioSource;
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionCount++;
            
            AudioClip currentSound;
            int soundSelector = collisionCount % 3;
            switch (soundSelector)
            {
                case 0:
                    currentSound = collisionSound1;
                    break;
                case 1:
                    currentSound = collisionSound2;
                    break;
                case 2:
                    currentSound = collisionSound3;
                    break;
                default:
                    currentSound = collisionSound1;
                    break;
            }

            audioSource.PlayOneShot(currentSound); 

            player.transform.position = dudeScript.initialPosition;
            dudeScript.Reset();
            player.SetActive(true);
        }
    }
}
