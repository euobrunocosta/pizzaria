using System;

namespace pizzaria.domain {
	
	public class Entregador {

		public string nome { get; set; }
		public long cpf { get; set; }
		public int rg { get; set; }
		public int celular { get; set; }
		
		public Entregador(string nome, long cpf, int rg, int celular) {
			this.nome = nome;
			this.cpf = cpf;
			this.rg = rg;
			this.celular = celular;
		}

		public static void mostrarEntregadores() {

			Console.Clear();
			Console.WriteLine("LISTA DE ENTREGADORES");
			Console.WriteLine("");

			for (int i = 0; i < Program.entregadores.Count; i++) {
				Console.WriteLine(Program.entregadores[i]);
			}

			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public static void cadastrarEntregador() {
			
			Console.Clear();
			Console.WriteLine("CADASTRO DE ENTREGADOR");
			Console.WriteLine("");
			Console.WriteLine("Digite os dados do entregador");
			Console.WriteLine("");

			Console.Write("Nome: ");
			string nome = Console.ReadLine();

			Console.Write("CPF: ");
			long cpf = long.Parse(Console.ReadLine());

			Console.Write("RG: ");
			int rg = int.Parse(Console.ReadLine());

			Console.Write("Celular: ");
			int celular = int.Parse(Console.ReadLine());

			Entregador E = new Entregador(nome, cpf, rg, celular);
			Program.entregadores.Add(E);

			Console.WriteLine("");
			Console.WriteLine("Entregador cadastrado com sucesso!");
			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public override string ToString() {

			return "Nome: " + nome + 
				", CPF: " + cpf +
				", RG: " + rg +
				", Celular: " + celular;

		}

	}

}
