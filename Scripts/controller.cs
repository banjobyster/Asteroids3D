using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject headPos, left, up, Earth, laser, asteroid;
    public Rigidbody rb;
    public Camera cam;
    Vector3 moveDir, gravDir, laserDir;
    public float gravSpeed, camsensitivity, speed, randomizerrange = 1000, mul = 0.001f, startSkip = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (startSkip>10)
        {
            rb.AddForce(gravDir * (1 / (gravDir.magnitude * gravSpeed)), ForceMode.Acceleration);
            startSkip = 12f;
        }
        startSkip += 1f;
    }
    void Update()
    {
        gravDir = (Earth.transform.position - transform.position);
        moveDir = (headPos.transform.position - cam.transform.position);
        laserDir = (headPos.transform.position - cam.transform.position);
        formAsteroid();
        move();
        lookAt();
        fire();
    }

    void formAsteroid()
    {
        float x = Random.Range(-800f, 800f);
        float y = Random.Range(-800f, 800f);
        float z = Random.Range(-800f, 800f);
        float randomizer = Random.Range(0f, randomizerrange);
        if (((x > 400 || x < -400) || (y > 400 || y < -400) || (z > 400 || z < -400)) && randomizer <= 0.05f)
        {
            GameObject ast = (GameObject)Instantiate(asteroid, new Vector3(x, y, z), Quaternion.Euler(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f)));
            ast.transform.localScale *= Random.Range(1f, 2.5f);
            //laserC.transform.position = headPos.transform.position;
            //laserC.transform.rotation = headPos.transform.rotation;
            ast.GetComponent<Rigidbody>().AddForce((Earth.transform.position - ast.transform.position) * speed * 0.04f, ForceMode.VelocityChange);
            Destroy(ast, 200f);
        }
    }
    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject laserC = (GameObject)Instantiate(laser, headPos.transform.position, headPos.transform.rotation);
            //laserC.transform.position = headPos.transform.position;
            //laserC.transform.rotation = headPos.transform.rotation;
            laserC.GetComponent<Rigidbody>().AddForce(laserDir * speed * 800, ForceMode.Impulse);
            Destroy(laserC, 4f);
        }
    }
    void move()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            rb.AddForce(moveDir * speed);
        }
    }

    void lookAt()
    {
        float x = Input.GetAxis("Mouse X") * camsensitivity;
        float y = Input.GetAxis("Mouse Y") * camsensitivity;
        Vector3 leftdir = transform.position - left.transform.position;
        Vector3 updir = transform.position - up.transform.position;
        transform.RotateAround(transform.position, leftdir, y);
        transform.RotateAround(transform.position, updir, x);
    }
}
