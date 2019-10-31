using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour {

    public Transform Image;

	void Update () {
        Image.Rotate(Vector3.forward * 300 * Time.deltaTime);
	}
}
