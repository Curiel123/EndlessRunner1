using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace HMProtect
{
    public class CamAnimate : MonoBehaviour
    {
        public Vector3 direction;
        [Tooltip("Leave all as '1' to add no secondary rotation")]
        public Vector3 SecondaryDirection = new Vector3(1f,1f,1f);
        public int probabilityOfSecondaryRotation = 20;
        public float magnitude;

        void Update()
        {
            transform.Rotate(direction.x*magnitude, direction.y *magnitude, direction.z *magnitude); // Primary rotation
            // Debug.Log(UnityEngine.Random.Range(0,10));
            if(UnityEngine.Random.Range(0,10)>((100-probabilityOfSecondaryRotation)/10)) // 20% chance secondary rotation occurs by default
			    transform.Rotate(SecondaryDirection.x * magnitude, SecondaryDirection.y * magnitude, SecondaryDirection.z * magnitude); 
		}
	}
}