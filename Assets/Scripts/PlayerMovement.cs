using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float horizontalSpeed = 4f;

    public bool isJumping = false;
    public bool goingDown = false;

    public float jumpHeight = 3f;
    public GameObject playerObject;

    void MovimentaEsquerda()
    {
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }

    void MovimentaDireita()
    {
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
    }

    void Update()
    {
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
                playerObject.GetComponent<Animator>().Play("jumpAnimation");
                StartCoroutine(JumpSequence());
            }
        }

        if(isJumping)
        {
            if(!goingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
            }

            if(goingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpHeight, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.5f);
        goingDown = true;
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
        goingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
