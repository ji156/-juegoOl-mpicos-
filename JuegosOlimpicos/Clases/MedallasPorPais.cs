using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosOlimpicos.Clases
{
	public class MedallasPorPais
	{
		public int Oro {  get; set; }
		public int Plata { get; set; }
		public int Bronce { get; set; }

		public MedallasPorPais() 
		{
			Oro = 0;
			Plata = 0;
			Bronce = 0;
		}
	}
}
