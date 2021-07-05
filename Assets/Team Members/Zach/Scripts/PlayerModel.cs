using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace ZachFrench
{
    public class PlayerModel : MonoBehaviour
    {
        //References 
        public CharacterController characterController;
        //Variables 
        public float velocity;
        private float x;
        private float z;
        public float speed;
        public Vector3 move;
        public void Update()
        {
            CharacterMovement();
            //Getting Velocity for NPC Movement
            velocity = characterController.velocity.magnitude;
        }

        public void CharacterMovement()
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);
        }
    }
}