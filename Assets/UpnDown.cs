using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpnDown : MonoBehaviour
{
    private GameObject Platform;
    private Vector3 PlatformPosition;
    private Vector3 position;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        PlatformPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlatformPosition + new Vector3(x: 0, y: 2.5f, z: 0) * (Mathf.Sin(Time.time));
    }
}
