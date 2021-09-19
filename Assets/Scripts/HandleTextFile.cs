using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HandleTextFile:MonoBehaviour
{
    static string path;
    static private GameObject nomeUtente;
    private static string fileContent;
    public static string userNameString;

    private void Awake() {
        path = "VacciCOD_Data/Resources/setting.txt";
        if (!File.Exists(path)) {
            File.WriteAllText(path, "");
        }
        ReadString();
        UpdateValue();
        writeOnTextbox();
    }
    private static void UpdateValue()
    {
        string[] content = fileContent.Split(',');
        userNameString = content[0];
    }
   // [MenuItem("Tools/Write file")]
    static void WriteString(string whatToWrite)
    {

        //Write some text to the test.txt file
        var stream = new FileStream(path, FileMode.Truncate);
        StreamWriter writer = new StreamWriter(stream);

        writer.Write(whatToWrite);
        writer.Close();
    }

    //[MenuItem("Tools/Read file")]
    static void ReadString()
    {

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        fileContent = reader.ReadToEnd();
        try
        {
            nomeUtente = GameObject.Find("InUser");
        }
        catch {

        }
        reader.Close();
    }
    private static void writeOnTextbox() {
        string[] content = fileContent.Split(',');
        try
        {
            nomeUtente.GetComponent<InputField>().text = content[0];
        }
        catch { }
    }
    public static void writeSetting() {
        string nome = nomeUtente.GetComponent<InputField>().text;
        var stringToWrite = nome+",";
        WriteString(stringToWrite);
    }
    public static string getPlayerName() {
        path = "VacciCOD_Data / Resources / setting.txt";
        StreamReader reader = new StreamReader(path);
        fileContent = reader.ReadToEnd();
        reader.Close();
        string[] content = fileContent.Split(',');

        return content[0];
    }
}