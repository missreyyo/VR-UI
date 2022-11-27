using UnityEngine;
using TMPro;

public class DMMMover : MonoBehaviour {

    public Transform container;
    public float speed = 2;
    public float minimumDepth = 0.3f;
    public float maximumDepth = 10f;
    public TextMeshProUGUI textOutput;

    private Vector2 thumbStickPrevious = new Vector2();
    private Vector2 thumbStick = new Vector2();
    private float distance = 1;

    private void Start() {
        Layout();
    }

    private void Update() {

        // Get the Oculus controller input
        thumbStickPrevious = thumbStick;
        thumbStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // If we have change, calculate distance and layout
        if (!Mathf.Approximately(thumbStick.y, thumbStickPrevious.y)) {
            distance += Time.deltaTime * speed * thumbStick.y;
            distance = Mathf.Clamp(distance, minimumDepth, maximumDepth);
            Layout();
        }
    }

    private void Layout() {
        // Set position
        Vector3 position = transform.localPosition;
        position.z = distance;
        transform.localPosition = position;

        // Set Scale
        Vector3 scale = new Vector3(distance * 0.001f, distance * 0.001f, distance * 0.001f);
        transform.localScale = scale;

        // Render text
        textOutput.text = distance.ToString("###,###,##0.000");
    }
}
