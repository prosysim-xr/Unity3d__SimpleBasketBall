using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //data variable related to movement
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;
    [SerializeField] private Vector3 velocity;

    //related to ground check
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;

    //related to Jump
    public float jumpHeight =3f;
    
    void Update()
    {
        CheckIfGrounded();
        PlayerMove();
        GravityPlayerFall();
        PlayerJump();
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);// groundDistance is check sphere's radius
        if (isGrounded && velocity.y <0)
        {
            velocity.y = 0f;// value =-2 ac to brackeys
        }
    }
    private void PlayerMove()
    {
        float inputXmove = Input.GetAxis("Horizontal");
        float inputYmove = Input.GetAxis("Vertical");
        Vector3 directionMove = transform.right * inputXmove + transform.forward * inputYmove;

        controller.Move(directionMove * speed * Time.deltaTime);
    }
    private void GravityPlayerFall()
    {
        
        velocity.y += gravity * Time.deltaTime;//v=u+at//velocity is a vector its y component is newton low applied

        controller.Move((velocity*Time.deltaTime)/2);//change in displacement s = 1/2(at^2)//physics of freefall
    }
    private void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
        }
    }
}
