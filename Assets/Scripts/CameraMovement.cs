using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoSingleton<CameraMovement>
{
    [Range(0, 1)] [SerializeField] private float trauma;
    [SerializeField] private float traumaMultiplier;
    [SerializeField] private float maxOffset = 1f;
    [SerializeField] private float maxAngleOffset = 10f;
    [SerializeField] private float traumeDecrease;

    private float timeCounter;
    private float _relativeSpeed;

    private float PerlinRNG(float seed)
    {
        return (Mathf.PerlinNoise(seed, timeCounter) - 0.5f) * 2f;
    }

    public void CameraShake()
    {
        if (trauma > 0)
        {
            timeCounter += Time.deltaTime * trauma;
            Vector3 newPos = new Vector3((PerlinRNG(10) * traumaMultiplier * trauma * maxOffset * _relativeSpeed * 0.01f) + transform.position.x, (PerlinRNG(22) * traumaMultiplier * trauma * maxOffset * _relativeSpeed * 0.01f) + transform.position.y, -10);
            transform.position = newPos;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, PerlinRNG(trauma) * traumaMultiplier * maxAngleOffset * trauma * trauma * trauma * Mathf.Sqrt(_relativeSpeed));
        }
    }

    public void SetTrauma(float relativeSpeed)
    {
        trauma += Mathf.Clamp01(relativeSpeed / 60);
        _relativeSpeed = relativeSpeed;
    }

    public void DecreaseTrauma()
    {
        trauma -= (Time.deltaTime * traumeDecrease);
        if (trauma < 0)
        {
            trauma = 0;
        }
    }

    private void FixedUpdate()
    {
        //CameraShake();
        SetCameraPosition();
        
    }

    void Update()
    {
        DecreaseTrauma();
        CameraShake();
    }

    private void SetCameraPosition()
    {
            Vector3 newPosition = new Vector3();
            newPosition.x = (Player.Instance.transform.position.x * 0.05f + 0.95f * transform.position.x);
            newPosition.y = (Player.Instance.transform.position.y * 0.05f + 0.95f * transform.position.y);
            newPosition.z = -10;
        if (trauma == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
            transform.position = newPosition;
            //transform.position = new Vector3(newPosition.x - 13, newPosition.y +15, -10f);
    }

}
