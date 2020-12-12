using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private GameObject bullet;

    private int bulletSpeed;
    private bool bulletAvailable;

    private void Start()
    {
        bulletSpeed = 30;
        bulletAvailable = true;
    }

    internal void FirePressed() => ShootBullet();

    private void ShootBullet()
    {
        if (bulletAvailable)
        {
            bullet = Instantiate(Resources.Load("Bullet") as GameObject);
            bullet.transform.position = new Vector2(transform.position.x + 1f, transform.GetChild(0).position.y);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
            bullet.GetComponent<BulletController>().onBulletDestroyed += GetBulletBack;
            
            bulletAvailable = false;
        }
    }

    private void GetBulletBack()
    {
        bulletAvailable = true;
        bullet.GetComponent<BulletController>().onBulletDestroyed -= GetBulletBack;
    }
}