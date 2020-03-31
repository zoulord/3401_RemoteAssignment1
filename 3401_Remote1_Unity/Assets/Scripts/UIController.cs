using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    #region Variables

    public GameObject healthHeart1;
    public GameObject healthHeart2;
    public GameObject healthHeart3;

    public Text pickupCountText;

    #endregion Variables
    

    #region Health

    /// <summary>
    /// Tells the ui controller how much health to display
    /// Called from PlayerController
    /// </summary>
    /// <param name="remainingHealth"></param>
    public void ReportHealth(int remainingHealth)
    {
        // Deactivate all at first
        healthHeart1.SetActive(false);
        healthHeart2.SetActive(false);
        healthHeart3.SetActive(false);
        
        // Activate depending on the number of hits remaining
        if (remainingHealth == 3)
        {
            healthHeart1.SetActive(true);
            healthHeart2.SetActive(true);
            healthHeart3.SetActive(true);
        }
        else if (remainingHealth == 2)
        {
            healthHeart1.SetActive(true);
            healthHeart2.SetActive(true);
            healthHeart3.SetActive(false);
        }
        else if (remainingHealth == 1)
        {
            healthHeart1.SetActive(true);
            healthHeart2.SetActive(false);
            healthHeart3.SetActive(false);  
        }
        else
        {
            healthHeart1.SetActive(false);
            healthHeart2.SetActive(false);
            healthHeart3.SetActive(false);
        }
    }

    #endregion Health
    
    
    #region Pickup
    
    /// <summary>
    /// Updates the pickup count in the UI
    /// </summary>
    /// <param name="count"></param>
    public void ReportPickupCount(int count)
    {
        pickupCountText.text = count.ToString();
    }
    
    #endregion Pickup
}
