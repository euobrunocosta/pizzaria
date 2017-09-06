using System;
using pizzaria.domain;

namespace pizzaria {
	
	class Tela {

		public static void mostrarMenu() {
			
			Console.WriteLine("MENU PRINCIPAL");
			Console.WriteLine("");

			Console.WriteLine("PRODUTOS");
			Console.WriteLine("[1] Listar produtos");
			Console.WriteLine("[2] Cadastrar produto");
			Console.WriteLine("");

			Console.WriteLine("CLIENTES");
			Console.WriteLine("[3] Listar clientes");
			Console.WriteLine("[4] Cadastrar cliente");
			Console.WriteLine("");

			Console.WriteLine("ENTREGADORES");
			Console.WriteLine("[5] Listar entregadores");
			Console.WriteLine("[6] Cadastrar entregador");
			Console.WriteLine("");

			Console.WriteLine("PEDIDOS");
			Console.WriteLine("[7] Consultar pedido");
			Console.WriteLine("[8] Cadastrar pedido");
			Console.WriteLine("[9] Mudar status do pedido");
			Console.WriteLine("");

			Console.WriteLine("[0] Sair");
			Console.WriteLine("");

			Console.Write("Digite uma opção: ");

		}

		public static void sair() {
			
			Console.Clear();
			Console.WriteLine("Fim do programa!");
			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para fechar...");
			Console.ReadKey();

		}

		public static void opcaoInvalida() {
			Console.Clear();
			Console.Write("Opção inválida!");
			Console.ReadKey();
		}

	}

}
