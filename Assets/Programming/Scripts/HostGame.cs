using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 5;

    private string roomName;

    private NetworkManager networkManager;  

    public void SetRoomName (string _name)
    {
        roomName = _name;
    }

    void Start ()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void CreateRoom ()
    {
        if(roomName != "" && roomName != null)
        {
            Debug.Log("Ceating room: " + roomName + "with room for " + roomSize + " players");
            // Create room
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }

    }
}
