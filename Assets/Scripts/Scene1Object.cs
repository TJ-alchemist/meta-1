using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using Ajuna.NetApi;
using static Ajuna.NetApi.Mnemonic;
using Schnorrkel.Keys;

public class Scene1Object : MonoBehaviour
{

    public string AccountId = "Not Set";
    public string mnemonicPhrase = "";
    public string username = "";
    public int savedPlayerId = 0;
    public int savedGameId = 0;
    static Scene1Object ThisIsTheOneAndOnlyScene1Object;

    // [DllImport("libgame", EntryPoint = "create_player")]
    // public static extern int CreatePlayer(string origin, string playerUsername, uint playerAvatarNumber);

    // Start is called before the first frame update
    void Start()
    {       
        if(ThisIsTheOneAndOnlyScene1Object != null) 
        {
            Destroy(this.gameObject);
            return;
        }
        ThisIsTheOneAndOnlyScene1Object = this;
        GameObject.DontDestroyOnLoad( this.gameObject );
    }

    // Update is called once per frame
    void Update()
    {
        // GetEncodedHexString();
    }

    void OnDestroy() {
        Debug.Log("Scene1Object was destroyed!");
    }

    // public void GetEncodedHexString() {
    //     if (!string.IsNullOrEmpty(mnemonicPhrase)) {
    //         Debug.Log("The encoded mnemonic phrase is: " + mnemonicPhrase);
    //     } else {
    //         Debug.Log("Mnemonic phrase is not set!");
    //     }
    // }

    // void GeneratePlayer() 
    // {
    //     var mnemonicPhrase = "post phrase urban journey clock ghost man bar bargain diet quiz rival";
    //     // Convert phrase to secret key.
    //     var secretKey = Mnemonic.GetSecretKeyFromMnemonic(mnemonicPhrase, "", BIP39Wordlist.English);
    //     int playerId = Scene1Object.CreatePlayer(Utils.Bytes2HexString(secretKey), "TJ_STASH", 1);
    //     Debug.Log("Secret Key: " + Utils.Bytes2HexString(secretKey));
    //     Debug.Log("Player ID: " + playerId);
    // }

}
