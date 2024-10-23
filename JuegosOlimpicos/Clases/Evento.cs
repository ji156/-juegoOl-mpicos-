using System;
using System.Collections.Generic;
using System.Linq;

namespace JuegosOlimpicos.Clases
{
	public class GestorEventos
	{
		private List<string> eventos; // Almacenar eventos
		private Dictionary<string, List<Participantes>> participantesPorEvento; // Registra eventos a los participantes
		private Dictionary<string, MedallasPorPais> medallasPorPais; // Registra medallas a los paises

		//Constructor
		public GestorEventos()
		{
			eventos = new List<string>();
			participantesPorEvento = new Dictionary<string, List<Participantes>>();
			medallasPorPais = new Dictionary<string, MedallasPorPais>(); 
		}

		//Metodos
		public void AgregarEventos(string evento)
		{
			if (string.IsNullOrEmpty(evento))
			{
				Console.WriteLine("Evento no puede estar vacio");
				return;
			}
			eventos.Add(evento);
			participantesPorEvento[evento] = new List<Participantes>(); 
		}

		// Agregar participantes a un evento
		public bool AgregarParticipantesEvento(string evento, Participantes participantes)
		{
			if (!participantesPorEvento.ContainsKey(evento))
			{
				Console.WriteLine($"El evento {evento} no existe");
				return false;
			}
			participantesPorEvento[evento].Add(participantes);
			return true;
		}
		public void MostrarEventos()
		{
			int index = 1;
			foreach (var evento in eventos)
			{
				Console.WriteLine($"{index}. {evento}");
				index++;
			}
		}
		// Metodo para simular un evento
		public void SimularEvento(string evento)
		{
			if (!participantesPorEvento.ContainsKey(evento) || participantesPorEvento[evento].Count <= 3)
			{
				Console.WriteLine($"No se puede simular el evento '{evento}' porque no tiene participantes suficientes.");
				return;
			}

			List<Participantes> participantes = participantesPorEvento[evento];
			//Desordenar la lista anterior
			Random rand = new Random();
			var participantesDesordenados = participantes.OrderBy(x=>rand.Next()).ToList();

			Participantes oro = participantesDesordenados[0];
			Participantes plata = participantesDesordenados[1];
			Participantes bronce = participantesDesordenados[2];

			if (!medallasPorPais.ContainsKey(oro.Pais))
				medallasPorPais[oro.Pais] = new MedallasPorPais();
			if (!medallasPorPais.ContainsKey(plata.Pais))
				medallasPorPais[plata.Pais] = new MedallasPorPais();
			if (!medallasPorPais.ContainsKey(bronce.Pais))
				medallasPorPais[bronce.Pais] = new MedallasPorPais();


			// Actualizar medallas
			medallasPorPais[oro.Pais].Oro++;
			medallasPorPais[plata.Pais].Plata++;
			medallasPorPais[bronce.Pais].Bronce++;

			// Mostrar ganadores
			Console.WriteLine($"Medalla de oro '{evento}' es: {oro.Nombre} de {oro.Pais}.");
			Console.WriteLine($"Medalla de plata '{evento}' es: {plata.Nombre} de {plata.Pais}.");
			Console.WriteLine($"Medalla de bronce '{evento}' es: {bronce.Nombre} de {bronce.Pais}.");

			//Mostrar todos los resultados
			for (int i = 0; i < participantes.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {participantesDesordenados[i].Nombre} de {participantesDesordenados[i].Pais}");
			}
		}
		public void CrearInformeParticipantes()
		{
			Console.WriteLine("\nInforme de Participantes:");
			Console.WriteLine($"Total de participantes: {participantesPorEvento.SelectMany(p => p.Value).Count()}");

			var participantes = participantesPorEvento.SelectMany(p => p.Value).GroupBy(p => p.Pais);

			foreach (var pais in participantes)
			{
				Console.WriteLine($"País: {pais.Key}, Participantes: {pais.Count()}");
				foreach (var p in pais)
				{
					Console.WriteLine($" - {p.Nombre}, {p.Disciplina} ");
				}
			}
		}
		public void RankingPaises() 
		{
			Console.WriteLine("\nMedallas por país:");
			foreach (var pais in medallasPorPais.Keys)
			{
				var medallas = medallasPorPais[pais];
				Console.WriteLine($"{pais} - Oro: {medallas.Oro}, Plata: {medallas.Plata}, Bronce: {medallas.Bronce}");
			}
		}
	}
}
