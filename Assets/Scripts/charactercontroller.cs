using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{

    float speed = 5.0f; // units per frame
    int boxSelect = 1;

    GameObject Green;
    GameObject Blue;
    GameObject Red;
    GameObject Yellow;


    // Start is called before the first frame update
    void Start()
    {
        Green = GameObject.Find("Green");
        Blue = GameObject.Find("Blue");
        Red = GameObject.Find("Red");
        Yellow = GameObject.Find("Yellow");

        Green.SetActive(true);
        Blue.SetActive(false);
        Red.SetActive(false);
        Yellow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Green.SetActive(true);
            Blue.SetActive(false);
            Red.SetActive(false);
            Yellow.SetActive(false);

            boxSelect = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Green.SetActive(false);
            Blue.SetActive(true);
            Red.SetActive(false);
            Yellow.SetActive(false);

            boxSelect = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Green.SetActive(false);
            Blue.SetActive(false);
            Red.SetActive(true);
            Yellow.SetActive(false);

            boxSelect = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Green.SetActive(false);
            Blue.SetActive(false);
            Red.SetActive(false);
            Yellow.SetActive(true);

            boxSelect = 4;
        }

        // Multiplying a move distance with Time.deltaTime essentially expresses:
        // I want to move this object 10 meters per second instead of 10 meters per
        // frame. It creates frame rate independent movement speed:

        switch (boxSelect)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    // this is how to move an object manually

                    // Vector3 newPosition;
                    // newPosition = gameObject.transform.position; // current position
                    // newPosition.z += speed * Time.deltaTime;
                    // transform.position = newPosition;

                    Green.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    // this is how to move an object using Translate (like a method)

                    Green.transform.Translate(Vector3.left * speed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    Green.transform.Translate(Vector3.back * speed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    Green.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Blue.transform.Translate(Vector3.forward * 100 * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    Blue.transform.Translate(Vector3.left * 100 * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    Blue.transform.Translate(Vector3.back * 100 * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    Blue.transform.Translate(Vector3.right * 100 * Time.deltaTime);
                }
                break;

            case 3:
                float vert = Input.GetAxis("Vertical") * speed;
                float horiz = Input.GetAxis("Horizontal") * speed;

                vert *= Time.deltaTime;
                horiz *= Time.deltaTime;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    Red.transform.Translate(0, 0, vert);
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    Red.transform.Translate(horiz, 0, 0);
                }
                break;

            case 4:
                float rawvert = Input.GetAxisRaw("Vertical") * Time.deltaTime;
                float rawhoriz = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    Yellow.transform.Translate(0, 0, rawvert);
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    Yellow.transform.Translate(rawhoriz, 0, 0);
                }
                break;
        }
    }
}
