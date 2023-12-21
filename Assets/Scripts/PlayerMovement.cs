using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float horizontalSpeed = 4f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private GameObject painelGameOver;
    [SerializeField] private AudioSource gameOverSFX;
    public float moveSpeed = 4f;
    public bool isJumping = false;
    public bool goingDown = false;
    public static bool running = false;
    private int targetScore = 1;
    private int score;

    void Start()
    {
        Time.timeScale = 1;
        playerAnimator = playerObject.GetComponent<Animator>();
        painelGameOver.SetActive(false);
    }

    void Update()
    {
        if (running)
        {
            playerAnimator.SetBool("Running", running);
            score = ScoreController.instance.score;

            if (score > targetScore && moveSpeed < maxSpeed)
            {
                moveSpeed += 0.1f;
                horizontalSpeed += 0.05f;
                targetScore++;
            }

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > LevelBounds.leftBound)
                {
                    MovimentaEsquerda();
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < LevelBounds.rightBound)
                {
                    MovimentaDireita();
                }
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    playerAnimator.Play("jumpAnimation");
                    StartCoroutine(JumpSequence());
                }
            }

            if (isJumping)
            {
                if (!goingDown)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 3f, Space.World);
                }

                if (goingDown)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * -3f, Space.World);
                }
            }
        }
    }

        void MovimentaEsquerda()
    {
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }

    void MovimentaDireita()
    {
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.4f);
        goingDown = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
        goingDown = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            moveSpeed = 0;
            running = false;
            playerAnimator.SetBool("Running", running);
            StartCoroutine(ShowGameOver());

        }
    }

    IEnumerator ShowGameOver()
    {
        gameOverSFX.Play();
        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 0;
        painelGameOver.SetActive(true);
    }
}
