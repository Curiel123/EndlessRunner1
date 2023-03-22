using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
    public PlayerMovement Player;
    public TextMesh distanceText;
	public Transform distanceTracker;
	public int distanceIntervals;

	private int count; // How many intervals

	private void Start()
	{
		count = 1;
		distanceText.text = distanceIntervals.ToString();
	}

	private void Update()
	{
		Player.DistanceCalculator();

		if (-(Player.distanceTravelled.x + ((count-1)*distanceIntervals))/2 > distanceIntervals) { 
			count++;
			distanceText.text = (count*distanceIntervals).ToString();
			distanceTracker.position = new Vector3(distanceTracker.position.x - distanceIntervals, distanceTracker.position.y, distanceTracker.position.z);
		}
	}
}
