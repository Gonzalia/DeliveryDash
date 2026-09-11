using UnityEngine;

public class Package : MonoBehaviour
{
    bool hasPackage = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            GetComponent<ParticleSystem>().Play();
            hasPackage = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();

        }
        else if (collision.CompareTag("Boost"))
        {
            GetComponent<Driver>().IncreaseSpeed();
            Destroy(collision.gameObject);

        }
    }
}
