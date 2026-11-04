using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform ShootPointLeft, ShootPointRight;
    AudioSource audio;
    public AudioClip ShootSFX;
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot()
    {
        audio.clip = ShootSFX;
        audio.Play();
        if (sprite.flipX == false)
        {
            GameObject SpawnedBullet = Instantiate(bulletPrefab, ShootPointRight.position, ShootPointRight.rotation);
            SpawnedBullet.GetComponent<ProjectileLogic>().direction = 1;
            Destroy(SpawnedBullet, 2);
        }
        if (sprite.flipX == true)
        {
            GameObject SpawnedBullet = Instantiate(bulletPrefab, ShootPointLeft.position, ShootPointLeft.rotation);
            SpawnedBullet.GetComponent<ProjectileLogic>().direction = -1;
            Destroy(SpawnedBullet, 2);
        }

    }
}
