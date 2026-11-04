using UnityEngine;

public class SpawnTrapLogic : MonoBehaviour
{
    public GameObject trapPrefab;
    public int MinHvalue, MaxHvalue;
    public int MinVvalue, MaxVvalue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnTrap", 1, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnTrap()
    {
        GameObject SpawnedTrap = Instantiate(trapPrefab, transform.position, transform.rotation);
        int RandomHvalue = Random.Range(MinHvalue, MaxHvalue);
        int RandomVvalue = Random.Range(MinVvalue, MaxVvalue);
        SpawnedTrap.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomHvalue*20, RandomVvalue*20));
        Destroy(SpawnedTrap, 12);
    }
}
