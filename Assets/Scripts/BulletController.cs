using UnityEngine;

public class BulletController : MonoBehaviour
{
    public delegate void OnBulletDestroyed();
    public event OnBulletDestroyed onBulletDestroyed;

    private GameManager gameManager;

    private void Start() => gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                gameManager.ChangeScore(10);
                Destroy(collision.gameObject);
            }

            onBulletDestroyed();
            Destroy(gameObject);
        }
    }
}