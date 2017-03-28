using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!
// TODO: REFACTOR THIS CONVOLUTED SHIT OF A CODE!!!!


namespace Module{

	enum ItemSystemTypes { DEFAULT, PROPERTY_CREATOR, PROPERTY_EDITOR, ITEM_EDITOR};

	public class ItemSystem : RPSystem.MainframeModule {

		#region Information
		
		public override string Name {
			get {
				return "Item System";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.04";
			}
		}

		public override string VersionHistory {
			get {
				return 	"ItemSystem Module :: Version 0.0.04 \n" +
					" + Code currently is a convoluted mess, but we're getting closer to a really simple, \n" +
					"   implementation of creating property blueprints and creating actual properties using them. \n\n" +
					"ItemSystem Module :: Version 0.0.03 \n" +
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
		public SerializedObject propertyBlueprintDatabase;
		public SerializedObject propertyDatabase;

		static CreateNewBlueprintWindow newBlueprintWindow;
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
				if (newBlueprintWindow != null) {
					newBlueprintWindow.Focus ();
					return;
				}

				newBlueprintWindow = CreateNewBlueprintWindow.Initialize (this);

			}
		}

		public int propertyEditorSelectedIndex = -1;

		void PropertyEditorGUI (){
			EditorGUILayout.LabelField ("You're in property editor");
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(200));
			EditorGUILayout.LabelField ("Property Blueprints:", EditorStyles.boldLabel);
			SerializedProperty blueprintList = propertyBlueprintDatabase.FindProperty ("propertyBlueprintList");
			for (int i = 0; i < blueprintList.arraySize; i++) {
				EditorGUI.BeginDisabledGroup (i == propertyEditorSelectedIndex);
				if (GUILayout.Button (blueprintList.GetArrayElementAtIndex (i).FindPropertyRelative ("propertyName").stringValue)) {
					propertyEditorSelectedIndex = i;
				}
				EditorGUI.EndDisabledGroup ();
			}
			EditorGUILayout.EndVertical ();


			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(200));
			string name = "null";
			SerializedProperty selectedBlueprint = blueprintList.GetArrayElementAtIndex (propertyEditorSelectedIndex);
			if (propertyEditorSelectedIndex != -1) {
				name = "All " + selectedBlueprint.FindPropertyRelative ("propertyName").stringValue;
			}
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField (name, EditorStyles.boldLabel);
			if(GUILayout.Button("Add")){
				if (newPropertyWindow != null) {
					newPropertyWindow.Focus ();
					return;
				}
				newPropertyWindow = CreateNewPropertyWindow.Initialize (this);

			}
			EditorGUILayout.EndHorizontal ();
			// FIXME: THIS IMPLEMENTATION SHOULD BE COMPLETELY DIFFERENT HERE.
			SerializedProperty propertyList = propertyDatabase.FindProperty ("propertyList");
			for (int i = 0; i < propertyList.arraySize; i++) {
				SerializedProperty attribute = selectedBlueprint.FindPropertyRelative ("attributes").GetArrayElementAtIndex (0);
				string typeOfBlueprint = attribute.FindPropertyRelative ("Type").stringValue;
				int internalID = attribute.FindPropertyRelative ("InternalID").intValue;
				SerializedProperty thingToDisplay = propertyList.GetArrayElementAtIndex (i).FindPropertyRelative (typeOfBlueprint + "Values").GetArrayElementAtIndex (internalID);
				switch (typeOfBlueprint) {
				case "string":
					EditorGUILayout.LabelField (thingToDisplay.stringValue);
					break;
				case "int":
					EditorGUILayout.LabelField (thingToDisplay.intValue.ToString());
					break;
				}
			}

			EditorGUILayout.EndVertical ();


