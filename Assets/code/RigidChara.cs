using UnityEngine;
using System.Collections;

public class RigidChara : MonoBehaviour
{

    private Animator animator;
    private Vector3 velocity;
    [SerializeField]
    private float jumpPower = 5f;
    [SerializeField]
    private Transform charaRay;
    [SerializeField]
    private float charaRayRange = 0.2f;
    private bool isGround;
    private Vector3 input;
    [SerializeField]
    private float walkSpeed = 1.5f;
    private Rigidbody rigid;
    private bool isGroundCollider = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        velocity = Vector3.zero;
        isGround = false;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (!isGroundCollider)
        {
            if (Physics.Linecast(charaRay.position, (charaRay.position - transform.up * charaRayRange)))
            {
                isGround = true;
                rigid.useGravity = true;
            }
            else
            {
                isGround = false;
                rigid.useGravity = false;
            }
            Debug.DrawLine(charaRay.position, (charaRay.position - transform.up * charaRayRange), Color.red);
        }
        if (isGroundCollider || isGround)
        {
            if (isGroundCollider)
            {
                velocity = Vector3.zero;

                animator.SetBool("Jump", false);
                rigid.useGravity = true;

            }
            else
            {
                velocity = new Vector3(0f, velocity.y, 0f);
            }

            input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (input.magnitude > 0f)
            {
                animator.SetFloat("Speed", input.magnitude);

                transform.LookAt(transform.position + input);

                velocity += input.normalized * walkSpeed;
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            if (Input.GetButtonDown("Jump")
          && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
             && !animator.IsInTransition(0))
            {
                animator.SetBool("Jump", true);
                velocity.y += jumpPower;
                rigid.useGravity = false;
            }
        }
        if (!isGroundCollider && !isGround)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        rigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void OnCollisionEnter()
    {

        Debug.DrawLine(charaRay.position, charaRay.position + Vector3.down, Color.blue);

        if (Physics.Linecast(charaRay.position, charaRay.position + Vector3.down, LayerMask.GetMask("Field", "Block")))
        {
            isGroundCollider = true;
        }
        else
        {
            isGroundCollider = false;
        }
    }

    void OnCollisionExit()
    {
        isGroundCollider = false;
    }
}
