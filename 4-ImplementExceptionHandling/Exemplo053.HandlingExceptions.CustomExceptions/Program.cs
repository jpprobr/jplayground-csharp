using System;
using System.Runtime.Serialization;

namespace Exemplo053.HandlingExceptions.CustomExceptions
{
    /// <summary>
    /// Exemplo de exceção customizada
    /// Note que é importante usar o atributo Serializable p/ garantir que 
    /// as exceções possam ser serializadas e funcionem corretamente 
    /// em domínios de aplicativo (ex.: web service)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExcecutarExemplo1();
            }
            catch (OrderProcessingException e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);
                Console.WriteLine("InnerException: {0}", e.InnerException);
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Source: {0}", e.Source);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        static void ExcecutarExemplo1()
        {
            try
            {
                Console.WriteLine("Executa alguma operação");

                // P/ forçar lançamento de exceção
                throw new Exception();
            }
            catch (Exception exc)
            {
                throw new OrderProcessingException(123, "Mensagem da exceção customizada", exc);
            }
        }
    }

   


    [Serializable]
    public class OrderProcessingException : Exception, ISerializable
    {
        public OrderProcessingException(int orderId)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }
        
        public OrderProcessingException(int orderId, string message)
            : base(message)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }
        
        public OrderProcessingException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }
        
        protected OrderProcessingException(SerializationInfo info, StreamingContext context)
        {
            OrderId = (int)info.GetValue("OrderId", typeof(int));
        }


        public int OrderId { get; private set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }
    }
}
