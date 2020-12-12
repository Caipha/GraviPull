using UnityEngine;

public class PlayerColliderDetector : MonoBehaviour
{
    public bool InAir{ get; private set; }
    public bool GravityChanged { get; private set; }

    private Rigidbody2D rigidBody;

    private void Start()
    {
        InAir = false;
        GravityChanged = false;
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    internal void Jump(int jumpStrength)
    {
        int realJumpStrength = rigidBody.gravityScale > 0 ? jumpStrength : -jumpStrength;

        rigidBody.velocity = new Vector2(rigidBody.velocity.x, realJumpStrength);
        InAir = true;
    }

    internal void ChangeGravity()
    {
        rigidBody.gravityScale = -rigidBody.gravityScale;
        rigidBody.velocity = new Vector2(0f, 0f);
        GravityChanged = true;
    }

    private void GroundHit()
    {
        InAir = false;
        GravityChanged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GroundHit();

        if (collision.gameObject.tag == "Deadzone")
            GameObject.Find("GameManager").GetComponent<GameManager>().RestartScene();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            GameObject.Find("GameManager").GetComponent<GameManager>().RestartScene();
    }
}