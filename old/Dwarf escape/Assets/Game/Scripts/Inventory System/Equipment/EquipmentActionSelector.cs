using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EquipmentActionSelector : MonoBehaviour
{

    private InputActions inputAction;
    private List<ActivateEquipmentAction> actionList = new List<ActivateEquipmentAction>();

    int selectedIndex;



    void Start()
    {
        inputAction = new InputActions();

        inputAction.EquipmentSelection.Select.Enable();
        inputAction.EquipmentSelection.Select.performed += Select; 
    }

    public void Subscribe(ActivateEquipmentAction equipmentAction)
    {
        if (actionList == null)
        {
            actionList = new List<ActivateEquipmentAction>();   
        }

        actionList.Add(equipmentAction);
    }

    
    private void Select(InputAction.CallbackContext context)
    {
        selectedIndex = int.Parse(context.action.activeControl.name);
        //actionList[selectedIndex].
    }
}
