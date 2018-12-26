using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TerminalEventArgs
{
	public GameObject targetObject { get; set; }

	private List<object> Params = new List<object>();
	public void Add<T>(T parameter)
	{
		Params.Add(parameter);
	}
	//public T Get()
}

