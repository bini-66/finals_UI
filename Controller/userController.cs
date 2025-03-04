using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace finals_UI.Controller
{
    internal class userController
    {
       public void addUser(user user)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            //insertng into user table
            string query = "INSERT INTO user(username,password,role,application_id) VALUES (@username,@password,@role,@application_id)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());
            com.Parameters.AddWithValue("@username", user.username);
            com.Parameters.AddWithValue("@password",user.password);
            com.Parameters.AddWithValue("@role",user.role);
            com.Parameters.AddWithValue("@application_id", 2);

            com.ExecuteNonQuery();

            string getUserId = "SELECT LAST_INSERT_ID()";
            MySqlCommand com2 = new MySqlCommand(getUserId, con.getConnection());
            int userId = Convert.ToInt32(com2.ExecuteScalar());

            if(user.role== "Receptionist")
            {
                receptionist receptionist = (receptionist)user;

                //inserting data into receptionist table
                string query3 = "INSERT INTO receptionist(firstName,lastName,email,phoneNumber,userId) VALUES(@firstName,@lastName,@email,@phoneNumber,@userId)";
                MySqlCommand com3=new MySqlCommand(query3,con.getConnection());

                com3.Parameters.AddWithValue("@firstName", receptionist.firstName);
                com3.Parameters.AddWithValue("@lastName", receptionist.lastName);
                com3.Parameters.AddWithValue("@email", receptionist.email);
                com3.Parameters.AddWithValue("@phoneNumber", receptionist.phoneNumber);
                com3.Parameters.AddWithValue("@userId",userId);


                com3.ExecuteNonQuery();
            }
            else if (user.role == "Operational Manager")
            {
                operationalManager operationalManager = (operationalManager)user;

                //inserting data into receptionist table
                string query4 = "INSERT INTO operational_manager(firstName,lastName,email,phoneNumber,userId) VALUES(@firstName,@lastName,@email,@phoneNumber,@userId)";
                MySqlCommand com4 = new MySqlCommand(query4, con.getConnection());

                com4.Parameters.AddWithValue("@firstName", operationalManager.firstName);
                com4.Parameters.AddWithValue("@lastName", operationalManager.lastName);
                com4.Parameters.AddWithValue("@email", operationalManager.email);
                com4.Parameters.AddWithValue("@phoneNumber", operationalManager.phoneNumber);
                com4.Parameters.AddWithValue("@userId",userId);

                com4.ExecuteNonQuery();
            }
            else if (user.role == "Inventory Manager")
            {
                inventoryManager inventoryManager = (inventoryManager)user;

                //inserting data into receptionist table
                string query5 = "INSERT INTO inventory_manager(firstName,lastName,email,phoneNumber,userId) VALUES(@firstName,@lastName,@email,@phoneNumber,@userId)";
                MySqlCommand com5 = new MySqlCommand(query5, con.getConnection());

                com5.Parameters.AddWithValue("@firstName", inventoryManager.firstName);
                com5.Parameters.AddWithValue("@lastName", inventoryManager.lastName);
                com5.Parameters.AddWithValue("@email", inventoryManager.email);
                com5.Parameters.AddWithValue("@phoneNumber", inventoryManager.phoneNumber);
                com5.Parameters.AddWithValue("@userId", userId);

                com5.ExecuteNonQuery();
            }
            else if (user.role == "Service Manager")
            {
                serviceManager serviceManager = (serviceManager)user;

                //inserting data into receptionist table
                string query6 = "INSERT INTO service_manager(firstName,lastName,email,phoneNumber,userId) VALUES(@firstName,@lastName,@email,@phoneNumber,@userId)";
                MySqlCommand com6 = new MySqlCommand(query6, con.getConnection());

                com6.Parameters.AddWithValue("@firstName", serviceManager.firstName);
                com6.Parameters.AddWithValue("@lastName", serviceManager.lastName);
                com6.Parameters.AddWithValue("@email", serviceManager.email);
                com6.Parameters.AddWithValue("@phoneNumber", serviceManager.phoneNumber);
                com6.Parameters.AddWithValue("@userId", userId);

                com6.ExecuteNonQuery();
            }
            else if (user.role == "Owner")
            {
                owner owner = (owner)user;

                //inserting data into receptionist table
                string query7 = "INSERT INTO owner(firstName,lastName,email,phoneNumber,userId) VALUES(@firstName,@lastName,@email,@phoneNumber,@userId)";
                MySqlCommand com7 = new MySqlCommand(query7, con.getConnection());

                com7.Parameters.AddWithValue("@firstName", owner.firstName);
                com7.Parameters.AddWithValue("@lastName", owner.lastName);
                com7.Parameters.AddWithValue("@email", owner.email);
                com7.Parameters.AddWithValue("@phoneNumber", owner.phoneNumber);
                com7.Parameters.AddWithValue("@userId", userId);

                com7.ExecuteNonQuery();
            }
            MessageBox.Show("User added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        public bool userLogin(user user)
        {
            //  connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = "SELECT userId, role FROM user WHERE username=@username AND password=@password AND deleted_flag=FALSE AND application_id=2";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@username", user.username);
            com.Parameters.AddWithValue("@password", user.password);

            MySqlDataReader reader = com.ExecuteReader();

            if (reader.Read()) // If user exists
            {
                user.userId = reader.GetInt32("userId");
                user.role = reader.GetString("role");

                // Store session data         
                userSession.Login(user.userId, user.username, user.role);

                //MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;   
            }
        }

        public void resetPW(string newPW,string username)
        {
            //connection classs
            dbConnection con = new dbConnection();
            con.openConnection();
            //command class
            string query = "UPDATE user SET password=@password WHERE username=@username AND deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@password", newPW);
            com.Parameters.AddWithValue("@username", username);

            int ret = com.ExecuteNonQuery();

            MessageBox.Show("reset successfully");


        }
        public int validateUsername(string username)
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT COUNT(*) FROM user WHERE username=@username AND deleted_flag=FALSE AND application_id=2";
            MySqlCommand com = new MySqlCommand( query, con.getConnection());

            com.Parameters.AddWithValue("@username", username);

            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count == 0)
            {
                // Username does not exist
                MessageBox.Show("Please enter a valid login email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1; 
            }

            // Username exists
            return 1;


        }
        public DataSet loadUsers()
        {
            dbConnection con = new dbConnection();
            con.openConnection();
            String query = "SELECT u.userId, cr.firstName, cr.lastName, " +
               "CONCAT(cr.firstName, ' ', cr.lastName) AS fullName, " +
               "cr.email, cr.phoneNumber AS phone, cr.role " +
               "FROM user u " +
               "JOIN ( " +
               "    SELECT r.userId, r.firstName, r.lastName, r.email, r.phoneNumber, 'Receptionist' AS role FROM receptionist r " +
               "    UNION ALL " +
               "    SELECT sm.userId, sm.firstName, sm.lastName, sm.email, sm.phoneNumber, 'Service Manager' AS role FROM service_manager sm " +
               "    UNION ALL " +
               "    SELECT om.userId, om.firstName, om.lastName, om.email, om.phoneNumber, 'Operational Manager' AS role FROM operational_manager om " +
               "    UNION ALL " +
               "    SELECT im.userId, im.firstName, im.lastName, im.email, im.phoneNumber, 'Inventory Manager' AS role FROM inventory_manager im " +
               "    UNION ALL " +
               "    SELECT o.userId, o.firstName, o.lastName, o.email, o.phoneNumber, 'Owner' AS role FROM owner o " +
               ") AS cr ON u.userId = cr.userId WHERE u.deleted_flag=FALSE;";



            MySqlCommand com =new MySqlCommand(query, con.getConnection());
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);
            return ds;
        }
        public DataSet serachUser(string searchText)
        {
            //connection class
            dbConnection con= new dbConnection();
            con.openConnection();

            //command class
            String query = "SELECT u.userId, cr.firstName, cr.lastName, " +
                "CONCAT(cr.firstName, ' ', cr.lastName) AS fullName, " +
                "cr.email, cr.phoneNumber AS phone, cr.role " +
                "FROM user u " +
                "JOIN ( " +
                "    SELECT r.userId, r.firstName, r.lastName, r.email, r.phoneNumber, 'Receptionist' AS role FROM receptionist r " +
                "    UNION ALL " +
                "    SELECT sm.userId, sm.firstName, sm.lastName, sm.email, sm.phoneNumber, 'Service Manager' AS role FROM service_manager sm " +
                "    UNION ALL " +
                "    SELECT om.userId, om.firstName, om.lastName, om.email, om.phoneNumber, 'Operational Manager' AS role FROM operational_manager om " +
                "    UNION ALL " +
                "    SELECT im.userId, im.firstName, im.lastName, im.email, im.phoneNumber, 'Inventory Manager' AS role FROM inventory_manager im " +
                "    UNION ALL " +
                "    SELECT o.userId, o.firstName, o.lastName, o.email, o.phoneNumber, 'Owner' AS role FROM owner o " +
                ") AS cr ON u.userId = cr.userId " +
                "WHERE( u.userId = @txtsearch " +
                "OR cr.firstName LIKE CONCAT('%', @txtsearch, '%') " +
                "OR cr.role LIKE CONCAT('%', @txtsearch, '%') " +
                "OR cr.lastName LIKE CONCAT('%', @txtsearch, '%') ) AND  u.deleted_flag=FALSE;";

            MySqlCommand com =new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@txtsearch", searchText);

            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            return ds;  
            
        }
        public void deleteUser(int userId)
        {
            dbConnection con= new dbConnection();
            con.openConnection();

            //settng teh flag in user table
            string query = "UPDATE user SET deleted_flag=TRUE WHERE userId=@userId";
            MySqlCommand com =new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@userId", userId);
           int result1= com.ExecuteNonQuery();

            //settng the flag in role based tables
            string query2 = @"
            UPDATE receptionist SET deleted_flag = TRUE WHERE userId = @userId;
            UPDATE service_manager SET deleted_flag = TRUE WHERE userId = @userId;
            UPDATE operational_manager SET deleted_flag = TRUE WHERE userId = @userId;
            UPDATE inventory_manager SET deleted_flag = TRUE WHERE userId = @userId;
            UPDATE owner SET deleted_flag = TRUE WHERE userId = @userId;";
            MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());

            com2.Parameters.AddWithValue("@userId", userId);
            int result2=com2.ExecuteNonQuery();

            if(result1>0 && result2 > 0)
            {
                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
