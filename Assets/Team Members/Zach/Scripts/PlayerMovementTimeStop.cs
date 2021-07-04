using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZachFrench
{
    public class PlayerMovementTimeStop : MonoBehaviour
    {

        //Event created using a bool
        public event Action<float> TimeStopEvent;
        public event Action<float> ContinueTimeEvent;

        //References
        public Rigidbody rigidbody;
        public PlayerMovement PlayerMovement;
        
        //Variables 
        public bool notMoving;
        public Vector3 lastPosition;

        // Start is called before the first frame update
        void Start()
        {
            notMoving = false;
        }


        // Update is called once per frame
        void Update()
        {
            if (rigidbody.velocity.magnitude > .2f)
            {
                notMoving = false;
                ContinueTime();
            }
            else
            {
                notMoving = true;
                TimeStopping();
            }
        }

        public void TimeStopping()
        {
            if (notMoving)
            {
                TimeStopEvent?.Invoke(PlayerMovement.velocity);
            }
        }

        public void ContinueTime()
        {
            if (notMoving == false)
            {
                ContinueTimeEvent?.Invoke(PlayerMovement.velocity);
            }
        }
    }
}