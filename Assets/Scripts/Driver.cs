using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 2f;
    [SerializeField] float moveSpeed = .5f;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            return;
        }

        float move = 0f;
        float steer = 0f;
        if (keyboard.wKey.isPressed)
        {
            move += 1f;
        }
        if (keyboard.sKey.isPressed)
        {
            move -= 1f;
        }
        if (keyboard.aKey.isPressed)
        {
            steer += 1f;
        }
        if (keyboard.dKey.isPressed)
        {
            steer -= 1f;
        }

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);

    }
}
