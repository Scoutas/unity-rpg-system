using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module{

	enum ItemSystemTypes { DEFAULT, PROPERTY_CREATOR, PROPERTY_EDITOR, ITEM_EDITOR};

	public class ItemSystem : Editor.Module {

		#region Information
		
		public override string Name {
			get {
				return "Item System";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.03";
			}
		}

		public override string VersionHistory {
			get {
				return 	"ItemSystem Module :: Version 0.0.03 \n" +
					" + Added a possibility to create property blueprints. \n    NOTE: At this point, these blueprints only have \n    functionality with strings\n" +
					"    NOTE2: This possible will change in the future. \n\n" +
					"ItemSystem Module :: Version 0.0.02 \n" +
					" + Added choise between creating Properties, editing them and creating items. \n    NOTE: Still needs implementation of the functionality \n" +
					" + Added Database creation for Properties. \n    No functionality for actually adding to these databases as of yet. \n\n" +
					"ItemSystem Module :: Version 0.0.01 \n" +
					" + Added 'Version History' \n" +
					" + Initial setup";
			}
		}

			
		#endregion

		ItemSystemTypes currentType = ItemSystemTypes.DEFAULT;
		SerializedObject propertyBlueprintDatabase;

		static CreateNewPropertyWindow newPropertyWindow;


		public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");

			// We have to load up the databases that exist, and if they do not exist
			// create new ones.
			// TODO: Add functionality to actually allow users to specify the database file to load.
			// TODO: Move paths to their own seperate strings?

			// Try to load the databases right away. 
			Database.PropertyBlueprint propertyDatabaseAsset = (Database.PropertyBlueprint)AssetDatabase.LoadAssetAtPath(@"Assets/Database/PropertyBlueprintDatabase.asset", typeof(Database.PropertyBlueprint));


			// If the database didn't load, check if the folder actually exsists.

			if (propertyDatabaseAsset == null) {
				bool created = false;
				Debug.Log ("Checking if Database folder already exists.");
				if (AssetDatabase.IsValidFolder (@"Assets/Database") == false) {
					created = true;
					AssetDatabase.CreateFolder (@"Assets", @"Database");

				}
				Debug.Log ("Does it already exist? " + !created);

				// At this point, the folder Database already exsits, so all we need to do, is to create the asset
				// and load it up into a script as a SerializedObject, for manipulation.
				propertyDatabaseAsset = ScriptableObject.CreateInstance(typeof(Database.PropertyBlueprint)) as Database.PropertyBlueprint;
				AssetDatabase.CreateAsset (propertyDatabaseAsset, @"Assets/Database/PropertyBlueprintDatabase.asset");
				AssetDatabase.SaveAssets ();
				Debug.Log ("Created new Database");
			}

			propertyBlueprintDatabase = new SerializedObject (propertyDatabaseAsset);
			//Debug.Log ("propertyDatabase: " + propertyDatabase);




			// At this step, the directory already exists, so we try to find the database file.

			//Database.Property propertyDatabaseAsset = (Database.Property)AssetDatabase.LoadAssetAtPath(@"Asset



		}

		public override void Main ()
		{
			#region TOP_INFO
			EditorGUILayout.LabelField ("Working with " + Name + " module.", EditorStyles.boldLabel);
			
			EditorGUILayout.BeginHorizontal ();
			int typeCount = System.Enum.GetNames (typeof(ItemSystemTypes)).Length;
			EditorGUILayout.LabelField("There are " + (typeCount - 1)  + " types of ItemSystems");
			for (int i = 1; i < typeCount; i++) {
				string typeName = System.Enum.GetName (typeof(ItemSystemTypes), i);
				if (GUILayout.Button (typeName)) {
					currentType = (ItemSystemTypes)i;
				}
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.LabelField("Currently active type: " + currentType.ToString());
			#endregion

			switch (currentType) {
			case ItemSystemTypes.DEFAULT:
				break;
			case ItemSystemTypes.ITEM_EDITOR:
				ItemEditorGUI ();
				break;
			case ItemSystemTypes.PROPERTY_CREATOR:
				PropertyCreatorGUI ();
				break;
			case ItemSystemTypes.PROPERTY_EDITOR:
				PropertyEditorGUI ();
				break;

			}
		}

		void PropertyCreatorGUI (){
			EditorGUILayout.LabelField ("You're in property creator");
			if (GUILayout.Button ("Create new property")) {
				if (newPropertyWindow != null) {
					newPropertyWindow.Focus ();
					return;
				}

				newPropertyWindow = CreateNewPropertyWindow.Initialize (this);

			}
		}

		int propertyEditorSelectedIndex = -1;

		void PropertyEditorGUI (){
			EditorGUILayout.LabelField ("You're in property editor");
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(200));
			EditorGUILayout.LabelField ("Property Blueprints:", EditorStyles.boldLabel);
			SerializedProperty nP = propertyBlueprintDatabase.FindProperty ("properties");
			for (int i = 0; i < nP.arraySize; i++) {
				EditorGUI.BeginDisabledGroup (i == propertyEditorSelectedIndex);
				if (GUILayout.Button (nP.GetArrayElementAtIndex (i).FindPropertyRelative ("propertyName").stringValue)) {
					propertyEditorSelectedIndex = i;
				}
				EditorGUI.EndDisabledGroup ();
			}
			EditorGUILayout.EndVertical ();
			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(200));
			string name = "All " + nP.GetArrayElementAtIndex (propertyEditorSelectedIndex).FindPropertyRelative ("propertyName").stringValue;
			EditorGUILayout.LabelField (name, EditorStyles.boldLabel);

			EditorGUILayout.EndVertical ();


			EditorGUILayout.EndHorizontal ();

		}

		// TODO: In the future, the information sent into this method should be using a struct.
		// TODO: In addition, user should be describing the names of these strings and so forth, so instead of
		//		 using an array, I should exchange them for dictionaries, possibly.
		public void AddNewProperty(string name, int stringCount, string[] propertyNames){
			Debug.Log (propertyBlueprintDatabase);
			propertyBlueprintDatabase.Update ();
			SerializedProperty nP = propertyBlueprintDatabase.FindProperty ("properties");
			int index = nP.arraySize;
			nP.InsertArrayElementAtIndex (index);
			nP.GetArrayElementAtIndex (index).FindPropertyRelative("propertyName").stringValue = name;
			nP.GetArrayElementAtIndex (index).FindPropertyRelative ("stringCount").intValue = stringCount;
			nP.GetArrayElementAtIndex (index).FindPropertyRelative ("attributeNames").arraySize = stringCount;
			for (int i = 0; i < stringCount; i++) {
				nP.GetArrayElementAtIndex (index).FindPropertyRelative ("attributeNames").GetArrayElementAtIndex(i).stringValue = propertyNames[i];
			}

			propertyBlueprintDatabase.ApplyModifiedProperties ();
		}

		void ItemEditorGUI (){
			EditorGUILayout.LabelField ("You're in item creator");
		}



		// Property is a blueprint for actual properties. 
		// e.g. If you need a type for an item, you'd create
		// a property with a name of Type and create different
		// requirement that it has (like Type name, strings or integers,
		// sprites or colors etc.). 
		// Then in Property Editor you would be able to create new
		// properties using the blueprint, and store it in it's own database.


		// Then, once you need to create an item, you would simply create it
		// and specify, what kind of properties it should have
		// and then would be able to pick out of the properties that you have
		// created. 

		// :::::::::::::::::::::::::::
		// Property Creator
		// 1. Create a property blueprint
		// 2. Add this property blueprint to the property list/database
		// 3. Create a database for this property
		// Once this is done, one should be able to pick this property blueprint
		// to use in creating new actual properties, which would be stored
		// inside the database that was created for this property.
		// :::::::::::::::::::::::::::

		// :::::::::::::::::::::::::::
		// A Property Blueprint
		// When creating a property blueprint, one would specify
		// what kind of attributes/variables/logic should be inside
		// this property blueprint. 
		// e.g. for variables:
		// 		A 'Quality/Rarity' property could have a string, for it's name
		//		and a color, for the item name color. 
		// e.g. for logic:
		// 		A 'Type' property, could have 'Subtypes'.
		//      for example 
		//		|| Weapon -> Melee -> One-Handed ||
		// 		Here, Weapon is a TYPE, and Melee and One-Handed is a SUBTYPE
		// 		It would require some logic, so that when creating an item
		// 		it would only show SUBTYPES, that are derived from a TYPE.
		//		for example
		//		creating an item, you add a TYPE, and specify that it has subtypes.
		//		then when creating SUBTYPE, you specify that it has a parent, and specify what it is.
		//		Once you do, only SUBTYPES that derive from TYPE should show up to be chosen.
		// :::::::::::::::::::::::::::

		
	}
}

