using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class BallController : MonoBehaviour
{
    #region Variables
    [Header("Basic Configuration")]
    [SerializeField] PaddleController m_MainPaddle = null;

    [Header("Control Values")]
    [SerializeField] Vector2 launchVelocity = new Vector2(2f, 10f);
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float randomFactor = 0.2f;

    // component refs
    AudioSource audioChannel;
    Rigidbody2D playerRigidbody;

    //state
    Vector2 paddleToBallVector;
    bool hasLaunched = false;
    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - m_MainPaddle.transform.position;
        audioChannel = GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            AttachBall();
            LaunchOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched)
        {
            PlayerImpact();
        }
    }
    #endregion

    #region Helper Methods
    private void AttachBall()
    {
        Vector2 paddlePos = new Vector2(m_MainPaddle.transform.position.x, m_MainPaddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerRigidbody.velocity = launchVelocity;

            hasLaunched = true;
        }
    }

    private void PlayerImpact()
    {
        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
        audioChannel.PlayOneShot(randomClip);

        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), 
                                            Random.Range(0, randomFactor));
        playerRigidbody.velocity += velocityTweak;
    }
    #endregion
}
