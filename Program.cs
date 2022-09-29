
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Exactus.Tools.Conexion;

namespace CALC_INTERES
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] argvs)
        {
            string user, userx = "", pass, passx = "", db, owner, server = "", var2;
            bool flag = false;
            if (argvs.Length == 0)
            {

                user = "sa";
                pass = "123";
                db = "GALAXIA";
                owner = "GALAXIA";
                server = "200.1.1.57";

            }

            else
            {
                user = argvs[0];
                pass = argvs[1];
                db = argvs[2];
                owner = argvs[3];
                server = argvs[4];
            }
			//MessageBox.Show("  Usuario:    "+ user + "  clave:    "+ pass +"  server:   "+ server+ " Compania:  "+ owner+"   db:  " +db);
            // }/*     try
            //  {

            //   StaticData.ObtenerServidorODBC(db, out server, out var2);

            StaticData.oCnn = new Conexion(TipoBDEnum.SqlServer, server, db, owner, user, pass);
            StaticData.oCnn.Open();
            if (StaticData.oCnn.IsOpen)
            {

                StaticData.oCnn.Close();
                if (user.ToUpper() != "SA" && user.ToUpper() != "SYSTEM")
                    StaticData.GetUserX(user, out userx, out passx);
                else
                {
                    userx = user;
                    passx = pass;
			//		MessageBox.Show(" "+userx + passx);
                }
                StaticData.oCnn = new Conexion(TipoBDEnum.SqlServer, server, db, owner, userx, passx);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run((Form)new Form1());
                StaticData.oCnn.Close();
            }
            //  }
            /*  catch (Exception ex)
              {

                  MessageBox.Show(null, "Error con:" + user + "-" + userx + "-" + pass + "-" + passx + "-" + db + "-" + owner + "-" + server + " \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  StaticData.oCnn.Close();
              }*/


        }
    }
}






