			EditorGUILayout.EndHorizontal ();

		}

		// TODO: In the future, the information sent into this method should be using a struct.
		// TODO: In addition, user should be describing the names of these strings and so forth, so instead of
		//		 using an array, I should exchange them for dictionaries, possibly.
		public void AddNewBlueprint(ItemSystemEditor.PropertyBlueprint blueprint){
			propertyBlueprintDatabase.Update ();

			SerializedProperty blueprintList = propertyBlueprintDatabase.FindProperty ("propertyBlueprintList");

			int index = blueprintList.arraySize;
			blueprintList.InsertArrayElementAtIndex (index);
			blueprintList.GetArrayElementAtIndex (index).FindPropertyRelative ("propertyName").stringValue = blueprint.propertyName;
			SerializedProperty attributes = blueprintList.GetArrayElementAtIndex (index).FindPropertyRelative ("attributes");
			attributes.arraySize = blueprint.attributes.Count;
			CalculateInternalID (ref blueprint);
			for (int i = 0; i < attributes.arraySize; i++) {
				// Shouldn't allow to change them really easily, should allow only to change their positions.
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("ExtrernalID").intValue = blueprint.attributes [i].ExtrernalID;
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("InternalID").intValue = blueprint.attributes [i].InternalID;
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("Name").stringValue = blueprint.attributes [i].Name;
				attributes.GetArrayElementAtIndex (i).FindPropertyRelative ("Type").stringValue = blueprint.attributes [i].Type;
			}

			propertyBlueprintDatabase.ApplyModifiedProperties ();
		}

		public void AddNewProperty (ItemSystemEditor.Property sentInProperty){
			propertyDatabase.Update ();
			SerializedProperty currentBlueprint = propertyBlueprintDatabase.FindProperty ("propertyBlueprintList").GetArrayElementAtIndex (propertyEditorSelectedIndex);
			SerializedProperty attributes = currentBlueprint.FindPropertyRelative ("attributes");

			SerializedProperty propertyList = propertyDatabase.FindProperty ("propertyList");
			int indexOfNewProperty = propertyList.arraySize;
			propertyList.InsertArrayElementAtIndex (indexOfNewProperty);
			SerializedProperty newProperty = propertyList.GetArrayElementAtIndex (indexOfNewProperty);
			newProperty.FindPropertyRelative ("propertyName").stringValue = sentInProperty.propertyName;
			for (int i = 0; i < attributes.arraySize; i++) {
				SerializedProperty currentAttribute = attributes.GetArrayElementAtIndex (i);
				int CAIID = currentAttribute.FindPropertyRelative ("InternalID").intValue;
				string CAName = currentAttribute.FindPropertyRelative ("Name").stringValue;
				string CAType = currentAttribute.FindPropertyRelative ("Type").stringValue;

				switch (CAType) {
				case "string":
					newProperty.FindPropertyRelative ("stringValues").InsertArrayElementAtIndex (CAIID);
					newProperty.FindPropertyRelative ("stringValues").GetArrayElementAtIndex (CAIID).stringValue = sentInProperty.stringValues[CAIID];
					break;
				case "int":
					newProperty.FindPropertyRelative ("intValues").InsertArrayElementAtIndex (CAIID);
					newProperty.FindPropertyRelative ("intValues").GetArrayElementAtIndex (CAIID).intValue = sentInProperty.intValues[CAIID];
					break;
				}

			}
			propertyDatabase.ApplyModifiedProperties ();
		}

		void ItemEditorGUI (){
			EditorGUILayout.LabelField ("You're in item creator");
		}

		void CalculateInternalID(ref ItemSystemEditor.PropertyBlueprint blueprint){
			int stringCounter = 0;
			int intCounter = 0;

			for (int i = 0; i < blueprint.attributes.Count; i++) {
				string Type = blueprint.attributes [i].Type;

				switch (Type) {
				case "string":
					blueprint.attributes [i].InternalID = stringCounter;
					stringCounter++;
					break;
				case "int":
					blueprint.attributes [i].InternalID = intCounter;
					intCounter++;
					break;
				}
			}
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

public class CreateNewBlueprintWindow : EditorWindow {

	static Module.ItemSystem parent;
	static CreateNewBlueprintWindow window;
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
			currAtt.ExtrernalID = EditorGUILayout.IntField ("ID: ", currAtt.ExtrernalID);
			currAtt.Name = EditorGUILayout.TextField ("Name: ", currAtt.Name);
			currAtt.Type = EditorGUILayout.TextField ("Type: ", currAtt.Type);
			newBlueprint.attributes [i] = currAtt;
		}

		if (GUILayout.Button ("Finish")) {
			parent.AddNewBlueprint (newBlueprint);
			window.Close ();
		}

		if (GUILayout.Button ("Cancel")) {
			window.Close ();
		}
	}

	#region Initialization
	public static CreateNewBlueprintWindow Initialize(Module.ItemSystem _parent){
		ParentSetup (_parent);
		window = EditorWindow.GetWindow (typeof(CreateNewBlueprintWindow)) as CreateNewBlueprintWindow;
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


public class CreateNewPropertyWindow : EditorWindow {

	static Module.ItemSystem parent;
	static CreateNewPropertyWindow window;
	ItemSystemEditor.Property newProperty;

	SerializedProperty currentBlueprint;
	SerializedProperty attributes;

	void OnGUI(){

		if (currentBlueprint == null) {
			currentBlueprint = parent.propertyBlueprintDatabase.FindProperty ("propertyBlueprintList").GetArrayElementAtIndex (parent.propertyEditorSelectedIndex);
		}

		if (attributes == null) {
			attributes = currentBlueprint.FindPropertyRelative ("attributes");
		}

		if (newProperty == null) {
			newProperty = new ItemSystemEditor.Property ();
			newProperty.propertyName = currentBlueprint.FindPropertyRelative ("propertyName").stringValue;
		}

		for (int i = 0; i < attributes.arraySize; i++) {
			SerializedProperty currentAttribute = attributes.GetArrayElementAtIndex (i);
			int CAIID = currentAttribute.FindPropertyRelative ("InternalID").intValue;
			string CAName = currentAttribute.FindPropertyRelative ("Name").stringValue;
			string CAType = currentAttribute.FindPropertyRelative ("Type").stringValue;

			switch (CAType) {
			case "string":
				if (newProperty.stringValues.Count <= CAIID) {
					newProperty.stringValues.Insert (CAIID, "");
				}
				newProperty.stringValues [CAIID] = EditorGUILayout.TextField(CAName, newProperty.stringValues [CAIID]);
				break;
			case "int":
				if (newProperty.intValues.Count <= CAIID) {
					newProperty.intValues.Insert (CAIID, 0);
				}
				newProperty.intValues [CAIID] = EditorGUILayout.IntField(CAName, newProperty.intValues [CAIID]);
				break;
			}

		}
		 

		if (GUILayout.Button ("Finish")) {
			parent.AddNewProperty (newProperty);
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
