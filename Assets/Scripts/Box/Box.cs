using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour {
    public Transform sensor;
    public GameObject player;
    public LayerMask playerMask;
    public TextMeshProUGUI text;
    [HideInInspector] public bool colliding;
    [HideInInspector] public bool atRightFromPlayer;

    private readonly Vector2[] directions = { Vector2.right, Vector2.left, Vector2.up };
    private readonly float distanceToCollide = 1.7f;
    private readonly float offsetToDiffDir = 0.5f;
    private float collisionDistance;
    [SerializeField] private float distanceOffsetMultiplier;

    private float CollisionDistanceFromDirection(Vector2 direction) { 
        float distance = GetComponent<BoxCollider2D>().bounds.size.x + 3f;
        Debug.DrawRay(sensor.transform.position, direction * distance, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(
            sensor.transform.position, direction, distance, playerMask);
        if (hit.collider == null) return 0;
        return hit.distance;
    }
    
    private void Update() {
        // text
        float c(int i) => CollisionDistanceFromDirection(directions[i]);
        collisionDistance = c(0) + c(1) + c(2);
        colliding = (collisionDistance <= distanceToCollide && collisionDistance != 0); 
        text.fontSize = Mathf.RoundToInt(collisionDistance != 0 ? 30f / collisionDistance : 1);
        // Debug.Log($"Distance: {collisionDistance}, font size: {Mathf.RoundToInt(30f / collisionDistance)}");
        // Debug.Log(colliding);
        text.rectTransform.anchoredPosition = new Vector2(
            transform.position.x, transform.position.y + 59.82f - (collisionDistance * distanceOffsetMultiplier));
        
        // position check
        if (player.transform.position.x > transform.position.x + offsetToDiffDir) atRightFromPlayer = true;
        else atRightFromPlayer = false;

        // Debug.Log(atRightFromPlayer);
    }
}
