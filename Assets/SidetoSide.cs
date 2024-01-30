using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidetoSide : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 PlatformPosition;
    private int speed = 3;

    void Start()
    {
        PlatformPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlatformPosition + new Vector3(x:5, y:0, z:0) * (Mathf.Sin((Time.time)));
    }
}
