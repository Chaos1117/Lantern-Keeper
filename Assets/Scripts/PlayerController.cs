using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    Rigidbody rb;
    public int speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joystick = Object.FindFirstObjectByType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(joystick.Horizontal * speed, rb.linearVelocity.y, joystick.Vertical * speed);
    }
}
