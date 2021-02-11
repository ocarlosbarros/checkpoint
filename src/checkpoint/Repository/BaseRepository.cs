using System;
using System.IO;

namespace pontoDigital.Repository
{
    public abstract class BaseRepository
    {
        protected string[] ObterRegistrosCSV(string PATH)
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
                        
            return File.ReadAllLines(PATH);
        }
        protected string ExtrairCampo(string nomeCampo, string linha)
        {
            var valor = "";
            
            if(linha != "")
            {
                var chave = nomeCampo;
                var indiceInical = linha.IndexOf(chave);
                var indiceFinal = linha.IndexOf(";", indiceInical);

                if(indiceFinal != -1)
                {
                    valor = linha.Substring(indiceInical, indiceFinal - indiceInical);
                }else
                    {
                        valor = linha.Substring(indiceInical);
                    }

                Console.WriteLine($"Campo[{nomeCampo}] e valor {valor}");

                }
            return valor.Replace(nomeCampo + "=", "");
        }   
    }   
}