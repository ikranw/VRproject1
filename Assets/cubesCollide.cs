using UnityEngine;

public class cubeCollide : MonoBehaviour
{
    public GameObject effectObject; 
     public Transform cube2; 
     public float triggerDistance = 1.8f; 
    private ParticleSystem particles;

    void Start()
    {
        if (effectObject != null)
            particles = effectObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, cube2.position);

        if (distance < triggerDistance)
        {
            TriggerEffect();
        }
        else
        {
            StopEffect();
        }
        Debug.Log("distance: " + Vector3.Distance(transform.position, cube2.position));
        TriggerEffect();
    }

    void TriggerEffect()
    {
        if (particles != null && !particles.isPlaying)
            particles.Play();
    }

    void StopEffect()
    {
        if (particles != null && particles.isPlaying)
            particles.Stop();
    }
}