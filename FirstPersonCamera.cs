using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FirstPersonCamera : MonoBehaviour
{
	Vector3 velocity;

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) Cursor.lockState = CursorLockMode.Locked;
		if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;

		Vector3 direction = default;

		if (Input.GetKey(KeyCode.W)) direction += Vector3.forward;
		if (Input.GetKey(KeyCode.S)) direction += Vector3.back;
		if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
		if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
		if (Input.GetKey(KeyCode.Space)) direction += Vector3.up;
		if (Input.GetKey(KeyCode.LeftControl)) direction += Vector3.down;

		direction = transform.TransformVector(direction);

		velocity = Vector3.Lerp(velocity, Vector3.zero, 0.01f);
		velocity += Input.GetKey(KeyCode.LeftShift) ? direction * 2 : direction;

		transform.position += velocity * Time.deltaTime;
		transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
	}
}