using System;
using System.Collections.Generic;

namespace MobileMindWP7Unit.Unit
{

    /// <summary>
    /// Define o comportamento dos testes unitário
    /// </summary>
    public interface ITestBehavior
    {

        /// <summary>
        /// Metodo que executa quando uma metodo de teste inicia
        /// 
        /// </summary>
        void SetUp();

        /// <summary>
        /// Metodo que executa quando uma classe de teste inicia
        /// </summary>
        void SetUpClass();

        /// <summary>
        /// Metodo que executa quando uma metodo de teste finaliza
        /// </summary>
        void TearDown();

        /// <summary>
        /// Metodo que executa quando uma classe de teste finaliza
        /// </summary>
        void TearDownClass();

        /// <summary>
        /// Adiciona uma mensagem no test
        /// </summary>
        /// <param name="message"></param>
        void Say(String message);

        /// <summary>
        /// Limpa mensagens do teste
        /// 
        /// </summary>
        void ClearMessages();

        /// <summary>
        /// Retorna lista de mensagens do teste
        /// </summary>
        /// <returns></returns>
        IList<String> GetMessage();
    }
}