public class CreateNewPropertyWindow : EditorWindow {

	static Module.ItemSystem parent;
	static CreateNewPropertyWindow window;
	ItemSystemEditor.PropertyBlueprint newBlueprint;

	void OnGUI(){
		newBlueprint.propertyName = EditorGUILayout.TextField ("Property name: ", newBlueprint.propertyName);
		newBlueprint.hasStrings = EditorGUILayout.Toggle ("Has strings", newBlueprint.hasStrings );
		if(newBlueprint.hasStrings){
			newBlueprint.stringCount = EditorGUILayout.IntField ("String Count: ", newBlueprint.stringCount);
		}
		// TODO: Do I actually need integer counts?
		if(newBlueprint.hasIntegers){
			newBlueprint.stringCount = EditorGUILayout.IntField ("String Count: ", newBlueprint.stringCount);
		}

		if (GUILayout.Button ("Add New Property")) {
			if (stringCount == null || hasStrings == false) {
				stringCount = 0;
			}
			parent.AddNewProperty (name, stringCount, propertyNames);
			window.Close ();
		}
		if (GUILayout.Button ("Cancel")) {
			window.Close ();
		}
	}

	#region Initialization
	public static CreateNewPropertyWindow Initialize(Module.ItemSystem _parent){
		ParentSetup (_parent);
		window = EditorWindow.GetWindow (typeof(CreateNewPropertyWindow)) as CreateNewPropertyWindow;
		return window;
	}

	static void ParentSetup(Module.ItemSystem _parent){
		if (parent == null) {
			parent = _parent;
		} else {
			if (parent.Equals (_parent)) {
				Debug.Log ("Correct parent is already set");
			} 
			else {
				Debug.LogError ("Parent sent in to initialization is different from already assigned parent. Will assign new parent!");
				parent = _parent;
			}
		}
	}
	#endregion

}
