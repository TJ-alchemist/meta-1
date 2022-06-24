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

public class ExternalMethods : MonoBehaviour
{
    private const uint avatar1 = 1;
    private const uint avatar2 = 2;

    [DllImport("libgame", EntryPoint = "create_player")]
    private static extern int CreatePlayer(
        string origin, 
        string playerUsername, 
        uint playerAvatarNumber
    );

    [DllImport("libgame", EntryPoint = "create_game")]
    private static extern int CreateGame(
        string origin, 
        uint playerId,
        string gameName,
        string gameDeveloper,
        string gameDescription,
        uint gameVertical 
    );

    [DllImport("libgame", EntryPoint = "go_online")]
    private static extern int GoOnline(
        string origin, 
        uint gameId
    );

    [DllImport("libgame", EntryPoint = "go_offline")]
    private static extern int GoOffline(
        string origin, 
        uint gameId
    );

    public void SelectAvatar1() {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        sc1Obj.savedPlayerId = CreatePlayer(sc1Obj.mnemonicPhrase ,sc1Obj.username, avatar1);
        SceneManager.LoadScene("PlayGame");
    }

    public void SelectAvatar2() {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        sc1Obj.savedPlayerId = CreatePlayer(sc1Obj.mnemonicPhrase ,sc1Obj.username, avatar2);
        SceneManager.LoadScene("PlayGame");
    }

    public void PlayGame() {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        sc1Obj.savedGameId = CreateGame(
            sc1Obj.mnemonicPhrase,
            (uint) sc1Obj.savedPlayerId,
            "Super Mario",
            "Nintendo",
            "Super Mario is a 2D and 3D platform game series created by Nintendo based on and starring the fictional plumber Mario.",
            2 // Game vertical number : Adventure
        );
        SceneManager.LoadScene("NewGame");
    }

    public void ChangeToOnline() {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        int output = GoOnline(sc1Obj.mnemonicPhrase, (uint) sc1Obj.savedGameId);
    }

    public void ChangeToOffline() {
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        int output = GoOffline(sc1Obj.mnemonicPhrase, (uint) sc1Obj.savedGameId);
    }
}
