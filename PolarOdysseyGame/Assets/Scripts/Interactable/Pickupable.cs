using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour, IInteractable
{
    private bool isPickedUp = false;
    private State state;

    public void Interact()
    {
    }

    public void Interact(Interactor interactor)
    {
        Debug.Log("Picking up " + this.gameObject.name);

        isPickedUp = true;
        this.gameObject.transform.SetParent(interactor.transform);
        this.gameObject.transform.localPosition = new Vector3(0, 0, 3);
        this.GetComponent<Rigidbody>().isKinematic = true;
        state = new PickedUpState(this, interactor);
        interactor.SetInteracting(true);
    }

    void Start()
    {
        state = new State();
    }

    void Update()
    {
        state.Update();
    }

    class State {
        virtual public void Update(){}
    }

    class PickedUpState : State {
        Pickupable pickupable;
        Interactor interactor;

        public PickedUpState(Pickupable pickupable, Interactor interactor) {
            this.pickupable = pickupable;
            this.interactor = interactor;
        }

        override public void Update() {
            pickupable.gameObject.transform.localPosition = new Vector3(0, -2, -4);

            if(Input.GetKeyDown(KeyCode.Q)) {
                Debug.Log("Dropping " + pickupable.gameObject.name);

                this.interactor.SetInteracting(false);

                pickupable.isPickedUp = false;
                pickupable.GetComponent<Rigidbody>().isKinematic = false;
                pickupable.GetComponent<Rigidbody>().velocity = pickupable.GetComponentInParent<Rigidbody>().velocity;
                pickupable.gameObject.transform.SetParent(null);
                pickupable.state = new State();
            }
        }
    }
}
