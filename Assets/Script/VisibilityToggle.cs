using UnityEngine;
using TMPro;

public class VisibilityToggle : MonoBehaviour {

    public GameObject objectToToggle;
    public OVRInput.Button toggleButton;

    private bool isDownPrevious = false;
    private bool isDown = false;

    private void Update() {

        isDownPrevious = isDown;
        isDown = OVRInput.GetDown(toggleButton);
        if (isDown != isDownPrevious && isDown) {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
