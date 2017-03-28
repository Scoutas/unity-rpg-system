using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RPSystem;

public static class TypeReflection {

	public static IEnumerable FindDerivedTypes<T>() where T : class
	{
		var type = typeof(T);

		var derivedClasses = Assembly.GetExecutingAssembly ()
			.GetTypes ().Where(x => x.IsSubclassOf(type)).ToList();

		return derivedClasses;
	}

	public static T Initialize<T>(System.Type type) where T: class{
		return type.GetConstructors () [0].Invoke (new object[0]) as T;

	}
}
