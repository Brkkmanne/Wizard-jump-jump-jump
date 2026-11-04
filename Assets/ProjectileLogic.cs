using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public int speed;
    public int direction;
    public bool IsHit=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector2.right * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            GameObject enemy = collision.gameObject;
            Destroy(enemy);
        }
            Destroy(gameObject);
    }
}
