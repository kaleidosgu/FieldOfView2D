using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody2D rigidbody;
	Camera viewCamera;
	Vector3 velocity;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		viewCamera = Camera.main;
	}

	void Update () {
		Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        //Debug.Log(mousePos);
        //Vector3 newMousePos = mousePos + Vector3.forward * transform.position.z;
        Vector3 newMousePos = new Vector3(mousePos.x,0,0);
        //Vector3 newMousePos = mousePos + Vector3.up * transform.position.y;
        //newMousePos.z = 0;
        //transform.LookAt(newMousePos);
        velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical"),0 ).normalized * moveSpeed;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

	void FixedUpdate() {
		rigidbody.MovePosition (rigidbody.transform.position + velocity * Time.fixedDeltaTime);
	}
}