using UnityEngine;
using TMPro;
using System;
using Unity.Profiling;

public class TextAnimate : MonoBehaviour
{
	public enum AnimationType
	{
		MovementAndTransparency,
		TypeWriter
	}
	public AnimationType animationType = AnimationType.MovementAndTransparency;
    public RectTransform animTransform;
    public TextMeshProUGUI animText;
    public int FramesToTransition; // How many frames should the whole animation take
    public int Delay; 
    public Vector3 initPosition;
    public Vector3 finalPosition;
	public float initOpacity;
	public float finalOpacity;
	public int CursorTime;
	public bool destroyOnAnimate = false;

	private int currentFrame = 0; // Frame no. for animation purposes
	private int trueFrame; 
	private bool isAnimating = false;
	private string originalText;
	private string currentText = "";
	private bool TypeToggle;

	private void Start() 
	{
		trueFrame = -1; // Initializes at -1 because gets updated at the START of every frame 
		//Initialise properties to prevent "jumping"
		if (animationType == AnimationType.MovementAndTransparency)
		{
			animTransform.anchoredPosition = initPosition;
			animText.faceColor = new Color32(animText.faceColor.r, animText.faceColor.g, animText.faceColor.b, (byte)initOpacity);
		}
		if (animationType == AnimationType.TypeWriter)
		{
			originalText = animText.text;
			animText.text = " ";
		}
		// Debug.Log(originalText);
		 //Debug.Log(animText.text); // TextMeshPro can be tedious sometimes lol
	}
	void Update()
	{
		trueFrame++;
		
		if (!isAnimating)
		{

			// Delay
			if (trueFrame > Delay)
			{
				isAnimating = true;
			}
			else
			{
				return;
			}
		}
		if (animationType == AnimationType.MovementAndTransparency)
		{

			// Helps track how much animation completed (smoothly)
			float progress = EaseInOut(currentFrame / (float)FramesToTransition);
			//Debug.Log(progress);

			// Set the position and opacity of the RectTransform
			animTransform.anchoredPosition = Vector3.Lerp(initPosition, finalPosition, progress);

			// Set the color and opacity of the TextMeshProUGUI
			animText.faceColor = new Color32(animText.faceColor.r, animText.faceColor.g, animText.faceColor.b, (byte)Mathf.Lerp(initOpacity, finalOpacity, progress));

			currentFrame++;

			if (currentFrame > FramesToTransition)
			{
				// If we've reached the end of the animation, stop animating and set the final position and opacity
				animTransform.anchoredPosition = finalPosition;
				animText.faceColor = new Color32(animText.faceColor.r, animText.faceColor.g, animText.faceColor.b, (byte)finalOpacity);
				isAnimating = false;
				if (destroyOnAnimate)
				{
					Destroy(gameObject);
				}
			}
			
		}
		if (trueFrame > 0 && CursorTime > 0 && trueFrame % CursorTime == 0) // The ">0" conditions are to prevent a runtime divide by zero error which is occuring even though CursorTime has a constant nonzero value
		{
			TypeToggle = !TypeToggle;
		}
		if (animationType == AnimationType.TypeWriter)
		{
			if (currentFrame > FramesToTransition)
			{
				// If we've reached the end of the animation, stop animating
				isAnimating = false;
				if (TypeToggle)
					animText.text = originalText + "_";
				if (!TypeToggle)
					animText.text = originalText;
				if (destroyOnAnimate)
				{
					Destroy(gameObject);
				}
				return; 
			}
			currentFrame++;
			if(Mathf.RoundToInt(currentFrame * originalText.Length / FramesToTransition) < originalText.Length) // Prevents runtime errors where an index higher thn the original text length is requested
			currentText = originalText.Substring(0, Mathf.RoundToInt(currentFrame*originalText.Length/FramesToTransition));
			currentText += "_";
			animText.text = currentText;
		}
	}
	float EaseInOut(float t)
	{
		return t < 0.5 ? 2 * t * t : -1 + (4 - 2 * t) * t;
	}
}
