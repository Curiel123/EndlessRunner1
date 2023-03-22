using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    public enum Type
    {
        Fuel,
        HullIntegrity
    }
    public Image Slider;           //Stores the slider.
    public Type type;
    public PlayerMovement player;
    public float MaxValue = 0.91f;
    public float MinValue = 0.34f;
    public Color MaxColor;
    public Color MinColor;

	private void Update()
	{
        if (type == Type.HullIntegrity)
        {
			Slider.color = Color.Lerp(MinColor, MaxColor, player.playerHealth/3);
			Slider.fillAmount = Mathf.Lerp(MinValue, MaxValue, player.playerHealth/3);

			if (player.playerHealth <= 0f) // Keep this inside conditional statement to avoid conflict loading when there are more than one instances of sliders in the scene.
			{
				SceneManager.LoadScene("FinalResults");
			}
		}
	}


	//Sets the value of the slider to the float passed in (fuel, from player script)
	public void SetFuel(float fuel)
    {
        Slider.color = Color.Lerp(MinColor, MaxColor, fuel/100);
        Slider.fillAmount = Mathf.Lerp(MinValue, MaxValue, fuel / 100);
        if (fuel <= 0)
        {
			SceneManager.LoadScene("FinalResults");
		}
    }
}
