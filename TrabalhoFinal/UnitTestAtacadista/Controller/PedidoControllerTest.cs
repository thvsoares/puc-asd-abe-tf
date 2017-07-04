using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestAtacadista.Model;
using Atacadista.Controllers;
using Atacadista.Model;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestAtacadista.Controller
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
            _controller = new PedidoController(_atacadistaRepository);
        }

        /// <summary>
        /// Realiza o teste do item 3
        /// </summary>
        [TestMethod]
        public void ReceberPedido()
        {
            var novoPedido = new Pedido()
            {
                Itens = new List<PedidoItem>()
                {
                    new PedidoItem() { IdProduto = 2, Quantidade = 8 }
                }
            };

            Assert.AreEqual(0, novoPedido.Id);
            Assert.AreEqual(0, _atacadistaRepository.BuscarPedidos().Count);

            var idPedido = _controller.Post(novoPedido);

            Assert.AreEqual(1, idPedido);
            Assert.AreEqual(1, _atacadistaRepository.BuscarPedidos().Count);
        }
    }
}
