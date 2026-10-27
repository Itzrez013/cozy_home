using UnityEngine;

public class sound : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.PlayDelayed(5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
