using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TerminalEventArgs
{
	public TerminalEventArgs(GameObject gameObject, params object[] param)
	{
		targetObject = gameObject;

		foreach (var item in param)
		{
			Add(item);
		}
	}

	public GameObject targetObject { get; set; }

	private List<object> Params = new List<object>();
	public void Add(object parameter)
	{
		Params.Add(parameter);
	}
	public T Get<T>(int index)
	{
		try
		{
			return (T)Params[index];
		}
		catch (Exception)
		{
			return default;
		}
	}
}

