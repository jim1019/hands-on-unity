using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesCamera : MonoBehaviour 
{
	public GameObject target;
	// Use this for initialization
	void Start () {
		var camera = GetComponent<Camera>();
		print("WorldToScreenPoint:" + camera.WorldToScreenPoint(target.transform.position));
		print("WorldToViewportPoint:"+camera.WorldToViewportPoint(target.transform.position));
		print("worldToCameraMatrix:" + camera.worldToCameraMatrix.MultiplyPoint(target.transform.position));
		print("worldToLocalMatrix:" + transform.worldToLocalMatrix.MultiplyPoint(target.transform.position));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
