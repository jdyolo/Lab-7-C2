using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class AbilityController : MonoBehaviour
{
    [Header("Habilidades")]
    [SerializeField] private BaseAbility[] abilities;
    [SerializeField] private TMP_Text abilityNameText;

    private AbilityControls controls;
    private BaseAbility currentAbility;
    private int currentIndex = 0;

    private void Awake()
    {
        controls = new AbilityControls();

        if (abilities != null && abilities.Length > 0)
        {
            currentAbility = abilities[0];

            if (abilityNameText != null)
            {
                abilityNameText.text = "Habilidad: " + currentAbility.AbilityName;
            }
        }
    }

    private void OnEnable()
    {
        controls.Abilities.Enable();

        controls.Abilities.Ability1.performed += SelectAbility1;
        controls.Abilities.Ability2.performed += SelectAbility2;
        controls.Abilities.Ability3.performed += SelectAbility3;
        controls.Abilities.Ability4.performed += SelectAbility4;
        controls.Abilities.Ability5.performed += SelectAbility5;
        controls.Abilities.Cast.performed += CastAbility;
        controls.Abilities.Scroll.performed += ChangeAbilityWithScroll;
    }

    private void OnDisable()
    {
        controls.Abilities.Ability1.performed -= SelectAbility1;
        controls.Abilities.Ability2.performed -= SelectAbility2;
        controls.Abilities.Ability3.performed -= SelectAbility3;
        controls.Abilities.Ability4.performed -= SelectAbility4;
        controls.Abilities.Ability5.performed -= SelectAbility5;
        controls.Abilities.Cast.performed -= CastAbility;
        controls.Abilities.Scroll.performed -= ChangeAbilityWithScroll;

        controls.Abilities.Disable();
    }

    private void SelectAbility1(InputAction.CallbackContext context)
    {
        SelectAbility(0);
    }

    private void SelectAbility2(InputAction.CallbackContext context)
    {
        SelectAbility(1);
    }

    private void SelectAbility3(InputAction.CallbackContext context)
    {
        SelectAbility(2);
    }

    private void SelectAbility4(InputAction.CallbackContext context)
    {
        SelectAbility(3);
    }

    private void SelectAbility5(InputAction.CallbackContext context)
    {
        SelectAbility(4);
    }

    private void SelectAbility(int index)
    {
        if (abilities == null || index < 0 || index >= abilities.Length)
            return;

        currentIndex = index;
        currentAbility = abilities[currentIndex];

        Debug.Log("Habilidad seleccionada: " + currentAbility.AbilityName);

        if (abilityNameText != null)
        {
            abilityNameText.text = "Habilidad: " + currentAbility.AbilityName;
        }
    }

    private void ChangeAbilityWithScroll(InputAction.CallbackContext context)
    {
        if (abilities == null || abilities.Length == 0)
            return;

        float scroll = context.ReadValue<float>();

        if (scroll > 0)
            currentIndex++;
        else if (scroll < 0)
            currentIndex--;
        else
            return;

        if (currentIndex >= abilities.Length)
            currentIndex = 0;

        if (currentIndex < 0)
            currentIndex = abilities.Length - 1;

        SelectAbility(currentIndex);
    }

    private void CastAbility(InputAction.CallbackContext context)
    {
        if (currentAbility == null)
            return;

        currentAbility.Execute();
    }
}