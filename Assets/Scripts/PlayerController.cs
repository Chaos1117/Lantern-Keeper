using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    Rigidbody rb;
    public int speed;

    public int maxFuel = 100;
    public float currentFuel;
    public float fuelDrainRate = 3f;

    public FuelBar FuelBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joystick = Object.FindFirstObjectByType<Joystick>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentFuel = maxFuel;
        FuelBar.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        rb.linearVelocity = new Vector3(joystick.Horizontal * speed, rb.linearVelocity.y, joystick.Vertical * speed);
        var input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if(input != Vector3.zero)
        {
            transform.forward = input;
        }

        //Fuel Drain
        DrainFuel();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }

        if(currentFuel <= 0)
        {
            GameManager.SetCurrentLevel(SceneManager.GetActiveScene().name); //saves current level
            SceneManager.LoadScene("Lose");
        }
    }

    void DrainFuel()
    {
        currentFuel -= fuelDrainRate * Time.deltaTime;
        //prevents fuel above 100 or below 0
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        FuelBar.SetFuel((int)currentFuel);
    }

    public void TakeDamage(int damage)
    {
        currentFuel -= damage;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        FuelBar.SetFuel((int)currentFuel);
    }

    public void AddFuel(int amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        FuelBar.SetFuel((int)currentFuel);
    }
}
