using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;              // ���������� ��������
    public float sprintSpeed = 1.0f;         // �������� ����
    private Vector3 moveVector;
    public float jumpHeight = 3.0f;          // ������ ������
    private bool isGrounded;                  // �������� �� �����

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ��������� �������� �� �����
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // �������� ������� ������
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        moveVector.y = 0;  // �������� �������� ��� Y

        // ���������, ������ �� ������� Shift
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // �������� ������
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveVector.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }

        // ������� ������
        rb.MovePosition(rb.position + moveVector * currentSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // ��������� ���������� � �������
        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * rb.mass);
        }
    }
}
