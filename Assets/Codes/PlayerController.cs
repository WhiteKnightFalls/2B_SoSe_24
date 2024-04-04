using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private InputAction _move;
    private InputAction _look;

    private float _cameraXRotation;
    
    public PlayerInput PlayerInput;
    public CharacterController Controller;
    public Transform Camera;
    public float Speed = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {   //in Visuel Scripting gibt es ein drop down, mit action finden und variable speichern
        _move = PlayerInput.actions.FindAction("Move");
        
        _look = PlayerInput.actions.FindAction("Look");

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
        Controller.Move(moveInput * Speed * Time.deltaTime);
        
        
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
    }
}
