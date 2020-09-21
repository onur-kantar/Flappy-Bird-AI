using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 5f;
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
    }
}
