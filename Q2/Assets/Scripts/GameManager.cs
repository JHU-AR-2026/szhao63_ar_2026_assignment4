using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject startButton;
    public GameObject powerUp;

    private Rigidbody playerRigidbody;
    private PlayerControl playerControl;

    private int totalCollectibles;
    private int collectedCount = 0;

    void Awake()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerControl = player.GetComponent<PlayerControl>();

        // Disable movement and gravity before Start is pressed
        playerRigidbody.useGravity = false;
        playerControl.enabled = false;

        // Count all collectibles in the scene
        totalCollectibles =
            GameObject.FindGameObjectsWithTag("Collectible").Length;

        // Power-up should not be visible initially
        powerUp.SetActive(false);
    }

    public void StartGame()
    {
        playerRigidbody.useGravity = true;
        playerControl.enabled = true;

        startButton.SetActive(false);
    }

    public void CollectItem()
    {
        collectedCount++;

        if (collectedCount >= totalCollectibles)
        {
            powerUp.SetActive(true);
        }
    }
}