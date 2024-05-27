using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR;

public class Player : MonoBehaviour
{

    [SerializeField] private float upforce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    private AudioSource audioDino;
    public AudioClip jump;
    public AudioClip die;
    

    private Rigidbody2D dinoRb;
    private Animator dinoAnimator;
    


    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
        audioDino = GetComponent<AudioSource>();
       
        
    }


    void Update()
    {

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        dinoAnimator.SetBool("Isgrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded)
            {
                dinoRb.AddForce(Vector2.up * upforce);
                audioDino.PlayOneShot(jump);
            }

        }
        

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dinoAnimator.SetTrigger("agachar");
        }
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            dinoAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
            audioDino.PlayOneShot(die);
        }
    }
}
