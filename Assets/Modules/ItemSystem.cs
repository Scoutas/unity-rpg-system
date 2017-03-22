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
				return "0.0.02";
			}
		}

		public override string VersionHistory {
			get {
				return 	"ItemSystem Module :: Version 0.0.02 \n" +
					" + Added choise between creating Properties, editing them and creating items. \n    NOTE: Still needs implementation of the functionality \n" +
					" + Added Database creation for Properties. \n    No functionality for actually adding to these databases as of yet. \n\n" +
					"ItemSystem Module :: Version 0.0.01 \n" +
					" + Added 'Version History' \n" +
					" + Initial setup";
			}
		}

			
		#endregion

		ItemSystemTypes currentType = ItemSystemTypes.DEFAULT;
		SerializedObject propertyDatabase;



		public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");

			// We have to load up the databases that exist, and if they do not exist
			// create new ones.
			// TODO: Add functionality to actually allow users to specify the database file to load.
			// TODO: Move paths to their own seperate strings?

			// Try to load the databases right away. 
			Database.Property propertyDatabaseAsset = (Database.Property)AssetDatabase.LoadAssetAtPath(@"Assets/Database/PropertyDatabase.asset", typeof(Database.Property));


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
				propertyDatabaseAsset = ScriptableObject.CreateInstance(typeof(Database.Property)) as Database.Property;
				AssetDatabase.CreateAsset (propertyDatabaseAsset, @"Assets/Database/PropertyDatabase.asset");
				AssetDatabase.SaveAssets ();
				propertyDatabase = new SerializedObject (propertyDatabaseAsset);
				Debug.Log ("Created new Database");

			}



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
				
			}
		}

		void PropertyEditorGUI (){
			EditorGUILayout.LabelField ("You're in property editor");
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
