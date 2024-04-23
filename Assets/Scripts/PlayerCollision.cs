using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab, getStarParticules;
    // Aumentar puntos al atravesar por completo el trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        int obstaclePoints = 1;

        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.GetComponent<Star>();

        if (star != null)
        {
            GameManager.Instance.AddScore(star.GetPoints());
            Instantiate(getStarParticules, star.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

        }
    }

    // Destruccion de objeto
    private void OnCollisionEnter2D()
    {
        GameManager.Instance.StopGame();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
