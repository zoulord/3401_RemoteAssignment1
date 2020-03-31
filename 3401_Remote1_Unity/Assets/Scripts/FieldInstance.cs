using UnityEngine;


public class FieldInstance : MonoBehaviour
{
    #region Variables

    private float _moveSpeed;
    private static float _despawnXPosition = -35;
    
    #endregion Variables
    
    
    #region Initialization

    /// <summary>
    /// Initializes the instance
    /// Called from ObstacleController
    /// </summary>
    public void Initialize(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    #endregion Initialization


    #region Update

    /// <summary>
    /// Called every frame
    /// </summary>
    private void Update()
    {
        // Move this obstacle to the left
        transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
        
        // Should we despawn yet?
        if (transform.position.x <= _despawnXPosition)
        {
            Destroy(gameObject);
        }
    }

    #endregion Update
}
