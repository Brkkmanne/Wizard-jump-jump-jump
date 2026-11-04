using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerPoints : MonoBehaviour
{
    public int CurrentPoints, PointsToWin;
    public TMP_Text PointsText;
    public GameObject WinPanel;
    AudioSource audio;
    public GameObject BackgroundMusic;
    public AudioClip WinMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PointsText.text = "Points: " + CurrentPoints;
        if (CurrentPoints >= PointsToWin)
        {
            WinPanel.SetActive(true);
            BackgroundMusic.SetActive(false);
            Time.timeScale = 0;
        }
        new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            CurrentPoints++;
            Destroy(collision.gameObject);
        }
    }
}
