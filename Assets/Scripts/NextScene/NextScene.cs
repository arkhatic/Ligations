using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {
    public bool canChangeScene = true;
    public ButtonPlate button;
    public bool useButton = true;

    private void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.CompareTag("Player") && canChangeScene) { 
            if (useButton) {
                if (button.isPressed) SceneChanger.LoadNextChamber();
                return; 
            }
            SceneChanger.LoadNextChamber();
        }
    }
}
