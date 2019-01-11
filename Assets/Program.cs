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
		private Dictionary<string, object> tempVariables =
			new Dictionary<string, object>();
		private Dictionary<string, Func<object>> functions =
			new Dictionary<string, Func<object>>();
		private Dictionary<string, CustomizedFunctionWrapper> funcBlocks =
			new Dictionary<string, CustomizedFunctionWrapper>();
		private Dictionary<string, object> executionSequence =
			new Dictionary<string, object>();

		public CustomizedFunctionWrapper() { }
		public CustomizedFunctionWrapper(
			Dictionary<string, object> parameters,
			KeyValuePair<string, Func<object>> function = new KeyValuePair<string, Func<object>>())
		{
			AddVariable(parameters);
			if (function.Value != null)
			{
				AddFunction(function.Key, function.Value);
			}
		}

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
		public void AddFunction(string name, Func<object> method)
		{
			functions.Add(name, method);
			executionSequence.Add(name, functions[name]);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="funcBlock"></param>
		public void AddFunction(string name, CustomizedFunctionWrapper funcBlock)
		{
			funcBlocks.Add(name, funcBlock);
			executionSequence.Add(name, funcBlocks[name]);
		}

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

			foreach (KeyValuePair<string, Func<object>> function in functions)
			{
				//tempResult = new KeyValuePair<string, object>
				//	(function.Key, function.Value.Invoke());

				tempResult = new KeyValuePair<string, object>
				(
					function.Key,
					function
						.Value
						.GetType()
						.GetMethod("Invoke")
						.Invoke
						(
							function.Value,
							new object[] { }
						)
				);

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
			get => tempVariables[name];
			set => tempVariables[name] = value;
		}

		/// <summary>
		///		Show the invocation sequence
		/// </summary>
		/// <returns>A list of the names of functions ordered by their invocation</returns>
		public IEnumerable<string> ShowInvocationOrder()
		{
			foreach (KeyValuePair<string, object> function in executionSequence)
				yield return function.Key;
		}
	}
}