using UnityEngine;

public class DiChuyenThu : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        HandleFlip();
        HandleAttack();
    }

    // Hàm di chuyển
    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        // Animation walking
        bool isWalking = move != 0;
        animator.SetBool("isWalking", isWalking);
    }

    // Hàm nhảy
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    // Hàm quay đầu
    private void HandleFlip()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private bool isFacingRight = true;
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Hàm tấn công
    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack");
        }
    }

    // Kiểm tra chạm đất
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
