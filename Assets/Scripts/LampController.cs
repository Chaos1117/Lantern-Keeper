using UnityEditor.VisionOS;
using UnityEngine;

public class LampController : MonoBehaviour
{

    public Light lampLight;
    private bool activated = false;
    public AudioSource activateSound;

    private void OnTriggerEnter(Collider other)
    {
        if(activated)
        {
            return;
        }

        if(other.CompareTag("Player"))
        {
            ActivateLamp();
        }
    }

    void ActivateLamp()
    {
        activated = true;
        lampLight.intensity = 10f;
        GameManager.gm.ActivateLamp();
        AudioSource.PlayClipAtPoint(activateSound.clip, transform.position);
    }
}
