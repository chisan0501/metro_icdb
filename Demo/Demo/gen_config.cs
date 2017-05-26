using Demo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Demo { 
    public class gen_config
    {
        
        public static string gen_file(string server_address, string user_name, string password, string db_name) {
            db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();
            string value = (from t in db.scripts where t.name == "discovery_config" select t.content).FirstOrDefault();

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "configuration";
            xRoot.IsNullable = true;

            

            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("<appSettings>");
            sb.AppendLine("<add key='OnlineMySqlConnectionString' value='Server = MYSQL5013.Smarterasp.net; Database = db_a094d4_demo; Uid = a094d4_demo; Pwd = icdb123!; persist security info = True; '/>");
            sb.AppendLine("<add key='LocalMySqlConnectionString' value='Server = "+server_address+"; user id = "+user_name+"; password = "+password+"; database = "+db_name+"; persist security info = True; '/>");
            sb.AppendLine("</appSettings>");
            sb.AppendLine("</configuration>");


            value = sb.ToString();

            return value;
        }

    }
}