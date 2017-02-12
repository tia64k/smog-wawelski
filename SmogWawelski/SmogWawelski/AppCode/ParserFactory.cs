using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmogWawelski.Parsers;

namespace SmogWawelski.AppCode
{
    public enum Apis
    {
        PowietrzeMalopolskaPl
    }

    public class ParserFactory
    {
        public IApiParser CreateParser(Apis api)
        {
            IApiParser parser;

            switch (api)
            {
                case Apis.PowietrzeMalopolskaPl:
                    parser = new PowietrzeMalopolskaParser();
                    break;
                default:
                    parser = null;
                    break;
            }
            return parser;
        }
    }
}
