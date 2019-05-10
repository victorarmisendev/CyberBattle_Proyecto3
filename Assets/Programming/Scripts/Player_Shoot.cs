using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof (Weapon_Manager))]
public class Player_Shoot : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private Player_Weapon currentWeapon;
    private Weapon_Manager weaponManager;

    public Transform WeaponHolder;


    public AudioSource shootSound;
    public AudioSource source;
    public GameObject particle, particle2;
    //public ParticleSystem blood;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No camara shoot");
            this.enabled = false;
        }
        weaponManager = GetComponent<Weapon_Manager>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();

        if (PauseMenu.IsOn)
            return;

        if (currentWeapon.fireRate <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                source.Play();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f/currentWeapon.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }

    [Command]
    void CmdOnShoot()
    {
        //RpcMuzzleFlash();
        Instantiate(particle2, WeaponHolder.transform.position, particle.transform.rotation);
    }

    [ClientRpc]
    void RpcMuzzleFlash()
    {
        //weaponManager.GetCurrentGraphics().muzzleFlash.Play();
    }


    [Command]
    void CmdOnHit(Vector3 _pos, Vector3 _normal)
    {
        RpcHitEffect(_pos, _normal);
    }

    [ClientRpc]
    void RpcHitEffect(Vector3 _pos, Vector3 _normal)
    {
        //GameObject _hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hitEffect, _pos, Quaternion.LookRotation(_normal));
        Instantiate(particle2, _pos, particle.transform.rotation);
        //Destroy(_hitEffect, 2f);
    }

    [Client]
    void Shoot ()
    {
        Debug.Log("Shoooooooooooot");

        shootSound.Play();

        if (!isLocalPlayer)
        {
            return;
        }

        CmdOnShoot();        

        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name, currentWeapon.damage);
                GetComponent<Player>().points += 10;
            }
            
            CmdOnHit(_hit.point, _hit.normal);
            //Instantiate(blood, _hit.point, blood.transform.rotation);
        }
    }

    [Command]
    void CmdPlayerShot (string _playerID, int _damage)
    {
        Debug.Log(_playerID + "Been shoot");

        Player _player =  GameManager.GetPlayer(_playerID);
        
        _player.RpcTakeDamage(_damage);
    }
}