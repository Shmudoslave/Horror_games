using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseXSensitivity = 100f;
        public float mouseYSensitivity = 100f; // добавим чувствительность по Y

        public Transform playerBody;

        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseYSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Применяем поворот по X (искосок вверх/вниз)
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Поворачиваем тело игрока по Y (искорость влево/вправо)
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}

