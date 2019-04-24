using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {

    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [SerializeField]
    private int maxHP = 100;

    //When hp changes all clients know it
    [SyncVar]
    private int currentHP;

    [SerializeField]
    private Behaviour[] disableDead;
    public bool[] wasEnabled;

    private bool firstSetup = true;

    public float points;

    public void PlayerSetup()
    {

        CmdBroadCastNewPlayerSetup();
    }

    [Command]
    private void CmdBroadCastNewPlayerSetup()
    {
        RpcSetupPlayerAllClients();
    }

    [ClientRpc]
    private void RpcSetupPlayerAllClients()
    {
        if (firstSetup)
        {

            //gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();

            wasEnabled = new bool[disableDead.Length];
            for (int i = 0; i < wasEnabled.Length; i++)
            {
                wasEnabled[i] = disableDead[i].enabled;
            }
            firstSetup = false;
        }
        SetDefaults();
    }

    //All clients know everything
    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead)
            return;

        currentHP -= _amount;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Dissable components if is dead
        isDead = true;

        for (int i = 0; i < disableDead.Length; i++)
        {
            disableDead[i].enabled = false;
        }

        Collider _col = GetComponent<Collider>();
        if (_col != null)
            _col.enabled = true;

        StartCoroutine(Respawn());
    }

    //If dead respanw in one of the respawns set on the networkmanager
    private IEnumerator Respawn()
    {
        //Seconds to respawn
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawn);

        Vector3 _spawnPoint = new Vector3(0, 4, 0);
        transform.position = _spawnPoint;
        //transform.rotation = 

        yield return new WaitForSeconds(0.1f);
        PlayerSetup();
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHP = maxHP;

        for (int i = 0; i < disableDead.Length; i++)
        {
            disableDead[i].enabled = wasEnabled[i];
        }

        Collider _col = GetComponent<Collider>();
        if (_col != null)
            _col.enabled = true;
    }
}
