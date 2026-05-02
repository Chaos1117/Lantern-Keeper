using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    Rigidbody rb;
    public int speed;

    public int maxFuel = 100;
    public int currentFuel;

    public FuelBar FuelBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joystick = Object.FindFirstObjectByType<Joystick>();
        rb = GetComponent<Rigidbody>();
        currentFuel = maxFuel;
        FuelBar.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(joystick.Horizontal * speed, rb.linearVelocity.y, joystick.Vertical * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }
    }


    public void TakeDamage(int damage)
    {
        currentFuel -= damage;
        FuelBar.SetFuel(currentFuel);
    }
}
