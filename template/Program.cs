using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swed32;


namespace template
{
    internal class Program
    {
        static void Main(string[] args)
        {

            swed swed = new swed();

            swed.GetProcess("csgo");

            // how to get module base address 

            var client = swed.GetModuleBase("client.dll");
            var engine = swed.GetModuleBase("engine.dll");

            // get player health 

            int dwLocalPlayer = 0xDB65EC;
            int m_iHealth = 0x100;

            var buffer = swed.ReadPointer(client, dwLocalPlayer);
           

            while (true)
            {
                var hp = BitConverter.ToInt32(swed.ReadBytes(buffer, m_iHealth, 4), 0);

                Console.WriteLine("Player health ---> " + hp);

            }
            


        }
    }
}
