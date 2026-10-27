using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private float footstepInterval = 0.66f;
    [SerializeField] private AudioSource[] footstepSounds;

    private bool isSitting = false;
    private float footstepTimer = 0f;


    void Start()
    {
        IEnumerator playwinstone()

                {

                    yield return new WaitForSeconds(2f);

                    GameObject.Find("voice_preview_winstone2").GetComponent<AudioSource>().Play();

                }

            StartCoroutine(playwinstone());
    }
    void Update()
    {

        if (Keyboard.current.cKey.isPressed && !isSitting)

        {

            GameObject.Find("chair").GetComponent<AudioSource>().Play();

            animator.SetInteger("mode", 2);

            isSitting = true;

        }

        if (Keyboard.current.vKey.isPressed && isSitting)

        {

            IEnumerator FalseIsSitting()

                {

                    yield return new WaitForSeconds(0.8f);

                    isSitting = false;

                    GameObject.Find("chair-stand").GetComponent<AudioSource>().Play();

                }

            StartCoroutine(FalseIsSitting());

            animator.SetInteger("mode", 3);

        }

        if (!isSitting)
        {
            if (Keyboard.current.aKey.isPressed)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetInteger("mode", 1);
                PlayFootstepSound();
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetInteger("mode", 1);
                PlayFootstepSound();
            }
            else if (Keyboard.current.wKey.isPressed)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetInteger("mode", 1);
                PlayFootstepSound();
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetInteger("mode", 1);
                PlayFootstepSound();
            }
            else
            {
                animator.SetInteger("mode", 0);
                footstepTimer = 0f;
            }
        }
    }

    private void PlayFootstepSound()
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0f)
        {
            footstepSounds[Random.Range(0, footstepSounds.Length)].Play();

            footstepTimer = footstepInterval;
        }
    }

}

