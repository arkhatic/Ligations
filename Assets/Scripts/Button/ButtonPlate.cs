using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlate : MonoBehaviour {
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    [HideInInspector] public bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) isPressed = !isPressed;
    }

    private void Update() {
        spriteRenderer.color = (isPressed) ? Color.yellow : Color.red;
    }
}
