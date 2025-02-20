﻿using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string query = "INSERT INTO user(username,password,role) VALUES (@username,@password,@role)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());
            com.Parameters.AddWithValue("@username", user.username);
            com.Parameters.AddWithValue("@password",user.password);
            com.Parameters.AddWithValue("@role",user.role);

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

            string query = "SELECT userId, role FROM user WHERE username=@username AND password=@password";
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

                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;   
            }
        }
    }
}
