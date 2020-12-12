using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public Text Scoretext;
    private int score;
    private int runDistance;

    private int minWidthNewGround, maxWidthNewGround;
    private int minHeightNewGround, maxHeightNewGround;
    private int posXNewGround, minPosYNewGround, maxPosYNewGround;

    private void Start()
    {
        score = 0;
        Scoretext.text = $"Score: {score}";
        
        runDistance = 0;

        minWidthNewGround = 2;
        maxWidthNewGround = 7;
        minHeightNewGround = 1;
        maxHeightNewGround = 5;

        posXNewGround = 12;
        minPosYNewGround = 3;
        maxPosYNewGround = 5;

        InvokeRepeating("SpawnPlatforms", 1.5f, 1.5f);
        InvokeRepeating("ChangeRunDistance", 0.2f, 0.2f);
    }

    public int GetPlayerSpeed() => Player.GetComponent<PlayerController>().GetPlayerMover().Speed;
    public void RestartScene() => SceneManager.LoadScene(0);

    public void ChangeScore(int scoreChange)
    {
        score += scoreChange;
        Scoretext.text = $"Score: {score}";
    }

    private void SpawnPlatforms()
    {
        CreatePlatform(minWidthNewGround, maxWidthNewGround, minHeightNewGround, maxHeightNewGround, minPosYNewGround, maxPosYNewGround);
        CreatePlatform(minWidthNewGround, maxWidthNewGround, minHeightNewGround, maxHeightNewGround, -minPosYNewGround, -maxPosYNewGround);

        if (Random.Range(0, 3) == 0)
            SpawnEnemy();
    }

    private void CreatePlatform(int minWidth, int maxWidth, int minHeight, int maxHeight, int minPosY, int maxPosY)
    {
        GameObject ground = Instantiate(Resources.Load("Ground") as GameObject);
        ground.transform.localScale = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
        ground.transform.position = new Vector2(posXNewGround, Random.Range(-maxPosY, -minPosY));
        ground.transform.SetParent(transform.parent);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(Resources.Load("Enemy") as GameObject);
        enemy.transform.position = new Vector2(11f, Random.Range(0f, 1f));
        enemy.transform.SetParent(transform.parent);
        enemy.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(-GetPlayerSpeed(), 0f);
    }

    private void ChangeRunDistance()
    {
        runDistance++;
        ChangeScore(1);

        if (runDistance > 0f && runDistance % 50 == 0)
            Player.GetComponent<PlayerController>().GetPlayerMover().IncrementSpeed();
    }
}