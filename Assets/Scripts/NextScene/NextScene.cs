using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.CompareTag("Player")) SceneChanger.LoadNextChamber();
    }
}
