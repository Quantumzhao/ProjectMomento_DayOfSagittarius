using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Components.Equipments
{
	/// <summary>
	///		All equipments should implement this. 
	/// </summary>
	interface IActivate
	{
		/// <summary>
		///		The main access point of equipment
		/// </summary>
		/// <returns>
		///		If this equipment is successfully activated, return true
		///		Otherwise, false. 
		/// </returns>
		bool Activate(Transform transform);
	}
}
