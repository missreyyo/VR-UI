using UnityEngine;

public class EditorInput : MonoBehaviour {

#if UNITY_EDITOR

    private const float MAX_PITCH_ANGLE = 85;
    private const string MOUSE_X_AXIS_KEY = "Mouse X";
    private const string MOUSE_Y_AXIS_KEY = "Mouse Y";

    public Transform cameraTransform;
	public KeyCode modifierKey = KeyCode.LeftAlt;
    public float mouseXSpeed = 6;
    public float mouseYSpeed = 3;

    private Vector3 eularAngles = new Vector3();

	private void Update() {

        // If we are using the look functionality
		if (Input.GetKey(modifierKey)) {

            // Calculate the heading using the mouse X delta
            eularAngles.y += Input.GetAxis(MOUSE_X_AXIS_KEY) * mouseXSpeed;
            eularAngles.y = Mathf.Abs(eularAngles.y) > 180
                ? eularAngles.y -= Mathf.Sign(eularAngles.y) * 360
                : eularAngles.y;

            // Calculate the pitch using the mouse Y delta and clamp to avoid gimble lock
            eularAngles.x -= Input.GetAxis(MOUSE_Y_AXIS_KEY) * mouseYSpeed;
            eularAngles.x = Mathf.Clamp(eularAngles.x, -MAX_PITCH_ANGLE, MAX_PITCH_ANGLE);

            // Apply the changes to the camera
            cameraTransform.localEulerAngles = eularAngles;
        }
    }

#endif
}
