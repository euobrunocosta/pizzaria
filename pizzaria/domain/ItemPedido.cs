using System;
using System.Globalization;

namespace pizzaria.domain {
	
	public class ItemPedido {

		public int quantidade { get; set; }
		public Produto produto { get; set; }
		public Pedido pedido { get; set; }

		public ItemPedido(int quantidade, Pedido pedido, Produto produto) {
			this.quantidade = quantidade;
			this.pedido = pedido;
			this.produto = produto;
		}

		public double subTotal() {
			return quantidade * produto.preco;
		}

		public override string ToString() {
			return produto.nome + "\n"
				+ "Quantidade: " + quantidade + "\n"
				+ "Preço: R$ " + produto.preco.ToString("F2", CultureInfo.InvariantCulture) + "\n"
				+ "Subtotal: R$ " + subTotal().ToString("F2", CultureInfo.InvariantCulture);
		}

	}

}
