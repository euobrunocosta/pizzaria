using System;
using System.Globalization;

namespace pizzaria.domain {
	
	public class Produto {

		public int id { get; set; }
		public string nome { get; set; }
		public string descricao { get; set; }
		public char tamanho { get; set; }
		public double preco { get; set; }
		
		public Produto(int id, string nome, string descricao, char tamanho, double preco) {
			this.id = id;
			this.nome = nome;
			this.descricao = descricao;
			this.tamanho = tamanho;
			this.preco = preco;
		}

		public static void mostrarProdutos() {

			Console.Clear();
			Console.WriteLine("LISTA DE PRODUTOS");
			Console.WriteLine("");

			for (int i = 0; i < Program.produtos.Count; i++) {
				Console.WriteLine(Program.produtos[i].id +
					", Nome: " + Program.produtos[i].nome +
					", Descrição: " + Program.produtos[i].descricao +
					", Tamanho: " + Program.produtos[i].tamanho +
					", Preço: R$ " + Program.produtos[i].preco.ToString("F2", CultureInfo.InvariantCulture)
				);
			}

			Console.WriteLine("");
			Console.Write("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public static void cadastrarProduto() {
			
			Console.Clear();
			Console.WriteLine("CADASTRO DE PRODUTO");
			Console.WriteLine("");

			Console.WriteLine("Digite os dados do produto");
			Console.WriteLine("");

			Console.Write("ID: ");
			int id = int.Parse(Console.ReadLine());

			Console.Write("Nome: ");
			string nome = Console.ReadLine();

			Console.Write("Descrição: ");
			string descricao = Console.ReadLine();

			Console.Write("Tamanho (P, M ou G): ");
			char tamanho = char.Parse(Console.ReadLine());

			Console.Write("Preço: R$ ");
			double preco = double.Parse(Console.ReadLine());

			Produto P = new Produto(id, nome, descricao, tamanho, preco);
			Program.produtos.Add(P);

			Console.WriteLine("");
			Console.WriteLine("Produto cadastrado com sucesso!");
			Console.WriteLine("");
			Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();

		}

		public override string ToString() {

			return "Nome: " + nome + "\n"
				+ "Descrição: " + descricao + "\n"
				+ "Tamanho: " + tamanho + "\n"
				+ "Preço: R$ " + preco.ToString("F2", CultureInfo.InvariantCulture);

		}

	}

}
