
using UnityEngine;

public class KnightExample   : MonoBehaviour
{
    public float speed = 10.0f; // Tốc độ di chuyển của đối tượng

    public bool isFacingRight = true; // Kiểm tra quay đầu

    public Vector2 velocity = Vector2.zero;  // Vận tốc hiện tại của nhân vật

    public bool canJump = true;

    // nhảy 
    private Rigidbody2D rB; // để tao áp lực nhảy
    public float jumpForce = 5.0f; // Lực nhảy của nhân vật
    public Animator animator; // Animator để điều khiển animation
    private bool isGrounded = true; // kiểm tra nhân vật đang ở trên mặt đất

    


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

        HandledBlock();

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
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalk", true);

        }
        else if (Input.GetKey(KeyCode.D))
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

        if (Input.GetKeyDown(KeyCode.S)) // Chỉ bật khi nhấn phím
        {
            animator.SetBool("isCrouch", true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("isCrouchATK", true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S)) // Tắt khi nhả phím
        {
            animator.SetBool("isCrouch", false);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("isCrouchATK", true);
            }

        }
    }

    // Jump nhảy
    public void HandeldJump()
    {


        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
            animator.SetTrigger("isJump");
        }

    }

    //Tấn công Attack

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("isAttack");
        }
    }

    // FlayKick bay
    private void HandledBlock()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isBlock");
        }

    }

    //Hurt choáng
    private void HandledHurt()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("isHurt");
        }

    }

    //Strike 
    private void HandledStrike()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("isStrike");
        }
    }

    //win
    private void HandledWin()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isWin");
        }
    }

    //Die
    private void HandledDie()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("isDie");
        }
    }

    //Dizzy

    private void HandledDizzy()
    {
        if (Input.GetKeyDown(KeyCode.H))
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
