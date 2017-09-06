using System;
using System.Collections.Generic;
using System.Globalization;

namespace pizzaria.domain {
	
	public class Pedido {

		public int id { get; set; }
		public DateTime data { get; set; }
		public Cliente cliente { get; set; }
		public Entregador entregador { get; set; }
		public char status { get; set; }
		public List<ItemPedido> itens { get; set; }
		public bool troco { get; set; }
		public double trocoPara { get; set; }

		public Pedido(int id, int dia, int mes, int ano, Cliente cliente, Entregador entregador, char status, bool troco, double trocoPara) {
			this.id = id;
			data = new DateTime(ano, mes, dia);
			this.cliente = cliente;
			this.entregador = entregador;
			this.status = status;
			itens = new List<ItemPedido>();
			this.troco = troco;
			this.trocoPara = trocoPara;
		}

		public double valorTotal() {
			double soma = 5;
			for (int i = 0; i < itens.Count; i++) {
				soma = soma + itens[i].subTotal();
			}
			return soma;
		}

		public static void mudaStatusPedido() {

			Console.Clear();
			Console.WriteLine("MUDAR STATUS DE PEDIDO");
			Console.WriteLine("");

			Console.Write("ID: ");
			int id = int.Parse(Console.ReadLine());

			Console.WriteLine("");
			Console.WriteLine("Escolha o novo status do peido:");
			Console.Write("1 - Pendente\n2 - Em trânsito\n3- Cancelado\n4- Entregue");
			Console.WriteLine("");
			ConsoleKeyInfo opcao = new ConsoleKeyInfo();
			opcao = Console.ReadKey();

			char status;
			switch (opcao.Key) {
				case ConsoleKey.D1:
					status = char.Parse("P");
					break;
				case ConsoleKey.D2:
					status = char.Parse("T");
					break;
				case ConsoleKey.D3:
					status = char.Parse("C");
					break;
				case ConsoleKey.D4:
					status = char.Parse("E");
					break;
				default:
					status = char.Parse("I");
					break;
			}

			int pos = Program.pedidos.FindIndex(x => x.id == id);

			Program.pedidos[pos].status = status;

			Console.WriteLine("");
			Console.Write("Status modificado com sucesso!");
			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public static void cadastrarPedido() {

			Console.Clear();
			Console.WriteLine("CADASTRO DE PEDIDO");
			Console.WriteLine("");
			Console.WriteLine("Digite os dados do pedido");
			Console.WriteLine("");

			Console.Write("Código: ");
			int codigo = int.Parse(Console.ReadLine());

			Console.Write("Dia: ");
			int dia = int.Parse(Console.ReadLine());

			Console.Write("Mês: ");
			int mes = int.Parse(Console.ReadLine());

			Console.Write("Ano: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Telefone do Cliente: ");
			int codCliente = int.Parse(Console.ReadLine());
			int posCliente = Program.clientes.FindIndex(x => x.telefone == codCliente);
			Console.WriteLine("Cliente escolhido: " + Program.clientes[posCliente].nome);

			Console.Write("CPF do Entregador: ");
			long codEntregador = long.Parse(Console.ReadLine());
			int posEntregador = Program.entregadores.FindIndex(x => x.cpf == codEntregador);
			Console.WriteLine("Entregador escolhido: " + Program.entregadores[posEntregador].nome);

			Console.Write("Precisa de troco (S/N)? ");
			ConsoleKeyInfo trocoOpcao = new ConsoleKeyInfo();
			trocoOpcao = Console.ReadKey();

			bool troco = false;
			double trocoPara = 0;
			if (trocoOpcao.Key == ConsoleKey.S) {
				troco = true;
				Console.WriteLine();
				Console.Write("Troco para quanto? ");
				trocoPara = double.Parse(Console.ReadLine());
			}

			char status = char.Parse("P");

			Pedido P = new Pedido(codigo, dia, mes, ano, Program.clientes[posCliente], Program.entregadores[posEntregador], status, troco, trocoPara);

			Console.WriteLine("");
			Console.Write("Quantos itens tem o pedido? ");
			int N = int.Parse(Console.ReadLine());

			for (int i = 1; i <= N; i++) {
				Console.WriteLine("");
				Console.WriteLine("Digite os dados do " + i + "º item:");
				Console.WriteLine("");
				Console.Write("Produto (ID): ");
				int codProduto = int.Parse(Console.ReadLine());

				int pos = Program.produtos.FindIndex(x => x.id == codProduto);

				Console.Write("Quantidade: ");
				int pedidosQtd = int.Parse(Console.ReadLine());

				ItemPedido ip = new ItemPedido(pedidosQtd, P, Program.produtos[pos]);

				P.itens.Add(ip);
			}

			Program.pedidos.Add(P);

			Console.WriteLine("");
			Console.Write("Pedido cadastrado com sucesso!");
			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public static void consultarPedido() {

			Console.Clear();
			Console.WriteLine("CONSULTA DE PEDIDO");
			Console.WriteLine("");

			Console.Write("Código do Pedido: ");
			int codigo = int.Parse(Console.ReadLine());

			int pos = Program.pedidos.FindIndex(x => x.id == codigo);
			Console.WriteLine("");
			Console.WriteLine(Program.pedidos[pos]);
			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public string statusHelper() {
			
			switch (status.ToString()) {
				case "P":
					return "Pendente";
				case "T":
					return "Em trânsito";
				case "C":
					return "Cancelado";
				case "E":
					return "Entregue";
				default:
					return "Indeterminado";
			}

		}

		public override string ToString() {

			string s = "Pedido: " + id
				+ ", Data:" + data.Day + "/" + data.Month + "/" + data.Year
				+ ", Satus: " + statusHelper() + "\n\n"
				+ "Cliente: " + cliente.nome + "\n"
				+ "Endereço: " + cliente.endereco  + "\n"
				+ "Referência: " + cliente.referencia + "\n\n"
				+ "Entregador: " + entregador.nome + "\n\n";
			if (troco) {
				s += "Troco para R$ " + trocoPara.ToString("F2", CultureInfo.InvariantCulture) + "\n\n";
			}
			s += "Itens:\n\n";

			for (int i = 0; i < itens.Count; i++) {
				s += itens[i] + "\n\n";
			}

			s += "Taxa de entrega: R$ 5.00\n"
				+ "Total do pedido: R$ " + valorTotal().ToString("F2", CultureInfo.InvariantCulture);

			return s;

		}

	}

}
