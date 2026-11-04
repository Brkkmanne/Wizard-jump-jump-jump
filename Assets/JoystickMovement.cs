using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class JoystickMovement : MonoBehaviour
{
    public Joystick Joy;
    public Button JumpButton;
    public float speed;
    public int JumpForce;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    AudioSource audio;
    public AudioClip JumpSound;
    public AudioClip HoverSound;
    public float hJoy, vJoy;
    public bool IsHovering = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        InvokeRepeating("Hover", 0, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        hJoy = Joy.Horizontal;
        vJoy = Joy.Vertical;
        if (hJoy > 0)
        {
            sprite.flipX = false;
        }
        else if (hJoy < 0)
        {
            sprite.flipX = true;
        }
        if (hJoy > 0.2)
        {
            anim.SetBool("isRunning", true);
        }
        else if (hJoy < -0.2)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        transform.Translate(hJoy * Vector2.right * speed * Time.deltaTime);
        if (vJoy >= 0.8 || vJoy < 0)
        {
            rb.AddForce(vJoy * Vector2.up * JumpForce);
            if (vJoy >= 0.8)
            {
                IsHovering = true;
            }
        }
        else
        {
            IsHovering = false;
        }
        new WaitForSeconds(0.1f);
    }

    public void Hover()
    {
        if(IsHovering == true)
        {
            audio.clip = HoverSound;
            audio.Play();
        }
        
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce * 100);
        audio.clip = JumpSound;
        audio.Play();
    }
}
