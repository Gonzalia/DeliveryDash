using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Atravieso");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Salgo");
    }
}
