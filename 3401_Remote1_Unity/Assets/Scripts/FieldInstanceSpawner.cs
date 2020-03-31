using UnityEngine;
using Random = UnityEngine.Random;


public class FieldInstanceSpawner : MonoBehaviour
{
    #region Variables
    
    [Header("References")]
    public GameObject fieldPrefab;
    public Transform spawnGateTop;
    public Transform spawnGateBottom;
    
    [Header("Spawn")]
    public float initialSpawnRate;
    public float spawnRateIncrease;

    [Header("Speed")]
    public float initialSpeed;
    public float speedIncrease;
    public float maxSpeed;

    //
    private float _currentSpawnRate;
    private float _currentSpeed;

    #endregion Variables
    
    
    #region Initialization

    /// <summary>
    /// Used for initialization
    /// </summary>
    private void Start()
    {
        // Set initial rates
        _currentSpawnRate = initialSpawnRate;
        _currentSpeed = initialSpeed;
        
        // Spawn our 1st instance
        Invoke(nameof(SpawnInstance), Random.Range(0, (1/_currentSpawnRate)));
    }

    #endregion Initialization
    
    
    #region Spawn

    /// <summary>
    /// Spawns a new field instance
    /// </summary>
    private void SpawnInstance()
    {
        // Get randomized spawn position
        float spawnY = Random.Range(spawnGateTop.position.y, spawnGateBottom.position.y);
        Vector3 spawnPosition = new Vector3(spawnGateTop.position.x, spawnY, 0);
        
        // Spawn prefab
        GameObject thisInstance = Instantiate(fieldPrefab, spawnPosition, Quaternion.identity);
        
        // 50% chance we increase speed/spawnrate
        if (Random.value > 0.5f)
        {
            _currentSpawnRate += spawnRateIncrease;
            _currentSpeed += speedIncrease;
            
            // Clamp values so we don't go over max
            _currentSpeed = Mathf.Min(_currentSpeed, maxSpeed);
        }
        
        // Initialize the spawned instance
        thisInstance.GetComponent<FieldInstance> ().Initialize(_currentSpeed);
        
        // Spawn another instance
        Invoke(nameof(SpawnInstance), 1 / _currentSpawnRate);
    }
    
    #endregion Spawn
}
