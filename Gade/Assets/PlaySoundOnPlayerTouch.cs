using UnityEngine;

public class PlaySoundOnPlayerTouch : MonoBehaviour
{
    public AudioClip playerTouchSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüfen, ob das berührte GameObject den Tag "Player" hat
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(playerTouchSound); 
        }
    }
}
