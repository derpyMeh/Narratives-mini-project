using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    // Reference to the player object
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Get direction to the player
            Vector3 directionToPlayer = transform.position - player.position;

            // Keep only the horizontal direction
            directionToPlayer.y = 0;

            // Check if direction vector is valid (non-zero)
            if (directionToPlayer.sqrMagnitude > 0.001f)
            {
                // Calculate the rotation required to face the player
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                // Smoothly rotate towards the target direction
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }

}
