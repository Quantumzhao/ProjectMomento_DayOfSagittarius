using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Components.Equipments;

namespace Assets.Components.Equipments.Weapons
{
	interface IWeapon : IActivate
	{
		float Bearing { get; set; }

		float Range { get; }

		float SteeringRange { get; }
	}
}
