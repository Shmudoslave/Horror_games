using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;              // Нормальная скорость
    public float sprintSpeed = 1.0f;         // Скорость бега
    private Vector3 moveVector;
    public float jumpHeight = 3.0f;          // Высота прыжка
    private bool isGrounded;                  // Проверка на земле

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Обновляем проверку на земле
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Получаем входные данные
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        moveVector.y = 0;  // Временно обнуляем ось Y

        // Проверяем, нажата ли клавиша Shift
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // Проверка прыжка
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveVector.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }

        // Двигаем игрока
        rb.MovePosition(rb.position + moveVector * currentSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Применяем гравитацию к объекту
        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * rb.mass);
        }
    }
}
