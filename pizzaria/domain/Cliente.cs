using System;

namespace pizzaria.domain {
	
	public class Cliente {
		
		public string nome { get; set; }
		public int telefone { get; set; }
		public string endereco { get; set; }
		public string referencia { get; set; }
		public DateTime nascimento { get; set; }
		
		public Cliente(string nome, int telefone, string endereco, string referencia, int dia, int mes, int ano) {
			this.nome = nome;
			this.telefone = telefone;
			this.endereco = endereco;
			this.referencia = referencia;
			nascimento = new DateTime(ano, mes, dia);
		}

		public static void mostrarClientes() {

			Console.Clear();
			Console.WriteLine("LISTA DE CLIENTES");
			Console.WriteLine("");

			for (int i = 0; i < Program.clientes.Count; i++) {
				var data = Program.clientes[i].nascimento;
				Console.WriteLine("Nome: " + Program.clientes[i].nome +
					", Endereço: " + Program.clientes[i].endereco +
					", Telefone: " + Program.clientes[i].telefone +
					", Referência: " + Program.clientes[i].referencia +
					", D. Nascimento: " + data.Day + "/" + data.Month + "/" + data.Year
				);
			}

			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public static void cadastrarCliente() {

			Console.Clear();
			Console.WriteLine("CONSULTA / EDIÇÃO / CADASTRO DE PRODUTO");
			Console.WriteLine("");

			Console.Write("Digite o telefone do cliente: ");
			int telefone = int.Parse(Console.ReadLine());

			int pos = Program.clientes.FindIndex(x => x.telefone == telefone);
			if (pos != -1) {
				Console.WriteLine("");
				Console.WriteLine("Cliente já cadastrado:");
				Console.WriteLine("");
				Console.WriteLine(Program.clientes[pos]);
				Console.WriteLine("");
				Console.Write("Deseja editar nome do cliente? (S/N) ");
				var R = Console.ReadKey();

				if (R.Key == ConsoleKey.S) {
					editarCliente(pos);
				}
				else {
					Console.Write("Pressione qualquer tecla para voltar ao menu...");
					Console.ReadKey();
				}

			}
			else {

				Console.WriteLine("");
				Console.WriteLine("Cliente ainda não cadastrado!");
				Console.WriteLine("");
				Console.WriteLine("Digite o restante dos dados do Cliente");
				Console.WriteLine("");

				Console.Write("Nome: ");
				string nome = Console.ReadLine();

				Console.Write("Endereço: ");
				string endereco = Console.ReadLine();

				Console.Write("Referência: ");
				string referencia = Console.ReadLine();

				Console.Write("Dia de Nascimento: ");
				int dia = int.Parse(Console.ReadLine());
				Console.Write("Mês de Nascimento: ");
				int mes = int.Parse(Console.ReadLine());
				Console.Write("Ano de Nascimento: ");
				int ano = int.Parse(Console.ReadLine());

				Cliente C = new Cliente(nome, telefone, endereco, referencia, dia, mes, ano);
				Program.clientes.Add(C);

				Console.WriteLine("");
				Console.WriteLine("Cliente cadastrado com sucesso!");
				Console.WriteLine("");
				Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
				Console.ReadKey();

			}

		}

		public static void editarCliente(int pos) {

			Console.WriteLine("");
			Console.Write("Digite o novo nome para o cliente: ");
			string nome = Console.ReadLine();
			Console.WriteLine("");

			Program.clientes[pos].nome = nome;

			Console.Clear();
			Console.WriteLine("Cliente cadastrado com sucesso!");
			Console.WriteLine("");
			Console.WriteLine(Program.clientes[pos]);

			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public override string ToString() {

			return "Nome: " + nome + "\n"
				+ "Telefone: " + telefone + "\n"
				+ "Endereço: " + endereco + "\n"
				+ "Ponto de Referência: " + referencia + "\n"
				+ "Data de Nascimento: " + nascimento.Day + "/" + nascimento.Month + "/" + nascimento.Year;

		}

	}
}
