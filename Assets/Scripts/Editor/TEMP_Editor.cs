using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TEMP_Editor : EditorWindow {

	[MenuItem("Role Playing System/Editor")]
	public static void InitializeWindow(){
		TEMP_Editor window = EditorWindow.GetWindow (typeof(TEMP_Editor)) as TEMP_Editor;
		window.titleContent = new GUIContent ("KEK");
	}

	TEMP_CreateProperty property_window;

	#region Variables

	//public PropertyDatabase databaseAsset;
	public SerializedObject database;

	#endregion

	#region Database Paths

	public const string PARENT_FOLDER = @"Assets";
	public const string DATABASE_FOLDER = @"Databases";
	public const string DATABASE_BACKUP_FOLDER = @"Backup";
	public const string DATABASE_SUFFIX = @".asset";


	public string DATABASE_NAME = @"Undefined Database";
	public string DATABASE_DIRECTORY_FULL;
	public string DATABASE_BACKUP_DIRECTORY_FULL;
	public string DATABASE_PATH_FULL;

	#endregion

	public void SetupPaths(string databaseName){
		DATABASE_NAME 					= @"" + databaseName;
		DATABASE_DIRECTORY_FULL 		= PARENT_FOLDER + "/" + DATABASE_FOLDER;
		DATABASE_BACKUP_DIRECTORY_FULL 	= DATABASE_DIRECTORY_FULL + "/" + DATABASE_BACKUP_FOLDER;
		DATABASE_PATH_FULL				= DATABASE_DIRECTORY_FULL + "/" + DATABASE_NAME + DATABASE_SUFFIX;
	}

//	public virtual void OnEnable()
//	{	
//		SetupPaths ("PROPERTYIS");
//		// Try to load up the database at the specified location.
//		databaseAsset = (PropertyDatabase)AssetDatabase.LoadAssetAtPath(DATABASE_PATH_FULL, typeof(PropertyDatabase));
//
//
//		if (databaseAsset != null) {
//			// If we find the database, create a SerializedObject using that.
//			database = new SerializedObject (databaseAsset);
//		}
//		else if (databaseAsset == null) 
//		{
//			// If we didn't find it, check if the directory actually exists.
//			// If it doesn't - create it.
//			if (AssetDatabase.IsValidFolder (DATABASE_DIRECTORY_FULL) == false) 
//			{
//				AssetDatabase.CreateFolder (PARENT_FOLDER, DATABASE_FOLDER);
//			}
//
//			// Once we know the database directory exists, we create the database
//			// and create a SerialzedObject using that database.
//
//			databaseAsset = ScriptableObject.CreateInstance<PropertyDatabase> ();
//			database = new SerializedObject (databaseAsset);
//			AssetDatabase.CreateAsset (databaseAsset, DATABASE_PATH_FULL);
//			AssetDatabase.SaveAssets ();
//		}
//
//
//	}

	void OnGUI(){
		if (GUILayout.Button ("Add new property")) {
			property_window = TEMP_CreateProperty.InitializeWindow (this);
		}
			
	}

	public void AddNewProperty(string name, int stringCount){
		database.Update ();
		SerializedProperty nP = database.FindProperty ("properties");
		int index = nP.arraySize;
		nP.InsertArrayElementAtIndex (index);
		nP.GetArrayElementAtIndex (index).FindPropertyRelative("propertyName").stringValue = name;
		nP.GetArrayElementAtIndex (index).FindPropertyRelative("stringValues").arraySize = stringCount;
		database.ApplyModifiedProperties ();
	}
}

public class TEMP_CreateProperty: EditorWindow {

	static TEMP_Editor parent;
	static TEMP_CreateProperty window;
	string name;
	bool hasStrings;
	int stringCount;

	public static TEMP_CreateProperty InitializeWindow(TEMP_Editor _parent){
		parent = _parent;
		window = EditorWindow.GetWindow (typeof(TEMP_CreateProperty)) as TEMP_CreateProperty;
		window.titleContent = new GUIContent ("New Property");

		return window;
	}

	public void OnGUI(){
		name = EditorGUILayout.TextField ("Property name: ", name);
		hasStrings = EditorGUILayout.Toggle ("Stings?", hasStrings);
		if(hasStrings){
			stringCount = EditorGUILayout.IntField ("String Count: ", stringCount);
		}

		if (GUILayout.Button ("Add New Property")) {
			if (stringCount == null || hasStrings == false) {
				stringCount = 0;
			}
			parent.AddNewProperty (name, stringCount);
			window.Close ();
		}
		if (GUILayout.Button ("Cancel")) {
			window.Close ();
		}
	}
}
