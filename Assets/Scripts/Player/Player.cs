using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    public float speed = 6f;
    public float jumpHeight = 8f;
    public Transform[] sensors;
    public GameObject polarObject;
    public GameObject apolarObject;
    [HideInInspector] public bool isGrounded;

    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] LayerMask groundMask;
    private TextMeshProUGUI polarText;
    private TextMeshProUGUI apolarText;
    private float horizontal;
    private Rigidbody2D body;
    private Box polarBox;
    private Box apolarBox;
    
    private void Start() {
        body = GetComponent<Rigidbody2D>();

        if (GameObject.Find("Polar Box") || GameObject.Find("Apolar Box")) {
            polarBox = polarObject.GetComponent<Box>();
            apolarBox = apolarObject.GetComponent<Box>();

            polarText = polarObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            apolarText = apolarObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }

    private void Jump() =>  body.velocity = new Vector2(body.velocity.x, jumpHeight);
    private void FastFall() =>  body.velocity = new Vector2(body.velocity.x, -12);
    private bool CheckGrounded() {
        foreach (Transform sensor in sensors) {
            Vector2 position = sensor.position;
            Vector2 forward = sensor.forward;
            RaycastHit2D hit = Physics2D.Raycast(position, forward, groundCheckDistance, groundMask);
            if (hit.collider != null) return true;
        }
        return false;
    }

    private void Update() {
        isGrounded = CheckGrounded();
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isGrounded) Jump();
        else if (Input.GetKey(KeyCode.S) && !isGrounded) FastFall();
        if (Input.GetKeyDown(KeyCode.Backspace)) SceneChanger.LoadNextChamber();

        // if (GameObject.Find("Polar Box") == null && GameObject.Find("Apolar Box") == null) return;
        apolarText.text = "push me!";

        if (polarBox.colliding && Input.GetMouseButton(0)) {
            polarObject.transform.position = new Vector3(
                transform.position.x + (polarObject.transform.position.x > transform.position.x ? 1.52f : -1.52f), 
                transform.position.y + 0.108f, 
                transform.position.z
            );
            polarText.text = "aiaiai";
        } 
        else polarText.text = "pull me!";
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }
}
