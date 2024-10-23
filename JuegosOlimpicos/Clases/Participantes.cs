using System;
using System.Collections.Generic;

namespace JuegosOlimpicos.Clases
{
	public class Participantes
	{
		public string Nombre { get; set; }
		public string Pais { get; set; }
		public string Disciplina { get; set; }
		public Participantes(string nombre, string pais, string disciplina)
		{
			Nombre = nombre;
			Pais = pais;
			Disciplina = disciplina;
		}
	}
	public class RegistrarParticipantes
	{
		private List<Participantes> listaParticipantes;
		//Constructor
		public RegistrarParticipantes()
		{
			listaParticipantes = new List<Participantes>();
		}
		//Metodo nuevo participante
		public void NuevoParticioante(string nombre, string pais, string disciplina)
		{
			if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(pais)) 
			{
				Console.WriteLine("Nombre o país no pueden estar vacios");
				return;
			}
			listaParticipantes.Add(new Participantes(nombre, pais, disciplina));
		}
		// Metodo mostrar todos participantes
		public void MostrarParticipantes()
		{
			if (listaParticipantes.Count == 0)
			{
				Console.WriteLine("No hay participantes");
			}
			foreach (var participante in listaParticipantes)
			{
				Console.WriteLine($"Nombre: {participante.Nombre} Pais: {participante.Pais}");
			}
		}
	}
}

