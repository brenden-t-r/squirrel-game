using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTree : MonoBehaviour
{
	[HideInInspector] public bool playEnabled;
	[SerializeField] private float speed = 4f;
	private Vector3 StartPosition;

void Start() {
	StartPosition = transform.position;
}

void Update() {
	if (!playEnabled) return;
	transform.Translate(Vector3.down * speed * Time.deltaTime);
	if (transform.position.y <= -5.4) {
		transform.position = StartPosition;
	}
}
}
