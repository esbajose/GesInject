using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Net.Mail;


    public class cEnvioMail
    {
        // Propiedades del mensaje
        private string mStrFrom = "";
        private string mStrTo = "";
        private string mStrCC = "";
        private string mStrBCC = "";
        private string mStrSubject = "";
        private string mStrBody = "";
        private string mStrPathAttach = "";
        private string mStrReplyTo = "";
        private string _Error = "";

        private bool mBoolIsHTML = false;

        string Error
        {
            set { _Error = value; }
            get { return _Error; }
        }

        string From
        {
            set { mStrFrom = value; }
            get { return mStrFrom; }
        }
        string To
        {
            set { mStrTo = value; }
            get { return mStrTo; }
        }
        string ReplyTo
        {
            set { mStrTo = value; }
            get { return mStrTo; }
        }
        string CC
        {
            set { mStrCC = value; }
            get { return mStrCC; }
        }
        string BCC
        {
            set { mStrBCC = value; }
            get { return mStrBCC; }
        }
        string Subject
        {
            set { mStrSubject = value; }
            get { return mStrSubject; }
        }
        string Body
        {
            set { mStrBody = value; }
            get { return mStrBody; }
        }
        string PathAttachment
        {
            set { mStrPathAttach = value; }
            get { return mStrPathAttach; }
        }
        bool IsHtml
        {
            set { mBoolIsHTML = value; }
            get { return mBoolIsHTML; }
        }
        // ------------------------------------------------------------------------

        /// <summary>
        /// Constructor Base de la clase
        /// </summary>
        public cEnvioMail()
        {
            //
            // TODO: agregar aquí la lógica del constructor
            //
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="pvStrFrom"></param>
        /// <param name="pvStrTo"></param>
        /// <param name="pvStrSubject"</param>
        /// <param name="pvStrBody"</param>
        /// <param name="pvStrPathAttach"></param>
        public cEnvioMail(string pvStrFrom, string pvStrTo, string pvStrSubject, string pvStrBody, string pvStrPathAttach)
        {
            EnvioMail(pvStrFrom, pvStrTo, pvStrSubject, pvStrBody, pvStrPathAttach, false, string.Empty);
        }

        public cEnvioMail(string pvStrFrom, string pvStrTo, string pvStrSubject, string pvStrBody, string pvStrPathAttach, bool pvbolIsHTML)
        {
            EnvioMail(pvStrFrom, pvStrTo, pvStrSubject, pvStrBody, pvStrPathAttach, pvbolIsHTML, string.Empty);
        }
        public cEnvioMail(string pvStrFrom, string pvStrTo, string pvStrSubject, string pvStrBody, string pvStrPathAttach, bool pvbolIsHTML, string pvStrReplyTo)
        {
            EnvioMail(pvStrFrom, pvStrTo, pvStrSubject, pvStrBody, pvStrPathAttach, pvbolIsHTML, pvStrReplyTo);
        }
        private void EnvioMail(string pvStrFrom, string pvStrTo, string pvStrSubject, string pvStrBody, string pvStrPathAttach, bool pvbolIsHTML, string pvStrReplyTo)
        {
            mStrFrom = pvStrFrom;
            mStrTo = pvStrTo;
            mStrSubject = pvStrSubject;
            mStrBody = pvStrBody;
            mStrPathAttach = pvStrPathAttach;
            mBoolIsHTML = pvbolIsHTML;
            mStrReplyTo = pvStrReplyTo;
        }

        /// <summary>
        /// Metodo de envío: Devuelve TRUE si acaba con éxito
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            bool lbolResult;

            try
            {
                // Crea el objeto Mail message e informa sus propiedades
                MailMessage oMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "srv-exc.cosmic.local";
                smtp.Credentials = new System.Net.NetworkCredential("jmescorihuela", "xjose","COSMIC");
                
                oMessage.From = new System.Net.Mail.MailAddress(mStrFrom);
                if (mStrReplyTo != string.Empty)
                {
                    oMessage.ReplyTo = new System.Net.Mail.MailAddress(mStrReplyTo);
                }

                // Busca el fichero fisico adjuntado si es necesario
                if (mStrPathAttach != string.Empty)
                {
                    oMessage.Attachments.Add(new Attachment(mStrPathAttach));
                }

                string[] vTo = mStrTo.Split(';');
                for (int i = 0; i < vTo.Length; i++)
                {
                    string vsrtTo = vTo[i].Trim();
                    if (vsrtTo != "")
                    {
                        oMessage.To.Add(vsrtTo);
                    }
                }

                oMessage.Subject = mStrSubject;
                oMessage.BodyEncoding = System.Text.Encoding.UTF8;
                oMessage.IsBodyHtml = mBoolIsHTML;

                string[] vBody = mStrBody.Split((char)10);
                //oMessage.Body = "";
                for (int i = 0; i < vBody.Length; i++)
                {
                    string vsrtBody = vBody[i].Trim();
                    if (vsrtBody != "")
                    {
                        oMessage.Body += Environment.NewLine + vsrtBody;
                    }
                }

                //oMessage.Body += mStrBody;
                
                oMessage.Priority = System.Net.Mail.MailPriority.Normal;
                // Envía el mensaje
                smtp.Send(oMessage);
                lbolResult = true;
            }
            catch (Exception e)
            {
                _Error = e.Message;
                lbolResult = false;
            }
            return lbolResult;
        }
    }