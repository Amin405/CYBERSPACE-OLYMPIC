using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticles : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    public string targetTag = "Player"; // Tag als Parameter
    public Vector3 effectPosition = new Vector3(3.34f, -2.99f, -5f); // Position als Parameter
    public float destroyTime = 5.0f; // Zeit für das Zerstören als Parameter

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag(targetTag))
        {

            if (particleEffectPrefab == null)
            {
                Debug.LogError("Particle Effect Prefab wurde nicht zugewiesen");
                return;
            }

            GameObject particleEffectInstance = Instantiate(particleEffectPrefab, effectPosition, Quaternion.identity);
            if (particleEffectInstance != null)
            {
                Destroy(particleEffectInstance, destroyTime);
            }
            else
            {
                Debug.LogError("Fehler beim Instanziieren des Partikel-Systems");
            }
        }
    }
}