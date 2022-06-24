using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using Ajuna.NetApi;
using static Ajuna.NetApi.Mnemonic;
using Schnorrkel.Keys;
using UnityEngine.UI;


public class Conversion : MonoBehaviour
{
    [DllImport("libgame", EntryPoint = "create_player")]
    public static extern int CreatePlayer(string origin, string playerUsername, uint playerAvatarNumber);
    
    public void ConvertPhraseToHexString() 
    {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            Debug.LogError("Failed to find the scene1Object");
            this.enabled = false;
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        // var mnemonicPhrase = "post phrase urban journey clock ghost man bar bargain diet quiz rival";
        // Convert phrase to secret key.
        var secretKey = Mnemonic.GetSecretKeyFromMnemonic(sc1Obj.mnemonicPhrase, "", BIP39Wordlist.English);
        int playerId = CreatePlayer(Utils.Bytes2HexString(secretKey), "TJ_STASH", 1);
        Debug.Log("Secret Key: " + Utils.Bytes2HexString(secretKey));
        Debug.Log("Player ID: " + playerId);
    }
}
