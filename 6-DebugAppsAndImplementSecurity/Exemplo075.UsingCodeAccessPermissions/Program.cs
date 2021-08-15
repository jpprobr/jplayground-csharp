using System;
using System.Security;
using System.Security.Permissions;

namespace Exemplo075.UsingCodeAccessPermissions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // Exemplo na forma declarativa, de usar atributos p/ aplicar informações 
        // de segurança p/ código. 
        // Atributo solicita permissão p/ ler todos os arquivos locais
        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public void DeclarativeCAS()
        {
            // Method body
        }

        // Exemplo na forma imperativa (dentro do método)
        // Cria nova instancia de FileIOPermission e solicita permissões
        public void SomeMethod()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            
            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }
    }
}
