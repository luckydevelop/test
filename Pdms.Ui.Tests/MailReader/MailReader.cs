using System;
using System.Net;
using System.Xml;

namespace Kliiko.Ui.Tests.MailReader
{
    public class MailReader
    {
       
        public static int GmailUnreadCount(string username, string password)
        {
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = new NetworkCredential(username, password);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = resolver;
            try
            {
                XmlReader reader = XmlReader.Create("https://mail.google.com/mail/feed/atom", settings);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "fullcount":
                                    int output;
                                    Int32.TryParse(reader.ReadString(), out output);
                                    return output;
                            }
                            break;
                    }
                }
            }
            catch (Exception a)
            {
                return -1;
            }
            return -1;
        }
    }
}
