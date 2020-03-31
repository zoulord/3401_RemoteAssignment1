using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("References")]
    public UIController uiController;

    [Header("Jump")]
    public KeyCode jumpInput;
    public float jumpForce = 10;
    
    [Header("Layers")]
    public int obstacleLayer;
    public int pickupLayer;

    private Rigidbody _rb;
    private int _remainingHealth = 3;
    private int _pickupsCollected = 0;

    #endregion Variables
    
    
    #region Initialization

    private void Start()
    {
        // Cache the rigidbody component
        _rb = GetComponent<Rigidbody>();
        
        // Tell the ui to display full health/no pickups
        _remainingHealth = 3;
        _pickupsCollected = 0;
        uiController.ReportHealth(_remainingHealth);
        uiController.ReportPickupCount(_pickupsCollected);
    }

    #endregion Initialization
    
    
    #region Update

    /// <summary>
    /// Called every frame
    /// </summary>
    private void Update()
    {
        // Listen for jump input
        if (Input.GetKeyDown(jumpInput))
        {
            Jump();
        }
    }

    #endregion Update
    
    
    #region Jump
    
    /// <summary>
    /// Jump logic goes here
    /// </summary>
    private void Jump()
    {
        // Zero out velocity before jumping
        _rb.velocity = Vector3.zero;

        // Add velocity for "jump" effect
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    #endregion Jump
    
    
    #region Collision

    /// <summary>
    /// Responds to collisions with trigger colliders
    /// </summary>
    /// <param name="other">The collider on the gameObject that we collided with</param>
    private void OnTriggerEnter(Collider other)
    {
        // Did we hit an obstacle or a pickup?
        if (other.gameObject.layer == obstacleLayer)
        {
            OnObstacleCollision();
        }
        else if (other.gameObject.layer == pickupLayer)
        {
            OnPickupCollision();
        }
        
        // Destroy the gameObject we collided with
        Destroy(other.gameObject);
    }
    
    
    /// <summary>
    /// When the player hits an obstacle, take away health
    /// Called from OnTriggerEnter
    /// </summary>
    private void OnObstacleCollision()
    {
        // Decrease health
        _remainingHealth -= 1;
        
        // Tell UI controller to update health
        uiController.ReportHealth(_remainingHealth);
        
        // Are we dead?
        if (_remainingHealth <= 0)
        {
            Debug.Log("Dead!");
        }
    }
    
    
    /// <summary>
    /// When the player hits a pickup coin
    /// Called from OnTriggerEnter
    /// </summary>
    private void OnPickupCollision()
    {
        _pickupsCollected += 1;
        uiController.ReportPickupCount(_pickupsCollected);
    }

    #endregion Collision
}
