using EventChannelSystem;
using EventChannelSystem.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpforce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [Header("Events")]
    [SerializeField] private IntEventChannel onScoreUpdate;

    public int score;

    private bool _isMoving;
    private bool _isGrounded;
    private bool _isJumping;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horixontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _isGrounded = IsGrounded();
        _isMoving = (Mathf.Abs(horixontalInput) > 0f || Mathf.Abs(verticalInput) > 0f) && _isGrounded;

        rb.velocity = new Vector3(horixontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetKeyDown("space") && _isGrounded)
        {
            _isJumping = true;
            Jump();
            animator.SetBool("IsJumping", _isJumping);
        }
        else
        {

            _isJumping = false;
            animator.SetBool("IsJumping", _isJumping);
        }

        if (transform.position.y < -15f)
        {
            SceneManager.LoadScene("Gameover");

        }

        //Animation        
        animator.SetBool("IsMoving", _isMoving);
        animator.SetBool("IsGrounded", _isGrounded);
    }
    public void OnUpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        onScoreUpdate.RaiseEvent(score);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, .1f);
    }
}
