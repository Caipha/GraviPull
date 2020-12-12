using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int Speed { get; private set; }
    public int JumpStrength { get; private set; }

    private PlayerColliderDetector colliderDetector;

    private void Start()
    {
        Speed = 5;
        JumpStrength = 7;

        colliderDetector = transform.GetComponent<PlayerColliderDetector>();
    }

    public void JumpPressed() => CheckJump();

    public void IncrementSpeed() => Speed += 2;

    private void CheckJump()
    {
        if (colliderDetector.InAir && !colliderDetector.GravityChanged)
            colliderDetector.ChangeGravity();

        if (!colliderDetector.InAir)
            colliderDetector.Jump(JumpStrength);
    }
}