using Lojista.Controllers;
using Lojista.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestLojista.Model;

namespace UnitTestLojista.Controller
{
    [TestClass]
    public class OrcamentoControllerTest
    {
        public AtacadistaMoqRepository _atacadistaRepository;
        public LojistaMoqRepository _lojistaRepository;
        public OrcamentoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _atacadistaRepository = new AtacadistaMoqRepository();
            _lojistaRepository = new LojistaMoqRepository();
            _controller = new OrcamentoController(_atacadistaRepository, _lojistaRepository);

            _lojistaRepository.GravarPedido(new Pedido() { Id = 1 });
            _lojistaRepository.GravarPedido(new Pedido() { Id = 2, Orcamento = new Orcamento() { Id = 1, IdPedido = 2 } });
        }

        /// <summary>
        /// Teste item 5
        /// </summary>
        [TestMethod]
        public void ReceberOrcamento()
        {
            Assert.IsNull(_lojistaRepository.BuscarPedido(1).Orcamento);

            var orcamentoPedido1 = new Orcamento() { Id = 2, IdPedido = 1, PrevisaoEntrega = DateTime.Today, Valor = 10 };
            _controller.Put(1, orcamentoPedido1);

            var orcamentoLogista = _lojistaRepository.BuscarPedido(1).Orcamento;
            Assert.IsNotNull(orcamentoLogista);
            Assert.AreEqual(orcamentoPedido1.Id, orcamentoLogista.Id);
            Assert.AreEqual(orcamentoPedido1.IdPedido, orcamentoLogista.IdPedido);
            Assert.AreEqual(orcamentoPedido1.PrevisaoEntrega, orcamentoLogista.PrevisaoEntrega);
            Assert.AreEqual(orcamentoPedido1.Valor, orcamentoLogista.Valor);
        }

        /// <summary>
        /// Teste item 5
        /// </summary>
        [TestMethod]
        public void AceitarOrcamento()
        {
            Assert.AreEqual(0, _atacadistaRepository.OrcamentoAceito);

            _controller.PatchAceitar(2);

            Assert.AreEqual(2, _atacadistaRepository.OrcamentoAceito);
        }

        /// <summary>
        /// Teste item 5
        /// </summary>
        [TestMethod]
        public void RejeitarOrcamento()
        {
            Assert.AreEqual(0, _atacadistaRepository.OrcamentoRejeitado);

            _controller.PatchRejeitar(2);

            Assert.AreEqual(2, _atacadistaRepository.OrcamentoRejeitado);
        }
    }
}