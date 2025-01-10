using UnityEngine;

public class StaticPlatform : MonoBehaviour
{
    void Start()
    {
        // Optional: Ensure the platform is static by removing Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
    }
}
