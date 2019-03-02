using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    private Vector3 offset;

    public void Start()
    {
        offset = transform.position - player.transform.position;
    }


    public void Update()
    {
        transform.position = player.transform.position + offset;
    }

}
