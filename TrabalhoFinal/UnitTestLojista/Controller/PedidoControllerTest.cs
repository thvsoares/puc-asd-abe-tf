using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLojista.Model;
using Lojista.Controllers;
using Lojista.Model;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestLojista.Controller
{
    [TestClass]
    public class PedidoControllerTest
    {
        public AtacadistaMoqRepository _atacadistaRepository;
        public LojistaMoqRepository _lojistaRepository;
        public PedidoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _atacadistaRepository = new AtacadistaMoqRepository();
            _lojistaRepository = new LojistaMoqRepository();
            _controller = new PedidoController(_atacadistaRepository, _lojistaRepository);

            _lojistaRepository.GravarProduto(new Produto() { Id = 1, Nome = "Produto1" });
            _lojistaRepository.GravarProduto(new Produto() { Id = 2, Nome = "Produto2" });
            _lojistaRepository.GravarEstoque(new Estoque() { Quantidade = 10, Produto = _lojistaRepository.BuscarProdutos().Single(s => s.Id == 1) });
            _lojistaRepository.GravarEstoque(new Estoque() { Quantidade = 02, Produto = _lojistaRepository.BuscarProdutos().Single(s => s.Id == 2) });
        }

        /// <summary>
        /// Realiza o teste do item 2
        /// </summary>
        [TestMethod]
        public void RealizarPeido()
        {
            var novoPeido = new Pedido()
            {
                Itens = new List<PedidoItem>()
                {
                    new PedidoItem() { IdProduto = 2, Quantidade = 8 }
                }
            };

            Assert.AreEqual(0, novoPeido.Id);
            Assert.AreEqual(0, _lojistaRepository.BuscarPedidos().Count);
            Assert.AreEqual(1, _atacadistaRepository.IdPedido);

            var idPedido = _controller.Post(novoPeido);

            Assert.AreEqual(1, idPedido);
            Assert.AreEqual(1, _lojistaRepository.BuscarPedidos().Count);
            Assert.AreEqual(2, _atacadistaRepository.IdPedido);
        }
    }
}
