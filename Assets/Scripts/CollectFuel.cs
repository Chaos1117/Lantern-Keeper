using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    public AudioSource collectSound;
    public int fuelAmount = 25;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Add fuel
            other.GetComponent<PlayerController>().AddFuel(fuelAmount);
            AudioSource.PlayClipAtPoint(collectSound.clip, transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
        transform.position += Vector3.up * Mathf.Sin(Time.time) * 0.001f;
    }
}
