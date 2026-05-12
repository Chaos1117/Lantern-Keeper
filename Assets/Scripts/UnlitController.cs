using UnityEngine;

public class UnlitController : MonoBehaviour
{

    public Transform player;
    public float moveSpeed;
    public float lightDist = 7f;

    public int damageAmount = 5;
    public float damageRate = 1f;
    private float damageTimer;

    private Rigidbody rb;
    private Renderer rend;

    public float freezeTime = 2f;
    private bool isFrozen = false;
    private float freezeTimer;

    public AudioSource freezeAudio;
    public AudioSource unlitAudio;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //freeze in lamp light
        if(isFrozen)
        {
            HandleFreeze();
            return;
        }

        //only move when not in lantern light
        if(distanceToPlayer <= lightDist)
        {
            rb.linearVelocity = Vector3.zero;
            rend.material.color = Color.gray;
            return;
        }

        rend.material.color = Color.black;
        transform.LookAt(player);
        MoveTowardPlayer();
        HandleDamage();
        
    }

    void MoveTowardPlayer()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void HandleFreeze()
    {
        freezeTimer -= Time.deltaTime;
        rb.linearVelocity = Vector3.zero;
        rend.material.color = Color.gray;
        AudioSource.PlayClipAtPoint(freezeAudio.clip, transform.position);

        if (freezeTimer <= 0)
        {
            isFrozen = false;
        }
    }

    void HandleDamage()
    {
        damageTimer += Time.deltaTime;

        if(damageTimer >= damageRate)
        {
            if(Vector3.Distance(transform.position, player.position) <= 1.5f)
            {
                player.GetComponent<PlayerController>().TakeDamage(damageAmount);
                AudioSource.PlayClipAtPoint(unlitAudio.clip, transform.position);
            }

            damageTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ActivatedLamp"))
        {
            ActivateFreeze();
        }
    }

    void ActivateFreeze()
    {
        isFrozen = true;
        freezeTimer = freezeTime;
        rb.linearVelocity = Vector3.zero;
    }

}
