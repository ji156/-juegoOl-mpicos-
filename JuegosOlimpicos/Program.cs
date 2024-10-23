using JuegosOlimpicos.Clases;
using System;
using System.Collections.Generic;

namespace JuegosOlimpicos
/*
╔══════════════════════════════════════╗
║ Autor:  Ji156               ║
║ GitHub: https://github.com/ji156  ║
║ 2024 -  C#                           ║
╚══════════════════════════════════════╝
-----------------------------------------------------
* SIMULADOR JUEGOS OLÍMPICOS
-----------------------------------------------------

* EJERCICIO:
* ¡Los JJOO de París 2024 han comenzado!
* Crea un programa que simule la celebración de los juegos.
* El programa debe permitir al usuario registrar eventos y participantes,****
* realizar la simulación de los eventos asignando posiciones de manera aleatoria****
* y generar un informe final. Todo ello por terminal.****
* Requisitos:
* 1. Registrar eventos deportivos.****
* 2. Registrar participantes por nombre y país.****
* 3. Simular eventos de manera aleatoria en base a los participantes (mínimo 3).****
* 4. Asignar medallas (oro, plata y bronce) basándose en el resultado del evento.****
* 5. Mostrar los ganadores por cada evento.***
* 6. Mostrar el ranking de países según el número de medallas.***
* Acciones:
* 1. Registro de eventos.
* 2. Registro de participantes.
* 3. Simulación de eventos.
* 4. Creación de informes.***
* 5. Salir del programa.
*/

// NOTA: Esto es un intento de aplicar los principios SOLID.

// ________________________________________________
// Interfaces
/// <summary>Contrato sobre las constantes globales.</summary>
{




	internal class Program
	{
		static void Main(string[] args)
		{
			int opcion = 0;

			// Instancias
			GestorEventos gestorEventos = new GestorEventos();
			RegistrarParticipantes registrarParticipantes = new RegistrarParticipantes();

			do
			{
				try
				{
					Console.WriteLine("Olimpiadas 2024");
					Console.WriteLine("-------------------------------");
					Console.WriteLine("1. Registrar evento");
					Console.WriteLine("2. Registrar participante");
					Console.WriteLine("3. Simular evento");
					Console.WriteLine("4. Crear informe");
					Console.WriteLine("5. Ranking paises");
					Console.WriteLine("6. Salir");
					Console.Write("Selecciona una opción: ");
					opcion = Convert.ToInt32(Console.ReadLine());

					switch (opcion)
					{
						case 1:
							Console.WriteLine("Ingresa el nombre del evento");
							string nombreEvento = Console.ReadLine();
							gestorEventos.AgregarEventos(nombreEvento);
							break;
						case 2:
							Console.WriteLine("Ingresa el nombre del participante");
							string nombreParticipante = Console.ReadLine();
							Console.WriteLine("Ingresa el país");
							string nombrePais = Console.ReadLine();
							string evento;
							while (true)
							{
								Console.WriteLine("¿En qué evento participa?");
								evento = Console.ReadLine();

								// Agregar participante a un evento
								Participantes nuevoParticipante = new Participantes(nombreParticipante, nombrePais, evento);
								// Intentar agregar el participante al evento
								if (gestorEventos.AgregarParticipantesEvento(evento, nuevoParticipante))
								{
									// Salir del bucle si el participante se agregó correctamente
									break;
								}
							}
							break;
						case 3:
							Console.WriteLine("¿Qué evento quieres simular?");
							nombreEvento = Console.ReadLine();
							gestorEventos.SimularEvento(nombreEvento);
							break;
						case 4:
							gestorEventos.CrearInformeParticipantes();
							break;
						case 5:
							gestorEventos.RankingPaises();
							break;
						case 6:
							Console.WriteLine("Saliendo del programa...");
							break;
						default:
							Console.WriteLine("Opción no válida. Intente de nuevo.");
							break;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Error: Ingresaste un valor no válido. Por favor, intenta nuevamente.");
				}
			}
			while (opcion != 6);
		}
	}
}

