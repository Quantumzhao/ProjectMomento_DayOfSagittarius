using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Components.Equipments.Weapons
{
	interface IWeapon
	{
		float Bearing { get; set; }

		float Range { get; }

		float SteeringRange { get; }
	}
}
