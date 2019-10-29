using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float inputXmove = Input.GetAxis("Horizontal");
        float inputYmove = Input.GetAxis("Vertical");
        Vector3 move = transform.right * inputXmove + transform.forward * inputYmove;

        controller.Move(move * speed * Time.deltaTime);
    }
}
