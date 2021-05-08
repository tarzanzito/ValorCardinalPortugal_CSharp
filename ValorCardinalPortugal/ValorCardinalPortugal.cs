using System;
using System.Collections.Generic;

//números cardinais
// https://www.figuradelinguagem.com/gramatica/numeros-ordinais/
// https://ciberduvidas.iscte-iul.pt/consultorio/perguntas/biliao-triliao-quatriliao/2468


namespace Candal
{
    //
    //Codigo escrito totalmente em Portuguès porque apenas faz sentido para Portugueses (Portugal)
    //
    public class ValorCardinalPortugal
    {
        #region constantes

        private static readonly string[] CARDINAL_UNIDADES = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
        private static readonly string[] CARDINAL_DEZENAS = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        private static readonly string[] CARDINAL_DEZENAS_DEZ = { "dez", "onze", "doze", "treze", "catorze", "quinze", "desasseis", "desassete", "dezoito", "dezanove" };
        private static readonly string[] CARDINAL_CENTENAS = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        private static readonly string CARDINAL_ZERO = "zero"; 
        private static readonly string CARDINAL_UM = "um";
        private static readonly string CARDINAL_UMA = "uma";
        private static readonly string CARDINAL_DOIS = "dois";
        private static readonly string CARDINAL_DUAS = "duas";
        private static readonly string CARDINAL_CEM = "cem";

        private static readonly string[] CARDINAL_GRUPOS_PLURAL = { "", "mil", "milhões", "milhares de milhão", "biliões", "dezenas de bilião", "centenas de bilião",
            "milhares de bilião", "dezenas de milhar de bilião", "centenas de milhar de bilião", "triliões"};

        private static readonly string[] CARDINAL_GRUPOS_SINGULAR = { "", "mil", "milhão", "milhar de milhão", "bilião", "dezena de bilião", "centena de bilião",
            "milhar de bilião", "dezena de milhar de bilião", "centena de milhar de bilião", "trilião"};

        private static readonly bool[] CARDINAL_GRUPOS_MASCULINO = { true, true, true, true, true, false, false, true, false, false, true};

        private static readonly string FRASE_SUFIXO_AO = "ão";
        private static readonly string FRASE_SUFIXO_OES = "ões";

        private static readonly string FRASE_E = " e ";
        private static readonly string FRASE_VIRGULA = ", ";
        private static readonly string FRASE_DE = " de";
        private static readonly string FRASE_NOME_INTEIROS_PLURAL = "euros";
        private static readonly string FRASE_NOME_INTEIROS_SINGULAR = "euro";
        private static readonly string FRASE_NOME_DECIMAIS_PLURAL = "centimos";
        private static readonly string FRASE_NOME_DECIMAIS_SINGULAR = "centimo";
        private static readonly string FRASE_MENOS = "menos ";

        //decimal max int: 79228162514264337593543950335;
        //decimal max dec:    99999999999999999999999999.99;
        //                 12345678901234567890123456789.99  

        #endregion

        #region public methods

        public string Converte(decimal valor, bool vazioSeZeroParteinteira = false, bool vazioSeZeroParteDecimal = false)
        {
            string temp = valor.ToString();
            return Converte(temp, vazioSeZeroParteinteira, vazioSeZeroParteDecimal);
        }

