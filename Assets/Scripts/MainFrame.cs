using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;


public class MainFrame : EditorWindow {

	public List<Editor.Module> loadedModules { get; private set;}
	Editor.Module currentActiveModule;
	static MainFrame window;

	// This should display the mainframe options, for now it only displays buttons
	// that are used to switch between different modules. 

	void OnGUI(){
		
		EditorGUILayout.BeginHorizontal ();
		foreach (Editor.Module module in loadedModules) {
			EditorGUI.BeginDisabledGroup (module == currentActiveModule);
			if (GUILayout.Button (module.Name)) {
				currentActiveModule = module;
			}
			EditorGUI.EndDisabledGroup ();
		}
		EditorGUILayout.EndHorizontal ();

		if (currentActiveModule != null) {
			currentActiveModule.Main ();
		}

	}









	#region Initialization

	[MenuItem("Role Playing System/Editor")]
	static void Initialize(){
		window = EditorWindow.GetWindow (typeof(MainFrame)) as MainFrame;
	}

	void OnEnable(){
		loadedModules = new List<Editor.Module> ();
		LoadModulesUsingReflection ();
	}

	public static IEnumerable FindDerivedTypes<T>() where T : class
	{
		var type = typeof(T);

		var derivedClasses = Assembly.GetExecutingAssembly ()
			.GetTypes ().Where(x => x.IsSubclassOf(type)).ToList();

		return derivedClasses;
	}

	void LoadModulesUsingReflection(){
		foreach (Type moduleType in FindDerivedTypes<Editor.Module>()) {
			Editor.Module moduleInstance = moduleType.GetConstructors () [0].Invoke (new object[0]) as Editor.Module;
			moduleInstance.SetMainframe (this);
			//Debug.Log ("Loaded module: " + moduleInstance.ToString ().Split (new char[]{ '.' }) [1]);
			loadedModules.Add (moduleInstance);
		}
		//Debug.Log ("Total loaded modules: " + loadedModules.Count);
	}

	#endregion

}
