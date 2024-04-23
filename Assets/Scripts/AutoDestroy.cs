using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       float timeToDestroy = 1f; // Seconds
       Destroy(gameObject, timeToDestroy );
    }
}
