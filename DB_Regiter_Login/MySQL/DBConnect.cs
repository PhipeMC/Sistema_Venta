using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Regiter_Login.BackEnd;
using MySql.Data.MySqlClient;

namespace DB_Regiter_Login.MySQL
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            //port = "3307";
            database = "tiendita";
            uid = "root";
            password = "root";
            /*string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";*/
            //connection = new MySqlConnection(String.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PASSWORD={4}", server, port, database, uid, password));
            connection = new MySqlConnection(String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3}", server, database, uid, password));
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Error al conectar con el servidor.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Error al iniciar sesion con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(int id, String nick, String password, String email)
        {
            //Registrar usuarios en la base de datos
            string query = String.Format("INSERT INTO userData (id, nickname, password, email) VALUES('{0}','{1}',md5('{2}'),'{3}')",id.ToString(), nick, password, email);
            
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE userData SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM userData WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM userData";

            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["nickname"] + "");
                    list[2].Add(dataReader["password"] + "");
                    list[3].Add(dataReader["email"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM userData";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Verificar usuario registrado
        public bool Check(String nickname, String password)
        {
            string query = String.Format("select usuario,contrasenia from empleados where usuario = '{0}' and contrasenia = '{1}'", nickname, password);

            //Create a list to store the result
            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                 //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["usuario"] + "");
                    list[1].Add(dataReader["contrasenia"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                if (list[0].Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Restore
        public int getID(String nickname)
        {
            string query = String.Format("SELECT id FROM userData where nickname = '{0}'",nickname);

            //Create a list to store the result
            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return int.Parse(list[0][0]);
            }
            else
            {
                return 0;
            }
        }

        public String getName(int id)
        {
            string query = String.Format("SELECT nickname FROM userData where id = '{0}'", id);

            //Create a list to store the result
            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["nickname"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list[0][0];
            }
            else
            {
                return null;
            }
        }

        public bool checkRegister(String nickname, String password, String email)
        {
            string query = String.Format("SELECT nickname FROM userData where nickname = '{0}'", nickname);

            //Create a list to store the result
            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["nickname"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                if (list[0].Count <= 0)
                {
                    return true;
                }
                else
                {
                    throw new SystemException();
                }
            }
            return true;
        }

        public String selectMessages(int id)
        {
            String text = String.Empty;
            string query = String.Format("select aes_decrypt(unhex(message),'#011099#')as message from userContent where id={0}", id);
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    
                    byte[] datos = dataReader["message"] as byte[];
                    foreach(byte b in datos)
                    {
                        text += (char)b;
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return text;
        }

        public void InsertMessage(int id, String text)
        {
            try
            {
                //Registrar usuarios en la base de datos
                string query = String.Format("insert into userContent values('{0}',hex(aes_encrypt('{1}','#011099#')));", id.ToString(), text);

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateMessage(int id, String text)
        {
            //Registrar usuarios en la base de datos
            string query = String.Format("update userContent set id ={0} , message = hex(aes_encrypt('{1}','#011099#')) where id = {2}", id.ToString(), text, id.ToString());

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<String>[] selectMessages2(int id)
        {
            String text = String.Empty;
            string query = String.Format("select message from userContent where id={0}", id);

            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["message"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return list;
        }


        public Empleado SelectEmpleado(String ID)
        {
            string query = String.Format("SELECT * FROM EMPLEADOS WHERE idEmpleado='{0}'", ID);

            Empleado empleado = new Empleado();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {

                    empleado.idEmpleado = datareader["idEmpleado"] + "";
                    empleado.nombreCompleto = datareader["nombreCompleto"] + "";
                    empleado.direccion = datareader["direccion"] + "";
                    empleado.telefono = datareader["telefono"] + "";
                    empleado.usuario = datareader["usuario"] + "";
                    empleado.contrasenia = datareader["contrasenia"] + "";
                    empleado.puesto = datareader["puesto"] + "";
                }

                datareader.Close();
                this.CloseConnection();

            }
            return empleado;
        }
        /// <summary>
        /// falta documentar
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public List<Empleado> SelectEmpleados()
        {
            string query = "SELECT * FROM empleados";
            List<Empleado> list = new List<Empleado>();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.idEmpleado = datareader["idEmpleado"] + "";
                    empleado.nombreCompleto = datareader["nombreCompleto"] + "";
                    empleado.direccion = datareader["direccion"] + "";
                    empleado.telefono = datareader["telefono"] + "";
                    empleado.usuario = datareader["usuario"] + "";
                    empleado.contrasenia = datareader["contrasenia"] + "";
                    empleado.puesto = datareader["puesto"] + "";
                    list.Add(empleado);
                }

                datareader.Close();
                this.CloseConnection();

            }
            return list;
        }


        /// <summary>
        /// Consulta para obtener los proveedores de la BD
        /// </summary>
        /// <returns>
        /// Regresa un Array de List<String> donde cada lista es una columna de la tabla 
        /// en la base de datos
        /// </returns>
        public List<string>[] SelectProveedores()
        {
            string query = "SELECT * FROM proveedores";

            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idProveedor"] + "");
                    list[1].Add(dataReader["nombreCompleto"] + "");
                    list[2].Add(dataReader["direccion"] + "");
                    list[3].Add(dataReader["telefono"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// Consulta para obtener los clientes de la BD
        /// </summary>
        /// <returns>
        /// Retorna una lista con las columnas correspondientes a los datos del cliente
        /// </returns>
        public List<string>[] SelectClientes()
        {
            string query = "SELECT * FROM clientes";

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idCliente"] + "");
                    list[1].Add(dataReader["nombre"] + "");
                    list[2].Add(dataReader["RFC"] + "");
                    list[3].Add(dataReader["direccion"] + "");
                    list[4].Add(dataReader["telefono"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public string CrearVenta(string fecha, string empleado, string cliente)
        {
            string res = "";
            try
            {
                
                //Registrar una venta nueva
                string query = String.Format("insert into `ventas` values (null,'{0}','{1}','{2}');", fecha, empleado, cliente);
                string query2 = String.Format("select MAX(idVenta) from ventas;");
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    
                    //Executamos el comando
                    cmd.ExecuteNonQuery();
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    MySqlDataReader dataReader = cmd2.ExecuteReader();
                    while (dataReader.Read())
                    {
                        res = dataReader["MAX(idVenta)"].ToString();
                    }
                    //Cerrar la conexión
                    this.CloseConnection();
                    return res;
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return res;
            }
            
        }
        public void InsertarVenta(string cantidad, string descuento, string producto)
        {
            try
            {
                string sele = "select MAX(idVenta) as id from ventas;";
                string pro = String.Format("select MAX(idProducto) as idP, precio from productos where nombre='{0}';", producto);


                if (this.OpenConnection() == true)
                {
                    //creamos el comando y el reader
                    MySqlCommand cmdS = new MySqlCommand(sele, connection);
                    MySqlCommand cmdP = new MySqlCommand(pro, connection);
                    MySqlDataReader dataReader = cmdS.ExecuteReader();
                    List<string>[] list = new List<string>[1];
                    List<string>[] listpro = new List<string>[2];
                    list[0] = new List<string>();
                    listpro[0] = new List<string>();
                    listpro[1] = new List<string>();
                    while (dataReader.Read())
                    {
                        //añadimos el valor obtenido al list
                        list[0].Add(dataReader["id"] + "");

                    }
                    dataReader.Close();
                    MySqlDataReader dataReaderP = cmdP.ExecuteReader();
                    while (dataReaderP.Read())
                    {
                        listpro[0].Add(dataReaderP["idP"] + "");
                        listpro[1].Add(dataReaderP["precio"] + "");
                    }
                    //Cerrar readers
                    dataReaderP.Close();
                    //registramos un detalle más a la venta
                    string query = String.Format("insert into `detallesventa` values ('{0}','{1}','{2}','{3}','{4}');", listpro[1][0].ToString(), cantidad, descuento, list[0][0].ToString(),listpro[0][0].ToString());
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Executamos el comando
                    cmd.ExecuteNonQuery();

                    //Cerrar la conexión
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public List<string>[] SelectVenta(string producto)
        {
            string pro = String.Format("select MAX(idProducto) from productos where nombre='{0}';", producto);

            List<string>[] listpro = new List<string>[1];
            listpro[0] = new List<string>();
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            if (this.OpenConnection() == true)
            {
                //Create Command               
                MySqlCommand cmdP = new MySqlCommand(pro, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReaderP = cmdP.ExecuteReader();
                //Read the data and store them in the list
                while (dataReaderP.Read())
                {
                    listpro[0].Add(dataReaderP["MAX(idProducto)"] + "");
                }
                dataReaderP.Close();
                string query = String.Format("select precioXUnidad, MAX(IDVenta), IDProducto from detallesventa where idProducto = '{0}';", listpro[0][0]);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["precioXUnidad"] + "");
                    list[1].Add(dataReader["MAX(IDVenta)"] + "");
                    list[2].Add(dataReader["IDProducto"] + "");
                }

                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public int get_Last_ID_Client()
        {
            try
            {
                string query = "select idcliente from clientes order by idcliente desc; ";

                //Create a list to store the result
                List<string> list = new List<string>();

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["idCliente"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                }
                return Convert.ToInt32(list[0]) + 1;
            }
            catch (Exception ex) {
                ex.ToString();
                return 1;
            }
        }

        public List<string>[] SelectClientes(String ID)
        {
            string query = String.Format("Select * from clientes where idcliente={0}",ID);

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idCliente"] + "");
                    list[1].Add(dataReader["nombre"] + "");
                    list[2].Add(dataReader["RFC"] + "");
                    list[3].Add(dataReader["direccion"] + "");
                    list[4].Add(dataReader["telefono"] + "");
                }

                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        public void add_Client(int id, String nombre, String direccion, String telefono, String RFC)
        {
            //Registrar usuarios en la base de datos
            string query = String.Format("insert into clientes value({0},'{1}','{2}','{3}','{4}')", id.ToString(), nombre, RFC, direccion, telefono);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void update_Client(int id, String nombre, String direccion, String telefono, String RFC)
        {
            string query = String.Format("update clientes set nombre='{0}', direccion='{1}', telefono='{2}', RFC='{3}' where idcliente={4}",nombre,direccion,telefono,RFC,id);

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public String get_Puesto(String Usuario)
        {
            string query = String.Format("Select puesto from empleados where Usuario='{0}'", Usuario);

            //Create a list to store the result
            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["puesto"] + "");
                }

                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public String get_Nombre(String Usuario)
        {
            string query = String.Format("Select nombreCompleto from empleados where Usuario='{0}'", Usuario);

            //Create a list to store the result
            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["nombreCompleto"] + "");
                }

                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list[0];
            }
            else
            {
                return null;
            }
        }
    }
}
