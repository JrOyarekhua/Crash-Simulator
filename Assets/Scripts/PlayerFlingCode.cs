using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class FlingController : MonoBehaviour
{
    [Header("Sliders")]
    public Slider massSlider;
    public Slider speedSlider;



    private Rigidbody2D rb;
    private Vector2 startDragPos;
    private Vector2 launchDirection;
    private float launchForce;
    public TextMeshProUGUI distanceText;

    private Vector2 startPosition;
    private float maxDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateMass();
        startPosition = rb.position;

        // Hook slider change events
        massSlider.onValueChanged.AddListener(delegate { UpdateMass(); });
    }

    void Update()
    {
        HandleInput();

        // Distance traveled
        float dist = Vector2.Distance(startPosition, rb.position);
        if (dist > maxDistance) maxDistance = dist;
        distanceText.text = $"Current Speed: {maxDistance:F2} m/s";
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragVector = startDragPos - endDragPos;

            launchDirection = dragVector.normalized;
            launchForce = dragVector.magnitude * speedSlider.value;

            rb.linearVelocity = launchDirection * launchForce;

            // Reset distance
            startPosition = rb.position;
            maxDistance = 0;

        }
        
    }

    void UpdateMass()
    {
        rb.mass = massSlider.value;
    }
}
