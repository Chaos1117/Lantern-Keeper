using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        GameManager.theScore += 50;
        Destroy(gameObject);
    }
}
