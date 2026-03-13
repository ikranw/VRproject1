using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float floatHeight = 0.1f; 
    public float floatSpeed = 1f; 
    public float maxHeight = 0.1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        newY = Mathf.Clamp(newY, startPos.y, startPos.y + maxHeight);
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}