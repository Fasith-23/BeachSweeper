using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed=0.1f;
    [SerializeField] float sensitivity=0.1f;
    public float jumpspeed;
    public bool isGrounded = false;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * speed *2* Time.deltaTime);
        }
        else
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }
            transform.localRotation = Quaternion.Euler(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X"), 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
        {
           
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpspeed, 0f), ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tile" || collision.transform.tag == "Bomb")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Tile" || collision.transform.tag == "Bomb")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Tile" || collision.transform.tag == "Bomb")
        {
            isGrounded = false;
        }
    }
    
}
