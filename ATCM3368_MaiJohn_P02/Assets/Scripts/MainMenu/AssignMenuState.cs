using UnityEngine;

public class AssignMenuState : MonoBehaviour
{
    // Choose menu state to assign to game object
    [SerializeField] MenuState menuState;

    // Allow read privileges of assigned menu state
    public MenuState GetMenuState => menuState;
}