        public string Converte(string valor, bool vazioSeZeroParteinteira = false, bool vazioSeZeroParteDecimail = false)
        {
            string valorTrim = valor.Trim();

            // validação e formatação do impute
            if (!ValidaValor(valorTrim))
                return "ERRO: não é um valor valido: " + valor;

            string valorForm = FormataValor(valorTrim);

            // inicio
            bool negativo = ValorNegativo(valorForm);

            string valorInicial;
            if (negativo)
                valorInicial = valorForm.Substring(1);
            else
                valorInicial = valorForm;

            //processa

            // separa parte inteira pare decimal
            string[] partes = DivideEmPartesInteiraDecimal(valorInicial);

            //separa por grupos de mil "???"
            string[] gruposInteiros = DivideEmGruposDeMil(partes[0]);
            string[] gruposDecimais = DivideEmGruposDeMil(partes[1]);

            //descodifica os grupos inteiros
            string[] gruposCardinaisInteiros = new string[gruposInteiros.Length];
            for (int x = 0; x < gruposInteiros.Length; x++)
                gruposCardinaisInteiros[x] = DescodificaCardinal(gruposInteiros[x], (gruposInteiros.Length - x - 1));

            //descodifica os groupos decimais
            string[] gruposCardinaisDecimais = new string[gruposDecimais.Length];
            for (int x = 0; x < gruposDecimais.Length; x++)
                gruposCardinaisDecimais[x] = DescodificaCardinal(gruposDecimais[x], (gruposDecimais.Length - x - 1));

            //junta todos os grupos
            string finalInteiros = JuntaTodosGruposDeMil(gruposCardinaisInteiros, vazioSeZeroParteinteira);
            string finalDecimais = JuntaTodosGruposDeMil(gruposCardinaisDecimais, vazioSeZeroParteDecimail);

            //caso: se valor = 0.0 mostra sempre "zero"
            if ((finalInteiros.Length == 0) && (finalDecimais.Length == 0))
                finalInteiros = CARDINAL_ZERO + " " + FRASE_NOME_INTEIROS_PLURAL;

            //caso: analiza se coloca "de" antes do qualificador
            if (finalInteiros.Length > 2)
            {
                string temp = finalInteiros.Substring((finalInteiros.Length - 3), 3);
                if (temp == FRASE_SUFIXO_OES)
                    finalInteiros += FRASE_DE;
                else
                {
                    temp = finalInteiros.Substring((finalInteiros.Length - 2), 2);
                    if (temp == FRASE_SUFIXO_AO)
                        finalInteiros += FRASE_DE;
                }
            }

            //obtem qualificadores
            string qualificadorInteiros = ObtemQualificadorParteInteira(partes[0], vazioSeZeroParteinteira);
            string qualificadoreDecimais = ObtemQualificadorParteDecimal(partes[1], vazioSeZeroParteDecimail);

            //adiciona qualificador inteiros
            if (finalInteiros.Length > 0)
                finalInteiros += " " + qualificadorInteiros;

            //adiciona qualificador decimais
            if (finalDecimais.Length > 0)
                finalDecimais += " " + qualificadoreDecimais;

            //caso: adiciona " e " entre a frase inteiros & frase decimais
            string dual = "";
            if ((finalInteiros.Length > 0) && (finalDecimais.Length > 0))
                dual = FRASE_E;

            string resultdofinal = finalInteiros + dual + finalDecimais;
            if (negativo)
                resultdofinal = FRASE_MENOS + resultdofinal;

            return resultdofinal;
        }

        #endregion

        #region private methods

        private string[] DivideEmPartesInteiraDecimal(string valor)
        {
            string[] partes = valor.Split('.');

            return partes;
        }

        private string[] DivideEmGruposDeMil(string valor)
        {
            //extrai
            List<string> list = new List<string>();
            while (valor.Length > 3)
            {
                string str3 = valor.Substring(valor.Length - 3); //3 ultimos
                list.Add(str3);
                valor = valor.Substring(0, valor.Length - 3);
            }
            list.Add(valor.PadLeft(3, '0')); //garante comprimento = 3

            //reverte array
            int count = list.Count;
            string[] groupos = new string[count];
            for (int x = 0; x < count; x++)
                groupos[count - 1 - x] = list[x];

            return groupos;
        }

         private string JuntaTodosGruposDeMil(string[] grouposEmCardinal, bool vazioSeZero)
        {
            string resultado = "";
            int pos;

            for (int x = 0; x < grouposEmCardinal.Length; x++)
            {
                if (grouposEmCardinal[x].Length == 0)
                    continue;

                // no ultimo elemento analisa se coloca  " e " no fim
                if ((x == (grouposEmCardinal.Length - 1)) && (resultado.Length > 1))
                {
                    pos = grouposEmCardinal[x].IndexOf(FRASE_E);
                    if (pos == -1)
                    {
                        resultado = RemoveUltimasVirgulasEmExcesso(resultado);
                        resultado += FRASE_E;
                    }
                }

                resultado += grouposEmCardinal[x];
                resultado += FRASE_VIRGULA;
            }

            if ((resultado.Length == 0) && (!vazioSeZero))
                resultado = CARDINAL_ZERO;

            resultado = RemoveUltimasVirgulasEmExcesso(resultado);

            //caso: quantos " e " existem depois da ultima virgula? se zero substitui ultima ", " por " e " 
            pos = resultado.LastIndexOf(FRASE_VIRGULA);
            if (pos > 0)
            {
                string temp1 = resultado.Substring(0, pos);
                string temp2 = resultado.Substring(pos + FRASE_VIRGULA.Length);
                pos = temp2.IndexOf(FRASE_E);
                if (pos == -1)
                    resultado = temp1 + FRASE_E + temp2;
            }        

            return resultado;
        }

        private string RemoveUltimasVirgulasEmExcesso(string valor)
        {
            if (valor.Length < 2)
                return valor;

            string resultado = valor;

            while (resultado.Substring(resultado.Length - 2, 2) == FRASE_VIRGULA)
                resultado = resultado.Substring(0, resultado.Length - 2);

            return resultado;
        }

        private string DescodificaCardinal(string valor, int nivel)
        {
            if (valor == "000")
                return "";

            string[] cardinalArray = new string[3];
            byte[] digitArray = new byte[3];

            for (byte x = 0; x < 3; x++)
                digitArray[x] = System.Convert.ToByte(valor.Substring(x, 1));

            cardinalArray[0] = ObtemCentenas(digitArray[0], digitArray[1], digitArray[2]);
            cardinalArray[1] = ObtemDezenas(digitArray[1], digitArray[2]);
            cardinalArray[2] = ObtemUnidades(digitArray[2], digitArray[1]);

            String resultado = JuntaCentenasDezenasUnidades(cardinalArray[0], cardinalArray[1], cardinalArray[2]);

            resultado = AdicionaSufixoDeGrupoMil(resultado, nivel);

            return resultado;
        }

