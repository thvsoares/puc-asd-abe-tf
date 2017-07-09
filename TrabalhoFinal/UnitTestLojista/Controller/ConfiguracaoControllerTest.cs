using Lojista.Controllers;
using Lojista.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestLojista.Model;

namespace UnitTestLojista.Controller
{
    [TestClass]
    public class ConfiguracaoControllerTest
    {
        public AtacadistaMoqRepository _atacadistaRepository;
        public ConfiguracaoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _atacadistaRepository = new AtacadistaMoqRepository();
            _controller = new ConfiguracaoController(_atacadistaRepository);
        }

        [TestMethod]
        public void ConfiguracaoCaminhoAtacadista()
        {
            _atacadistaRepository.UrlAtacadista = "";

            _controller.Put("UrlAtacadista", "http://valor.camel.case:8080");
            Assert.AreEqual("http://valor.camel.case:8080", _atacadistaRepository.UrlAtacadista);

            _controller.Put("urlatacadista", "http://valor.minusculo");
            Assert.AreEqual("http://valor.minusculo", _atacadistaRepository.UrlAtacadista);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ChaveInvalidaLojista()
        {
            _controller.Put("ChaveInvalidaLojista", "teste");
        }
    }
}