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
		Database.PropertyDatabase propertyDatabaseAsset;
		Database.PropertyBlueprint propertyBlueprintDatabaseAsset;
		SerializedObject propertyBlueprintDatabase;
		SerializedObject propertyDatabase;

		static CreateNewPropertyWindow newPropertyWindow;


		public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");

			// We have to load up the databases that exist, and if they do not exist
			// create new ones.
			// TODO: Add functionality to actually allow users to specify the database file to load.
			// TODO: Move paths to their own seperate strings?

			// Try to load the databases right away. 
			propertyBlueprintDatabaseAsset = 
				(Database.PropertyBlueprint)AssetDatabase.LoadAssetAtPath(@"Assets/Database/PropertyBlueprintDatabase.asset", typeof(Database.PropertyBlueprint));
			
			propertyDatabaseAsset = 
				(Database.PropertyDatabase)AssetDatabase.LoadAssetAtPath(@"Assets/Database/PropertyDatabase.asset", typeof(Database.PropertyDatabase));

			// If the database didn't load, check if the folder actually exsists.


			// TODO: Make this a generic method.
			if (propertyBlueprintDatabaseAsset == null) {
				bool created = false;
				Debug.Log ("Checking if Database folder already exists.");
				if (AssetDatabase.IsValidFolder (@"Assets/Database") == false) {
					created = true;
					AssetDatabase.CreateFolder (@"Assets", @"Database");

				}
				Debug.Log ("Does it already exist? " + !created);

				// At this point, the folder Database already exsits, so all we need to do, is to create the asset
				// and load it up into a script as a SerializedObject, for manipulation.
				propertyBlueprintDatabaseAsset = ScriptableObject.CreateInstance(typeof(Database.PropertyBlueprint)) as Database.PropertyBlueprint;
				AssetDatabase.CreateAsset (propertyBlueprintDatabaseAsset, @"Assets/Database/PropertyBlueprintDatabase.asset");
				AssetDatabase.SaveAssets ();
				Debug.Log ("Created new Database" + propertyBlueprintDatabaseAsset.name);
			}

			// TODO: Make this a generic method.
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
				propertyDatabaseAsset = ScriptableObject.CreateInstance(typeof(Database.PropertyDatabase)) as Database.PropertyDatabase;
				AssetDatabase.CreateAsset (propertyDatabaseAsset, @"Assets/Database/PropertyDatabase.asset");
				AssetDatabase.SaveAssets ();
				Debug.Log ("Created new Database" + propertyDatabaseAsset.name);
			}

			propertyBlueprintDatabase = new SerializedObject (propertyBlueprintDatabaseAsset);
			propertyDatabase = new SerializedObject (propertyDatabaseAsset);
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
			SerializedProperty nP = propertyBlueprintDatabase.FindProperty ("propertyBlueprintList");
			for (int i = 0; i < nP.arraySize; i++) {
				EditorGUI.BeginDisabledGroup (i == propertyEditorSelectedIndex);
				if (GUILayout.Button (nP.GetArrayElementAtIndex (i).FindPropertyRelative ("propertyName").stringValue)) {
					propertyEditorSelectedIndex = i;
				}
				EditorGUI.EndDisabledGroup ();
			}
			EditorGUILayout.EndVertical ();
			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(200));
			string name = "null";
			if (propertyEditorSelectedIndex != -1) {
				name = "All " + nP.GetArrayElementAtIndex (propertyEditorSelectedIndex).FindPropertyRelative ("propertyName").stringValue;
			}
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField (name, EditorStyles.boldLabel);
			if (GUILayout.Button ("Test")) {


				SerializedProperty dictionary = propertyDatabase.FindProperty ("intAndIntDictionary");
				Debug.Log(dictionary.FindPropertyRelative ("_Keys").arraySize);





			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();


			EditorGUILayout.EndHorizontal ();

		}

		// TODO: In the future, the information sent into this method should be using a struct.
		// TODO: In addition, user should be describing the names of these strings and so forth, so instead of
		//		 using an array, I should exchange them for dictionaries, possibly.
		public void AddNewProperty(ItemSystemEditor.PropertyBlueprint blueprint){
			propertyBlueprintDatabase.Update ();

			SerializedProperty blueprintList = propertyBlueprintDatabase.FindProperty ("propertyBlueprintList");

			int index = blueprintList.arraySize;
			blueprintList.InsertArrayElementAtIndex (index);
			blueprintList.GetArrayElementAtIndex (index).FindPropertyRelative ("propertyName").stringValue = blueprint.propertyName;
			SerializedProperty attributes = blueprintList.GetArrayElementAtIndex (index).FindPropertyRelative ("attributes");
			attributes.arraySize = blueprint.attributes.Count;
			for (int i = 0; i < attributes.arraySize; i++) {
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("ID").intValue = blueprint.attributes [i].ID;
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("Name").stringValue = blueprint.attributes [i].Name;
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("Type").stringValue = blueprint.attributes [i].Type;
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
		if (newBlueprint == null) {
			newBlueprint = new ItemSystemEditor.PropertyBlueprint ();
			newBlueprint.attributes = new List<Attribute> ();
		}
		newBlueprint.propertyName = EditorGUILayout.TextField ("Property name: ", newBlueprint.propertyName);

		if (GUILayout.Button ("Add new attribute")) {
			newBlueprint.attributes.Add (new Attribute ());
		}

		for (int i = 0; i < newBlueprint.attributes.Count; i++) {
			EditorGUILayout.LabelField (i.ToString (), EditorStyles.boldLabel);
			Attribute currAtt = newBlueprint.attributes [i];
			currAtt.ID = EditorGUILayout.IntField ("ID: ", currAtt.ID);
			currAtt.Name = EditorGUILayout.TextField ("Name: ", currAtt.Name);
			currAtt.Type = EditorGUILayout.TextField ("Type: ", currAtt.Type);
			newBlueprint.attributes [i] = currAtt;
		}

		if (GUILayout.Button ("Finish")) {
			parent.AddNewProperty (newBlueprint);
			window.Close ();
		}


//		newBlueprint.hasStrings = EditorGUILayout.Toggle ("Has strings", newBlueprint.hasStrings );
//		newBlueprint.hasIntegers = EditorGUILayout.Toggle ("Has integers", newBlueprint.hasIntegers );
//
//		if(newBlueprint.hasStrings){
//			newBlueprint.stringCount = EditorGUILayout.IntField ("String Count: ", newBlueprint.stringCount);
//			for (int i = 0; i < newBlueprint.stringCount; i++) {
//				
//			}
//		}
//
//		if(newBlueprint.hasIntegers){
//			newBlueprint.integerCount = EditorGUILayout.IntField ("Integer Count: ", newBlueprint.integerCount);
//		}



//		if (GUILayout.Button ("Add New Property")) {
//			if (stringCount == null || hasStrings == false) {
//				stringCount = 0;
//			}
//			parent.AddNewProperty (name, stringCount, propertyNames);
//			window.Close ();
//		}
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

