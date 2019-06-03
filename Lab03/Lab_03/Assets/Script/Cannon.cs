using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBall;
    Rigidbody CannonBallRB;

    public Slider slider;

    public Transform ShootPoint;

    public float firepower;
    public float force;

    private bool firebool = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            force = force + 15;

            if (force > 5000)
            {
                force = 5000;
            }

            
        }

        if (Input.GetMouseButtonUp(0))
        {
            CannonBall.GetComponent<ConstantForce>().force = transform.forward * force;
            GameObject CannonBallCopy = Instantiate(CannonBall, ShootPoint.position, ShootPoint.rotation) as GameObject;
            force = 0;
            Destroy(CannonBallCopy, 5f);


        }

        float progressForce = Mathf.Clamp01(force / 5000);
        slider.value = progressForce;

    }




}
