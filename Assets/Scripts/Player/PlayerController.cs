using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private delegate void OnJumpPressed();
    private OnJumpPressed onJumpPressed;
    private delegate void OnFirePressed();
    private OnFirePressed onFirePressed;

    private PlayerMovement playerMover;
    private PlayerShooter shooter;

    private void Awake()
    {
        shooter = transform.GetComponent<PlayerShooter>();
        playerMover = transform.GetChild(0).GetComponent<PlayerMovement>();

        onFirePressed = shooter.FirePressed;
        onJumpPressed = playerMover.JumpPressed;
    }

    private void Update() => CheckForInput();

    private void CheckForInput()
    {
        if (Input.GetButtonDown("Jump"))
            onJumpPressed();
        if (Input.GetButtonDown("Shoot"))
            onFirePressed();
    }

    public PlayerMovement GetPlayerMover() => playerMover;
}