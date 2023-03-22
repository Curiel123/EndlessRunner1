using System;
using UnityEngine;
using UnityEngine.UI; // Visual Studio is struggling to understand that this namespace indeed exists, please ignore these errors in VS because it works in Unity.


public class FadeOutImage : MonoBehaviour
{
    public int FramesToFade =60;
	public Image FadeOutAsset; // If there's an "error" here, refer to comment on Line 3
    [Tooltip("Children to be liberated will have this parent")]
    public Transform NewParent; // Children to be liberated will have this parent
	private float TotalOpacity;
    private int TrueFrame = -1; // We need to disable splash once animation is complete.
    private Transform[] children;

    void Awake()
    {
		TotalOpacity = FadeOutAsset.color.a; // This prevents "jumping" to a preset opacity
    }

    void Update()
    {
        TrueFrame++;
        FadeOutAsset.color = new Vector4(FadeOutAsset.color.r, FadeOutAsset.color.g, FadeOutAsset.color.b, FadeOutAsset.color.a - (TotalOpacity / FramesToFade));
        if (TrueFrame > FramesToFade)
        {
            // Liberate the children before destroying FadeOutImage
            children = gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < children.Length; i++)
			{
                children[i].SetParent(NewParent, true);
			}
            GameObject.Destroy(gameObject);
		}
    }
}
