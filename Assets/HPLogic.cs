using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
public class HPLogic : MonoBehaviour
{
    public Slider HealthSlider;
    AudioSource audio;
    public AudioClip HitSound;
    public GameObject LosePanel;
    public GameObject BackgroundMusic;
    public int MaxHP;
    int CurrentHP;
    void Start()
    {
        HealthSlider.maxValue = MaxHP;
        CurrentHP = MaxHP;
        audio = GetComponent<AudioSource>();
        LosePanel.SetActive(false);
    }
    void Update()
    {
        HealthSlider.value = CurrentHP;
        new WaitForSeconds(0.3f);
        if (CurrentHP < 1 )
        {
            LosePanel.SetActive(true);
            BackgroundMusic.SetActive(false);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            CurrentHP--;
            audio.clip = HitSound;
            audio.Play();
        }
    }
}
