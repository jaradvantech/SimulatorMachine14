using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using Newtonsoft.Json.Linq;

public class PLCLinkCanvas : MonoBehaviour {

    // Use this for initialization

    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    public InputField inputField4;

    void Start () {

        StreamReader streamReader = new StreamReader(Application.dataPath + "/Config.txt");

        JObject obj = JObject.Parse(streamReader.ReadToEnd().ToString());
        string PLCIP = (string)obj["PLCIP"];
        string[] IPPieces = PLCIP.Split('.');

        inputField1.text = IPPieces[0];
        inputField2.text = IPPieces[1];
        inputField3.text = IPPieces[2];
        inputField4.text = IPPieces[3];

        streamReader.Close();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        string PLCIPString = inputField1.text + "." + inputField2.text + "." + inputField3.text + "." + inputField4.text;
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            //writer.Formatting = Formatting.Indented;

            writer.WriteStartObject();
            writer.WritePropertyName("PLCIP");
            writer.WriteValue(PLCIPString);
            writer.WriteEndObject();

            StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/Config.txt", true);
            streamWriter.WriteLine(sb.ToString());
            streamWriter.Close();

            //File.WriteAllText(AssetDatabase.GetAssetPath(ConfigFile), sb.ToString());
            //EditorUtility.SetDirty(ConfigFile);

        }

        Application.Quit();
    }
}
