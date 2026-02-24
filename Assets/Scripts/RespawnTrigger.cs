using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 playerRespawnPosition = new Vector2(0,2);
    [SerializeField] private Vector2 enemyRespawnPosition = new Vector2(-2,2);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerHealth>();
            if(player != null)
            {
                collision.transform.position = playerRespawnPosition;
            }
            }
            else if (collision.CompareTag("Enemy"))
            {
                var enemy = collision.GetComponent<EnemyAI>();
                if(enemy != null)
                {
                    collision.transform.position = enemyRespawnPosition;
                }
            }
        }
    }
 
