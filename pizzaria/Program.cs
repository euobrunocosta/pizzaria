using System;
using System.Collections.Generic;
using pizzaria.domain;

namespace pizzaria {
	
	class Program {

		public static List<Cliente> clientes = new List<Cliente>();
		public static List<Produto> produtos = new List<Produto>();
		public static List<Pedido> pedidos = new List<Pedido>();
		public static List<Entregador> entregadores = new List<Entregador>();
		
		static void Main(string[] args) {

			clientes.Add(new Cliente("José Ninguém", 11112222, "Rua Sem Nome, S/N", "Perto da loja Sem Nome", 1, 1, 1900));
			clientes.Add(new Cliente("Fulano de Tal", 33334444, "Rua da Esquina, S/N", "Perto da loja da Esquina", 2, 2, 1901));

			produtos.Add(new Produto(1001, "Pizza de Calabresa", "massa, molho, mussarela, calabresa, cebola", char.Parse("M"), 45));
			produtos.Add(new Produto(1002, "Pizza Romeu e Julieta", "massa, mussarela, goiabada", char.Parse("P"), 35));

			entregadores.Add(new Entregador("Sicrano de Tal", 11122233344, 1112223, 55556666));
			entregadores.Add(new Entregador("João Ninguém", 55566677788, 55566677, 77778888));

			ConsoleKeyInfo opcao = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);

			while (opcao.Key != ConsoleKey.D0) {
				
				Console.Clear();
				Tela.mostrarMenu();

				opcao = Console.ReadKey();

				switch (opcao.Key) {
					case ConsoleKey.D1:
						Produto.mostrarProdutos();
						break;
					case ConsoleKey.D2:
						Produto.cadastrarProduto();
						break;
					case ConsoleKey.D3:
						Cliente.mostrarClientes();
						break;
					case ConsoleKey.D4:
						Cliente.cadastrarCliente();
						break;
					case ConsoleKey.D5:
						Entregador.mostrarEntregadores();
						break;
					case ConsoleKey.D6:
						Entregador.cadastrarEntregador();
						break;
					case ConsoleKey.D7:
						Pedido.consultarPedido();
						break;
					case ConsoleKey.D8:
						Pedido.cadastrarPedido();
						break;
					case ConsoleKey.D9:
						Pedido.mudaStatusPedido();
						break;
					case ConsoleKey.D0:
						Tela.sair();
						break;
					default:
						Tela.opcaoInvalida();
						break;
				}

			}

		}
	}
}
