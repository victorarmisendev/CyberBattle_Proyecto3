using UnityEngine;
using UnityEngine.Networking;

public class Weapon_Manager : NetworkBehaviour {

    [SerializeField]
    private string weaponLayerName = "Weapon";

    [SerializeField]
    private Player_Weapon primaryPlayerWeapon;

    [SerializeField]
    private Transform weaponHolder;

    private Player_Weapon currentWeapon;
    private Weapon_Graphics currentGraphics;

   void Start()
    {
        EquipWeapon(primaryPlayerWeapon);
    }

    public Player_Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public Weapon_Graphics GetCurrentGraphics()
    {
        return currentGraphics;
    }

    void EquipWeapon(Player_Weapon _weapon)
    {
        currentWeapon = _weapon;

        ////GameObject _weaponInstance = (GameObject)Instantiate(_weapon.graphics, weaponHolder.position, weaponHolder.rotation);
        //_weaponInstance.transform.SetParent(weaponHolder);

        //currentGraphics = _weaponInstance.GetComponent<Weapon_Graphics>();

        //if (currentGraphics == null)
        //    Debug.Log("No weaponGraphics");

        //if (isLocalPlayer)
        //    Utils.SetLayerRecursively(_weaponInstance, LayerMask.NameToLayer(weaponLayerName));

    }
}
