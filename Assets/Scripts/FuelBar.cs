using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;

    public Image Fill;

    public void SetMaxFuel(int fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;

        Fill.color = gradient.Evaluate(1f);
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
