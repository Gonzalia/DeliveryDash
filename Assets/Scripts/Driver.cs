using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 2f;
    [SerializeField] float moveSpeed = .5f;
    [SerializeField] GameObject boostText;
    float boostEndTime;

    void Awake()
    {
        if (boostText != null)
        {
            boostText.SetActive(false);
        }
    }

    public void IncreaseSpeed()
    {
        boostEndTime = Time.time + 2f;
        if (boostText != null)
        {
            boostText.SetActive(true);
        }
    }

    void Update()
    {
        if (boostText != null && boostText.activeSelf && Time.time >= boostEndTime)
        {
            boostText.SetActive(false);
        }

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

        float currentMoveSpeed = Time.time < boostEndTime ? moveSpeed + 5f : moveSpeed;
        float moveAmount = move * currentMoveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);

    }
}
