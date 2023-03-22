using UnityEngine;
using TMPro;

public class StatManager : MonoBehaviour
{

	public float timeElapsed; // Total Time *in seconds*
	public float distanceTraveled;
	public float points;
	public TextMeshProUGUI timeText;
	public PlayerMovement player;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject); // This object can transcend scene loads
		timeElapsed = 0;
		distanceTraveled = 0;
		points = 0;
	}


	private void Update()
	{
		distanceTraveled =-(player.distanceTravelled.x+50f); // Remember that distance tracker is already calling the DistanceCalculator function every frame so there is no need to do it here
		timeElapsed += Time.deltaTime;
		points = player.currency;

		if (timeElapsed > 60)
		{
			timeText.text = Mathf.Floor(timeElapsed / 60) + ":" + Mathf.Floor(timeElapsed % 60);
		}
		else
		{
			timeText.text = "00:" + Mathf.Floor(timeElapsed);
		}
		//Debug.Log("d= " + distanceTraveled + " t = " + timeElapsed + " p= " + points);
	}
}
