using System;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    public class SparrowBehavior: MonoBehaviour
    {
        // Store the animator component of the character
        private Animator anim;
        private InputAction flyAction;
        private Rigidbody rb;
        private float jumpForce = 4f;
        private bool jumpCoolDown = false;
        private Vector3 spawnPos = new Vector3(10f, 5f, - 12f);

        [SerializeField] private SoundManager soundManager;
        [SerializeField] private GameObject lookUpPoint;
        [SerializeField] private GameObject lookDownPoint;
        [SerializeField] private AudioClip flySound;
        [SerializeField] private AudioClip coinSound;
        private Boolean coinSoundPlaying = false;
        private float rotationSpeed = 5f;
        private AudioSource audioSource;

        // Detect if the player collide with an obstacle in the scene
        static public Boolean gameOver = false;

        public void Initialize(InputAction flyAction)
        {
            // Initialize the moveAction variable
            flyAction.performed += FlyAction_performed;
            flyAction.Enable();
        }


        private void Start()
        {

            // Get the animator component of the character
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position,
                1000f * Time.deltaTime);

            // Rotate the bird to look up and down based on its velocity
            if (rb.velocity.y > 0)
            {
                //Look at the lookUpPoint 
                Quaternion targetRotation = Quaternion.LookRotation(lookUpPoint.transform.position 
                    - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 
                    Time.deltaTime * rotationSpeed);
            }
            else if(rb.velocity.y < 0)
            {
                //Look at the lookDownPoint 
                Quaternion targetRotation = Quaternion.LookRotation(lookDownPoint.transform.position
                    - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    Time.deltaTime * rotationSpeed);
            }

            // Collision detection for obstacles
            Collider[] hits = Physics.OverlapSphere(transform.position + new Vector3(0f, 0.35f, 0f), 0.33f);
            foreach (Collider hit in hits)
            {
                if (hit.gameObject.CompareTag("Obstacles"))
                {
                   
                    // Set the game over state and the animation trigger for death
                    anim.SetTrigger("HitPipe");
                    
                    gameOver = true;
                }else if (hit.gameObject.CompareTag("Coins"))
                {
                    // Make the coin disappear when picked up
                    Destroy(hit.gameObject);
                    //Increment the score
                    PipeGenerator.score++;
                    //Play the sound of coin picked up
                    if (!coinSoundPlaying)
                    {
                        audioSource.clip = coinSound;
                        audioSource.Play();
                    }
                }
            }

            if (gameOver)
            {
                soundManager.PlayDeathSound();
            }
 
        }
        private void FlyAction_performed(InputAction.CallbackContext obj)
        {
            if (!gameOver)
            {
                // Set the trigger to transit the state
                anim.SetTrigger("SpacePressed");


                if (!jumpCoolDown)
                {

                    //Increase altitude
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                    // Use coroutine to avoid constantly adding to much force to the sparrow
                    jumpCoolDown = true;
                    StartCoroutine(JumpCoolDownRefresh());

                    //Play the fly sound effect
                    audioSource.clip = flySound;
                    audioSource.Play();
                }
            }

            
        }

        private IEnumerator JumpCoolDownRefresh()
        {
            yield return new WaitForSeconds(0.3f);
            jumpCoolDown = false;
        }
    }
}
