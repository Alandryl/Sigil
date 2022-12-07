using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Spell spellToCast;

    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    [SerializeField] private Transform castPoint;

    private PlayerControls playerControls;

    private bool castingMagic = false;

    [SerializeField] private bool isGamepad;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        bool isSpellCastHeldDown;
        if (!isGamepad)
        {
            isSpellCastHeldDown = playerControls.Controls.Fire.ReadValue<float>() > 0.1;
        }
        else
        {
            Vector2 aim = playerControls.Controls.FireGamepad.ReadValue<Vector2>();

            isSpellCastHeldDown = Mathf.Abs(aim.x) > 0.1f || Mathf.Abs(aim.y) > 0.1f;

        }


        if (!castingMagic && isSpellCastHeldDown)
        {
            castingMagic = true;
            currentCastTimer = 0;
            CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime * playerStats.castSpeedMultiplier;

            if (currentCastTimer > spellToCast.spellToCast.cooldown)
            {
                castingMagic = false;
            }
        }

    }

    void CastSpell()
    {
        GameObject spell = Instantiate(spellToCast, castPoint.position, castPoint.rotation).gameObject;
        spell.GetComponent<Spell>().playerStats = playerStats;

        //Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad");
    }
}
