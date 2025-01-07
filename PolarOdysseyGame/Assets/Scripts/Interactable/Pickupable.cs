using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickupable : MonoBehaviour, IInteractable
{
    private State state;

    public void Interact(Interactor interactor)
    {
        state.Interact(interactor);
    }

    void Start()
    {
        state = new State(this);
    }

    void Update()
    {
        state.Update();
    }

    class State {
        protected Pickupable pickupable;
        public State(Pickupable pickupable) {
            this.pickupable = pickupable;
        }

        virtual public void Update(){}

        virtual public void Interact(Interactor interactor){
            Debug.Log("Picking up " + pickupable.gameObject.name);

            pickupable.gameObject.transform.SetParent(interactor.transform);
            pickupable.gameObject.transform.localPosition = new Vector3(0, 0, 3);
            pickupable.GetComponent<Rigidbody>().isKinematic = true;
            pickupable.state = new PickedUpState(pickupable, interactor);
            interactor.SetInteracting(true);
        }
    }

    class PickedUpState : State {
        Interactor interactor;

        public PickedUpState(Pickupable pickupable, Interactor interactor) : base(pickupable) {
            this.interactor = interactor;
        }

        override public void Update() {
            pickupable.gameObject.transform.localPosition = new Vector3(-0.1f, 0.2f, 0);
        }

        public override void Interact(Interactor interactor)
        {
            Debug.Log("Dropping " + pickupable.gameObject.name);

            this.interactor.SetInteracting(false);

            pickupable.GetComponent<Rigidbody>().isKinematic = false;
            pickupable.GetComponent<Rigidbody>().velocity = pickupable.GetComponentInParent<Rigidbody>().velocity;
            pickupable.gameObject.transform.SetParent(null);
            pickupable.state = new State(pickupable);
        }
    }
}