        private string JuntaCentenasDezenasUnidades(string centena, string dezena, string unidade)
        {
            String resultado = centena;
            if ((centena.Length > 0) && ((dezena.Length > 0) || (unidade.Length > 0)))
                resultado += FRASE_E;

            resultado += dezena;
            if ((dezena.Length > 0) && (unidade.Length > 0))
                resultado += FRASE_E;

            resultado += unidade;

            return resultado;
        }

        private string ObtemUnidades(byte digito, byte dezena)
        {
            if (dezena == 1)
                return "";

            return CARDINAL_UNIDADES[digito];
        }

        private string ObtemDezenas(byte digito, byte unidade)
        {
            if (digito == 1)
                return CARDINAL_DEZENAS_DEZ[unidade];

            return CARDINAL_DEZENAS[digito];
        }

        private string ObtemCentenas(byte digito, byte dezena, byte unidade)
        {
            if ((digito == 1) && (dezena == 0) && (unidade == 0))
                return CARDINAL_CEM; //Caso : Cem

            return CARDINAL_CENTENAS[digito];
        }

        private string ObtemQualificadorParteDecimal(string valor, bool vazioSeZero)
        {
            double valTemp = System.Convert.ToDouble(valor);

            if (valTemp > 1)
                return FRASE_NOME_DECIMAIS_PLURAL;

            if (valTemp == 1)
                return FRASE_NOME_DECIMAIS_SINGULAR;

            if ((valTemp == 0) && (!vazioSeZero))
                return FRASE_NOME_DECIMAIS_PLURAL;

            return "";
        }

        private string ObtemQualificadorParteInteira(string valor, bool vazioSeZero)
        {
            double valTemp = System.Convert.ToDouble(valor);

            if (valTemp > 1)
                return FRASE_NOME_INTEIROS_PLURAL;

            if (valTemp == 1)
                return FRASE_NOME_INTEIROS_SINGULAR;

            if ((valTemp == 0) && (!vazioSeZero))
                return FRASE_NOME_INTEIROS_PLURAL;

            return "";
        }

        private string AdicionaSufixoDeGrupoMil(string valor, int nivel)
        {
            string resultado = "";

            switch (nivel)
            {
                case 0: // xxx -unidades, dezenas, centenas
                    resultado = valor;
                    break;

                case 1: //xxx.000 - milhares
                    if (valor == CARDINAL_UM)
                        resultado = CARDINAL_GRUPOS_SINGULAR[nivel]; //caso: remove palavra "um" (um mil)
                    else
                        resultado = valor + " " + CARDINAL_GRUPOS_PLURAL[nivel];
                    break;

                default:
                    if (valor == CARDINAL_UM)
                    {
                        if (CARDINAL_GRUPOS_MASCULINO[nivel])
                            resultado = CARDINAL_UM;
                        else
                            resultado = CARDINAL_UMA;

                        resultado += " " + CARDINAL_GRUPOS_SINGULAR[nivel];
                    }
                    else if (valor == CARDINAL_DOIS)
                    {
                        if (CARDINAL_GRUPOS_MASCULINO[nivel])
                            resultado = CARDINAL_DOIS;
                        else
                            resultado = CARDINAL_DUAS;

                        resultado += " " + CARDINAL_GRUPOS_PLURAL[nivel];
                    }
                    else
                        resultado = valor + " " + CARDINAL_GRUPOS_PLURAL[nivel];
                    break;
            }

            return resultado;
        }

        #endregion

        #region private prepare valor

        private bool ValidaValor(string valor)
        {
            if (valor.Length == 0)
                return true;

            char[] array;

            int pontos = 0;
            array = valor.ToCharArray();

            for (int x = 0; x < array.Length; x++)
            {
                char chr = array[x];

                if (chr == '-')
                {
                    if (x > 0)
                        return false;
                    else
                        continue;
                }

                if (chr == '.')
                {
                    pontos++;
                    continue;
                }

                if (chr < 48 || chr > 57)
                    return false;

            }
            if (pontos > 1)
                return false;

            return true;
        }

        private string FormataValor(string valor)
        {
            if (valor.Length == 0)
                return "0.00";

            string result = valor;

            int pos = valor.IndexOf(".");
            if (pos == -1)
                result += ".00";
            else if (pos == 0)
                result = "0" + result;

            pos = result.IndexOf(".");
            int rlen = result.Length - pos;
            if (rlen == 1)
                result += "00";
            else if (rlen == 2)
                result += "0";
            else
                result = result.Substring(0, pos + 3);

            return result.Trim();
        }

        private bool ValorNegativo(string valor)
        {
            return (valor.Substring(0, 1) == "-");
        }

        #endregion
    }
}
