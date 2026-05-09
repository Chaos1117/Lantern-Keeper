using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    Rigidbody rb;
    public int speed;

    public int maxFuel = 100;
    public float currentFuel;
    public float fuelDrainRate = 5f;

    public FuelBar FuelBar;

    public string loseScene;

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
        //Player Movement
        rb.linearVelocity = new Vector3(joystick.Horizontal * speed, rb.linearVelocity.y, joystick.Vertical * speed);

        //Fuel Drain
        DrainFuel();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }

        if(currentFuel <= 0)
        {
            SceneManager.LoadScene(loseScene);
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
