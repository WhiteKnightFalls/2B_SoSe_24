using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private InputAction _move;
    private InputAction _look;
    private InputAction _interact;

    private float _cameraXRotation;

    private Vector3 _velocity;
    //-------------------------------------------------------
    
    public PlayerInput PlayerInput;
    public CharacterController Controller;
    public Transform Camera;
    public float Speed = 10f;

    public float Gravity = -9.8f; // m/s/s für Schwerkraft berechnen

    public Interactable CurrentInteractable;
    
    // Start is called before the first frame update
    void Start()
    {   //in Visuel Scripting gibt es ein drop down, mit action finden und variable speichern
        _move = PlayerInput.actions.FindAction("Move");
        _look = PlayerInput.actions.FindAction("Look");
        _interact = PlayerInput.actions.FindAction("Interact");

        _cameraXRotation = Camera.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        //move ist ein action, action wert wird gelesen,
        // wenn ich a drücke kommt -1 auf xachse
        // w = -1 xachse
        Vector3 moveInput = _move.ReadValue<Vector2>();
        
        //y konvertieren zu z damit Player sich auf z bewegt
        moveInput.z = moveInput.y;
        moveInput.y = 0;
    
        //forwärstrichtung
        Vector3 moveAmount = transform.forward * moveInput.z + transform.right * moveInput.x;
        moveAmount.y += Gravity * Time.deltaTime;
        
        _velocity.x = moveAmount.x;
        _velocity.y += Gravity * Time.deltaTime;
        _velocity.z = moveAmount.z;
        
        //OnCollisionEnter
        if(Controller.Move(_velocity * Speed * Time.deltaTime) == CollisionFlags.Below)
        {
            _velocity.y = 0;
        }
        

     
        
        //holen ein Vector2 aus dem _look 
        Vector2 lookInput = _look.ReadValue<Vector2>();
        Vector3 cameraRotation = Camera.rotation.eulerAngles;
        _cameraXRotation += lookInput.y;
        
        //Rotation einschränken
        _cameraXRotation = Mathf.Clamp(_cameraXRotation, 0, 60);
        
        cameraRotation.x = _cameraXRotation;

        Camera.eulerAngles = cameraRotation;
        //Camera.rotation = Quaternion.Euler(cameraRotation);
        
        //Drehen
        transform.Rotate(0, lookInput.x, 0);


        //radiant (rad)
        //Winkel zum rad konvertieren
        /*float angle = cameraRotation.x * Mathf.Deg2Rad;
        float z = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        Vector3 cameraPosition = Camera.position;
        cameraPosition.z = z;
        cameraPosition.y = y;
        Camera.position = cameraPosition;
        */
        /*
        //hold
        _interact.IsPressed();
        //pressed
        _interact.WasPerformedThisFrame();
        //released
        _interact.WasReleasedThisFrame();
        */

        if (_interact.WasPressedThisFrame() && CurrentInteractable != null)
        {
            CurrentInteractable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //option 1. tag
      /*  if(other.CompareTag("coin"))
        {
            
        }
        if(other.CompareTag("coin"))
        {
            
        }
       */
        //option 2. component
        Collectable collectable = other.GetComponent<Collectable>();
        //Ist collectable nicht null, kann ich den Collect aufrufen
        if (collectable != null)
        {
            collectable.Collect();
        }
         //interactable
         Interactable inter = other.GetComponent<Interactable>();
         if (inter != null)
         {
             CurrentInteractable = inter;
         }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable inter = other.GetComponent<Interactable>();
        if (inter != null)
        {
            CurrentInteractable = null;
        }
    }
}
