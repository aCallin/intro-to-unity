using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject key;
    public GameObject door;

    void OnTriggerEnter(Collider other)
    {
        key.SetActive(false);
        door.SetActive(false);
    }
}
