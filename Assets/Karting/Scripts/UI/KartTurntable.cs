using UnityEngine;

public class KartTurntable : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.25f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSpeed);
    }
}