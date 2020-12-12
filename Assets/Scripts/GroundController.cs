using UnityEngine;

public class GroundController : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() => gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    private void Update()
    {
        transform.position = new Vector2(transform.position.x - gameManager.GetPlayerSpeed() * 0.001f, transform.position.y);

        if (transform.position.x < -20f)
            Destroy(gameObject);
    }
}