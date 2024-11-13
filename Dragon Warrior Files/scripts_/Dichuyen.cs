
using UnityEngine;

public class Dichuyen : MonoBehaviour
{
    public float speed = 10.0f; // Tốc độ di chuyển của đối tượng

    public float verticalSpeed = 5.0f; // Tốc độ bay lên/xuống

    public bool isFacingRight = true; // Kiểm tra quay đầu

    public Vector2 velocity = Vector2.zero;  // Vận tốc hiện tại của nhân vật

    public bool canJump = true;

    // nhảy 
    private Rigidbody2D rB; // để tao áp lực nhảy
    public float jumpForce = 5.0f; // Lực nhảy của nhân vật
    public Animator animator; // Animator để điều khiển animation
    private bool isGrounded = true; // kiểm tra nhân vật đang ở trên mặt đất

    //bay
    public float flyForce = 5f;    // Lực bay (thấp hơn so với nhảy)



    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleMovement();

        HandeldWalk();

        HandeldCrouch();

        HandeldJump();

        HandledFlyKick();

        HandleAttack();

        HandledHurt();

        HandledStrike();

        HandledWin();

        //HandledDie();

        HandledDizzy();


    }
    private void HandleMovement()
    {



        // Lấy đầu vào từ phím A/D hoặc Mũi tên Trái/Phải để di chuyển ngang
        float horizontal = Input.GetAxisRaw("Horizontal");
        // Lấy đầu vào từ phím W/S hoặc Mũi tên Lên/Xuống để di chuyển dọc
        float forward = Input.GetAxisRaw("Vertical");

        // Tạo vector di chuyển cơ bản
        Vector3 move = transform.forward * forward * speed * Time.deltaTime;
        move += transform.right * horizontal * speed * Time.deltaTime;






        //quay đầu
        if (horizontal < 0 && isFacingRight) // Di chuyển sang trái
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = false;

        }
        else if (horizontal > 0 && !isFacingRight) // Di chuyển sang phải
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }
        transform.position += move;
    }

    //Walk
    public void HandeldWalk()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalk", true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalk", true);

        }
        else
        {
            animator.SetBool("isWalk", false);
        }

    }

    //Courch cúi
    public void HandeldCrouch()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow)) // Chỉ bật khi nhấn phím
        {
            animator.SetBool("isCrouch", true);
            if (Input.GetKeyDown(KeyCode.P))
            {
                animator.SetBool("isCrouchATK", true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) // Tắt khi nhả phím
        {
            animator.SetBool("isCrouch", false);

            if (Input.GetKeyDown(KeyCode.P))
            {
                animator.SetBool("isCrouchATK", true);
            }

        }
    }

    // Jump nhảy
    public void HandeldJump()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
            animator.SetTrigger("isJump");
        }

    }

    //Tấn công Attack

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("isAttack");
        }
    }

    // FlayKick bay
    private void HandledFlyKick()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("isFlyKick");
        }

    }

    //Hurt choáng
    private void HandledHurt()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("isHurt");
        }

    }

    //Strike 
    private void HandledStrike()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("isStrike");
        }
    }

    //win
    private void HandledWin()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("isWin");
        }
    }

    //Die
    private void HandledDie()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("isDie");
        }
    }

    //Dizzy

    private void HandledDizzy()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetBool("isDizzy",true);
        }
        else if(Input.GetKeyUp(KeyCode.V))
        {
           animator.SetBool("isDizzy",false); // Xóa trigger khi phím V không được nhấn
        }


    }

    // // Kiểm tra chạm đất
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //         isGrounded = true;
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //         isGrounded = false;
    // }



}
