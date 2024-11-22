using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimation : MonoBehaviour
{
    public Animator animator;
    public float minimumSpeedToWalk = 0.1f;
    public float maximumSpeedToStandStill = 0.9f;

    protected float xInput;
    protected float yInput;
    protected bool isWalking;

    private IState state;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        state = new IdleState(this);
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        state.CalculateWalkingState();

        animator.SetFloat("xMovement", xInput);
        animator.SetFloat("yMovement", yInput);
        animator.SetBool("isWalking", isWalking);
    }

    bool isAboveMinimum() {
        return Math.Abs(xInput) > minimumSpeedToWalk || Math.Abs(yInput) > minimumSpeedToWalk;
    }

    bool isUnderMaximum() {
        return Math.Abs(xInput) < maximumSpeedToStandStill && Math.Abs(yInput) < maximumSpeedToStandStill;
    }

    abstract class IState {
        protected InputToAnimation parent;
        public IState(InputToAnimation parent) {
            this.parent = parent;
        }
        public virtual void CalculateWalkingState(){}
    }

    class IdleState : IState {
        public IdleState(InputToAnimation parent) : base(parent){}

        override public void CalculateWalkingState() {
            parent.isWalking = parent.isAboveMinimum();

            if(!parent.isUnderMaximum()) parent.state = new WalkingState(parent);
        }
    }

    class WalkingState : IState {
        public WalkingState(InputToAnimation parent) : base(parent){}

        override public void CalculateWalkingState() {
            parent.isWalking = !parent.isUnderMaximum();

            if(!parent.isAboveMinimum()) parent.state = new IdleState(parent);
        }
    }
}
