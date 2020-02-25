//   Project : Battlecruiser3.0
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/23/2018

using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using static System.Char;


public class ProcessingEditorSamples : EndNameEditAction
{
    public const string PATH_TO_TEMPLATE = @"Assets\[0]Framework\LibBlueprints\SampleTemplate.txt";
    private const int MENU_ITEM_PRIORITY = 60;
    private static Texture2D scriptIcon = (EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);

    [MenuItem("Tools/Actors/Add/Sample", false, MENU_ITEM_PRIORITY)]
    public static void CreateSample()
    {
        CreateFromTemplate("SampleDefault.cs", PATH_TO_TEMPLATE);
    }


    public static void CreateFromTemplate(string name, string pathName)
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            CreateInstance<ProcessingEditorSamples>(),
            name,
            scriptIcon,
            pathName);
    }

    public static object CreateScript(string pathName, string templatePath)
    {
        var filePath = Path.GetFullPath(pathName);
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        var className = fileNameWithoutExtension.Replace(" ", string.Empty);
        var templateContents = string.Empty;

        if (!File.Exists(templatePath)) return (MonoScript) AssetDatabase.LoadAssetAtPath(pathName, typeof(MonoScript));
        using (var t = new StreamReader(templatePath))
        {
            t.ReadLine();
            templateContents = t.ReadToEnd();
        }

        templateContents = templateContents.Replace("##NAME##", className);

        var n = className.Replace("Sample", "");

        n = ToLowerInvariant(n[0]) + n.Substring(1);

        templateContents = templateContents.Replace("&NAME&", n);

        var encoding = new UTF8Encoding(true, false);

        using (var tc = new StreamWriter(filePath, false, encoding))
        {
            tc.Write(templateContents);
        }


        AssetDatabase.ImportAsset(pathName);
        AssetDatabase.Refresh();


        return (MonoScript) AssetDatabase.LoadAssetAtPath(pathName, typeof(MonoScript));
    }

    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var o = CreateScript(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset((Object) o);
        AssetDatabase.Refresh();
    }
}