using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//login
        {
            
           
            string Server = "simpe.net";// dominio del servidor
            string ruta = "LDAP://"+Server+ "/DC=simpe,DC=net"; //Editor ADSI
            DirectoryEntry raiz = new DirectoryEntry();
            raiz.Path = ruta;
            raiz.AuthenticationType = AuthenticationTypes.Secure;
            raiz.Username= User.Text.Trim();//Usuario
            raiz.Password = PW.Text.Trim();//Contraseña
            string filtro = "sAMAccountName";
            String strSeach = filtro + "=" + User.Text.Trim();//Usuario
            DirectorySearcher dsSystemn = new DirectorySearcher(raiz,strSeach);
            dsSystemn.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult srSystem = dsSystemn.FindOne();//LLama el proceso del active directory
                string puesto = srSystem.Path.ToString();

                int fount = 0;
                int end = 0;
                string Puestos;
                for (int i = 0; i < puesto.Length; i++)
                {
                   
                        fount = puesto.IndexOf("OU=");
                        Puestos= puesto.Substring(fount + 3);
                         end = Puestos.IndexOf("DC=");
                        permitido.Text = puesto.Substring(fount + 3,end-1);
                }
              

                permitido.BackColor = Color.Green;
                permitido.ForeColor = Color.White;
             
            }
            catch (Exception prueba)
            {
                permitido.BackColor = Color.Red;
                  permitido.ForeColor = Color.Black;
                   permitido.Text = "Acceso denegado";

            }


          
        }

        protected void Button2_Click(object sender, EventArgs e)//Get
        {
            var url = $"http://localhost:58714/api/Enviar/Prueba";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            permitido.Text= responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        protected void Button3_Click(object sender, EventArgs e)//Post
        {
            var url = $"http://localhost:58714/api/Enviar/ConsultaPagosEnviados";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            permitido.Text = responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }
    }
}