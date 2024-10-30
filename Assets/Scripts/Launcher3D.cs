using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher3D : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private float launchModifier;
    [SerializeField] private Transform launchPoint;

    [SerializeField] private GameObject point;
    private GameObject[] pointsList;
    [SerializeField] private int pointsCount;
    [SerializeField] private float spaceBetween;

    private Vector3 direction;

    private void Start()
    {
        pointsList = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i] = Instantiate(point, launchPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 launchePosition = transform.position;

        direction = (mousePosition - launchePosition).normalized;


        transform.right = direction;


        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i].transform.position = CurrentPosition(i * spaceBetween);
        }
    }

    private void Shoot()
    {
        GameObject proyectile = Instantiate(proyectilePrefab, launchPoint.position, Quaternion.identity);
        proyectile.GetComponent<Rigidbody2D>().velocity = transform.right * launchModifier;
    }

    private Vector3 CurrentPosition(float t)
    {
        return (Vector3)launchPoint.position + (direction.normalized * launchModifier * t) + (Vector3)(0.5f * Physics.gravity * (t * t));
    }
    public void ReadShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }
}
