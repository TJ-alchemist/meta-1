using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using Ajuna.NetApi;
using static Ajuna.NetApi.Mnemonic;
using Schnorrkel.Keys;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public Text objText;
    public InputField display;
    public Text textUsernameMessage;
    public InputField inputUsername;

    public async void SetSecretPhrase() 
    {
        try 
        {
            var enteredMnemonicPhrase = display.text.ToString();
            if (string.IsNullOrEmpty(enteredMnemonicPhrase)) {
                objText.text = "----- Please enter your mnemonic phrase! -----";
                return;
            }
            string result = ConvertPhraseToHexString(display.text.ToString());
            objText.text = result;
            GameObject go = GameObject.Find("Scene1Object");
            if (go == null) {
                this.enabled = false;
                Debug.LogError("Failed to find the Scene1Object");
                return;
            }
            Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
            sc1Obj.mnemonicPhrase = result;
            objText.text = "Please wait...";
            await Task.Delay(4000);
            SceneManager.LoadScene("EnterUsername");
        }
        catch (FormatException)
        {
            objText.text = "----- Invalid mnemonic phrase! -----";
        }
    }

    public async void ValidateUsername() {
        string username = inputUsername.text.ToString();
        if (string.IsNullOrEmpty(username)) {
            textUsernameMessage.text = "Please enter username!";
            return;
        }
        GameObject go = GameObject.Find("Scene1Object");
        if (go == null) {
            this.enabled = false;
            Debug.LogError("Failed to find the Scene1Object");
            return;
        }
        Scene1Object sc1Obj = go.GetComponent<Scene1Object>();
        sc1Obj.username = username;
        textUsernameMessage.text = "Please wait..";
        await Task.Delay(4000);
        SceneManager.LoadScene("SelectAvatar");
    }

    private string ConvertPhraseToHexString(string phrase) 
    {
        var secretKey = Mnemonic.GetSecretKeyFromMnemonic(phrase, "", BIP39Wordlist.English);
        string hexString = Utils.Bytes2HexString(secretKey);

        return hexString;
    }
}
