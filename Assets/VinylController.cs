using UnityEngine;
using System.Collections;

public class VinylController : MonoBehaviour
{
    public float coeff = 4.0f;
    public float rpm = 33.333f;

    AudioSource audioSource;

    float angle;
    float speed;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        angle = 0;
        speed = 0;
    }

    void Update()
    {
        var p = Input.mousePosition - new Vector3(Screen.width, Screen.height, 0) * 0.5f;
        transform.localRotation = Quaternion.FromToRotation(new Vector3(1, 0), p.normalized);

        var newAngle = -transform.localRotation.eulerAngles.z;
        var newSpeed = Mathf.DeltaAngle(angle, newAngle) / Time.deltaTime * 60;

        speed = Mathf.Lerp(newSpeed, speed, Mathf.Exp(-coeff * Time.deltaTime));

        audioSource.pitch = speed / (rpm * 360);

        angle = newAngle;
    }
}
