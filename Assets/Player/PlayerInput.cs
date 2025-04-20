using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputSystem_Actions actions;

    private InputAction move;
    private InputAction look;

    private CharacterBase character;
    private Camera cam;

    private void Awake()
    {
        actions = new InputSystem_Actions();
    }
    void Start()
    {
        character = GetComponent<CharacterBase>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        move = actions.Player.Move;
        look = actions.Player.Look;

        move.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
    }

    void Update()
    {
        character.Move(move.ReadValue<Vector2>());
        Vector2 p = look.ReadValue<Vector2>();
        p = cam.ScreenToWorldPoint(p);
        character.Look(p);
    }
}
