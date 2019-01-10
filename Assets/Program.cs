using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestCustomizedFunction
{
	class CustomizedFunctionWrapper
	{
		private Dictionary<string, object> tempVariables = new Dictionary<string, object>();
		private Dictionary<string, Func<Dictionary<string, object>, object>> functions =
			new Dictionary<string, Func<Dictionary<string, object>, object>>();

		/// <summary>
		///		Add one local variable to the wrapped function
		/// </summary>
		/// <param name="name"> Name of the parameter</param>
		/// <param name="data"> The object data of the parameter</param>
		public void AddVariable(string name, object data)
			=> tempVariables.Add(name, data);

		/// <summary>
		///		Add multiple variables at once to the wrapped function
		/// </summary>
		/// <param name="parameters">
		///		The variable list, containing names and data of each variable respectively
		///	</param>
		public void AddVariable(Dictionary<string, object> parameters)
			=> tempVariables = tempVariables.Concat(parameters) as Dictionary<string, object>;

		/// <summary>
		///		Add one subprocedure or function to the wrapped function
		/// </summary>
		/// <param name="name">
		///		<para>The name of the function</para>
		///		<para>
		///			NOTE: If the function has a return value, 
		///			the return value will be stored inside the 
		///			<code>CustomizedFunctionWrapper</code> typed instance, 
		///			and its name is the same as the function. 
		///		</para>
		/// </param>
		/// <param name="method"></param>
		public void AddFunction(string name, Func<Dictionary<string, object>, object> method)
			=> functions.Add(name, method);

		/// <summary>
		///		To invoke the wrapped function
		/// </summary>
		/// <returns>
		///		If the wrapped function is void type, then return null
		///		Otherwise a meaningful return value
		/// </returns>
		public object Invoke()
		{
			KeyValuePair<string, object> tempResult = new KeyValuePair<string, object>();

			foreach (KeyValuePair<string, Func<Dictionary<string, object>, object>> function in functions)
			{
				tempResult = new KeyValuePair<string, object>
					(function.Key, function.Value.Invoke(tempVariables));

				if (tempResult.Value != null)
				{
					tempVariables.Add(tempResult.Key, tempResult.Value);
				}
			}
			return tempResult.Value;
		}

		/// <summary>
		///		The generic version of the indexer
		/// </summary>
		/// <typeparam name="T">The type of the return value</typeparam>
		/// <param name="name">The name of the <c>tempVariable</c>, which is used to find it</param>
		/// <returns>The requested variable</returns>
		public T GetTempVariable<T>(string name) => (T)tempVariables[name];

		/// <summary>
		///		The Indexer. This version is easier to use. 
		/// </summary>
		/// <param name="name">The name of the <c>tempVariable</c>, which is used to find it</param>
		/// <returns>The requested variable</returns>
		public object this[string name]
		{
			get
			{
				 return tempVariables[name];
			}
			set
			{
				tempVariables[name] = value;
			}
		}

		/// <summary>
		///		Show the invocation sequence
		/// </summary>
		/// <returns>A list of the names of functions ordered by their invocation</returns>
		public IEnumerable<string> ShowInvocationOrder()
		{
			foreach (KeyValuePair<string, Func<Dictionary<string, object>, object>> function in functions)
				yield return function.Key;
		}
	}
}