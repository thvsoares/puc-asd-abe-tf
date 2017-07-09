using Atacadista.Controllers;
using Atacadista.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestAtacadista.Model;

namespace UnitTestAtacadista.Controller
{
    [TestClass]
    public class ConfiguracaoControllerTest
    {
        public LojistaMoqRepository _lojistaRepository;
        public ConfiguracaoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _lojistaRepository = new LojistaMoqRepository();
            _controller = new ConfiguracaoController(_lojistaRepository);
        }

        [TestMethod]
        public void ConfiguracaoCaminhoLojista()
        {
            _lojistaRepository.UrlLojista = "";

            _controller.Put(new KeyValuePair<string, string>("UrlLojista", "http://valor.camel.case:8080"));
            Assert.AreEqual("http://valor.camel.case:8080", _lojistaRepository.UrlLojista);

            _controller.Put(new KeyValuePair<string, string>("urllojista", "http://valor.minusculo"));
            Assert.AreEqual("http://valor.minusculo", _lojistaRepository.UrlLojista);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ChaveInvalidaAtacadista()
        {
            _controller.Put(new KeyValuePair<string, string>("ChaveInvalida", "teste"));
        }
    }
}