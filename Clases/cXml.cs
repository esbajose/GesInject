using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

    class cXml
    {

        public static string fncLeeDato(string vXml, string vNodo, string vClave)
        {
            return fncLeeDato(vXml, vNodo, vClave, "");
        }

        public static string fncLeeDato(string vXml, string vNodo, string vClave, string vDef)
        {
            string vRes = vDef;
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(vXml);

                XmlNode node;
                node = xDoc.DocumentElement;
                XmlNode node1 = node;
                if (node.Name != vNodo) { node1 = fncBuscaNodo(node, vNodo); }
                foreach (XmlNode node2 in node1.ChildNodes)
                {
                    if (node2.Name == vClave)
                    {
                        vRes = node2.InnerText;
                        return vRes;
                    }
                }

            }
            catch
            {
                vRes = vDef;
            }
            return vRes;
        }



        public static string fncGuardaDato(string vXml, string vNodo, string vClave, string vDato)
        {
            string vRes = "";
            try
            {
                XmlDocument xDoc = new XmlDocument();
                if (!File.Exists(vXml))
                {
                    XmlTextWriter xmlText = fncGrabaIni(vXml, "", vNodo);
                    fncGrabaEnd(xmlText);
                }

                xDoc.Load(vXml);

                XmlNode nodeRaiz;
                nodeRaiz = xDoc.DocumentElement;
                XmlNode node1 = fncBuscaNodo(nodeRaiz, vNodo);
                if (node1 != null)
                {
                    bool vEncontrado = false;
                    foreach (XmlNode node2 in node1.ChildNodes)
                    {
                        if (node2.Name == vClave)
                        {
                            node2.InnerText = vDato;
                            xDoc.Save(vXml);
                            vEncontrado = true;
                        }
                    }
                    if (!vEncontrado)
                    {
                        XmlElement elem2 = xDoc.CreateElement(vClave);
                        elem2.InnerText = vDato;
                        node1.AppendChild(elem2);
                        xDoc.Save(vXml);
                    }
                }
                else
                {
                    XmlElement elem = xDoc.CreateElement(vNodo);
                    nodeRaiz.AppendChild(elem);

                    node1 = fncBuscaNodo(nodeRaiz, vNodo);
                    XmlElement elem2 = xDoc.CreateElement(vClave);
                    elem2.InnerText = vDato;
                    node1.AppendChild(elem2);

                    xDoc.Save(vXml);
                }
            }
            catch (Exception ex)
            {
                string vError = ex.Message;
                vRes = "";
            }
            return vRes;
        }

        public static XmlNode fncBuscaNodo(XmlNode nodo, string vNodo)
        {
            XmlNode vRes = null;
            if (nodo.Name == vNodo) { vRes = nodo; return vRes; }
            foreach (XmlNode nodo1 in nodo.ChildNodes)
            {
                if (nodo1.Name == vNodo)
                {
                    vRes = nodo1;
                    return vRes;
                }
            }

            return vRes;
        }

        public static XmlTextWriter fncGrabaIni(string vFich, string vComment, string vNodoIni)
        {

            XmlTextWriter textWriter = new XmlTextWriter(vFich, null);
            textWriter.WriteStartDocument();
            textWriter.WriteComment(vComment);
            textWriter.WriteStartElement(vNodoIni);


            return textWriter;
        }
        public static bool fncGrabaValor(XmlTextWriter textWriter, string vClave, string vValor)
        {
            textWriter.WriteStartElement(vClave, "");
            textWriter.WriteString(vValor);
            textWriter.WriteEndElement();
            return true;

        }

        public static bool fncGrabaEnd(XmlTextWriter textWriter)
        {
            try
            {
                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch
            {
                return false;

            }
            return true;
        }

    }