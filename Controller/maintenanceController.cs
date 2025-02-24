using finals_UI.Model.classes;
using MySql.Data.MySqlClient;
using finals_UI.Model.Database;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class maintenanceController
    {
        public void addMaintenance(maintenance maintenance)
        {
            try
            {
                // Establish database connection
                dbConnection con = new dbConnection();
                con.openConnection();

                // Step 1: Fetch the associated serviceIds for the selected appointmentId
                List<int> serviceIds = new List<int>();
                string fetchServicesQuery = "SELECT serviceId FROM appointment_service WHERE appointmentId = @appointmentId";

                using (MySqlCommand fetchCmd = new MySqlCommand(fetchServicesQuery, con.getConnection()))
                {
                    fetchCmd.Parameters.AddWithValue("@appointmentId", maintenance.serviceId);
                    using (MySqlDataReader reader = fetchCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            serviceIds.Add(reader.GetInt32("serviceId"));
                        }
                    }
                }

                if (serviceIds.Count == 0)
                {
                    MessageBox.Show("No services found for the selected appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Insert a record into the maintenance table for each serviceId
                string maintenanceInsertQuery = "INSERT INTO maintenance(maintenanceStatus, maintenanceDescription, vehicleId, serviceId, customerInvoiceId) VALUES (@maintenanceStatus, @maintenanceDescription, @vehicleId, @serviceId, @customerInvoiceId)";
                int recordsInserted = 0;

                foreach (int serviceId in serviceIds)
                {
                    using (MySqlCommand maintenanceCmd = new MySqlCommand(maintenanceInsertQuery, con.getConnection()))
                    {
                        maintenanceCmd.Parameters.AddWithValue("@maintenanceStatus", maintenance.maintenanceStatus);
                        maintenanceCmd.Parameters.AddWithValue("@maintenanceDescription", maintenance.maintenanceDescription);
                        maintenanceCmd.Parameters.AddWithValue("@vehicleId", maintenance.vehicleId);
                        maintenanceCmd.Parameters.AddWithValue("@serviceId", serviceId);
                        maintenanceCmd.Parameters.AddWithValue("@customerInvoiceId", maintenance.customerInvoiceId);

                        maintenanceCmd.ExecuteNonQuery();

                        // Step 3: Get the Last Inserted maintenanceId
                        int maintenanceId = (int)maintenanceCmd.LastInsertedId;
                        recordsInserted++;

                        // Step 4: Insert into employee_maintenance for each maintenanceId
                        string employeeMaintenanceQuery = "INSERT INTO employee_maintenance (employeeId, maintenanceId, maintenanceDate) VALUES (@employeeId, @maintenanceId, @maintenanceDate)";
                        using (MySqlCommand employeeMaintenanceCmd = new MySqlCommand(employeeMaintenanceQuery, con.getConnection()))
                        {
                            employeeMaintenanceCmd.Parameters.AddWithValue("@employeeId", maintenance.employeeId);
                            employeeMaintenanceCmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                            employeeMaintenanceCmd.Parameters.AddWithValue("@maintenanceDate", maintenance.maintenanceDate);

                            employeeMaintenanceCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show($"Number of maintenance records inserted: {recordsInserted}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close connection
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataSet viewMaintenanceDetails()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = @"
                    SELECT 
                        GROUP_CONCAT(DISTINCT m.maintenanceId ORDER BY m.maintenanceId ASC SEPARATOR ', ') AS MaintenanceIDs,
                        CONCAT(e.firstName, ' ', e.lastName) AS Employee,
                        v.plateNumber AS PlateNo,
                        GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services,
                        m.maintenanceStatus AS Status,
                        m.maintenanceDescription AS Description,
                        em.maintenanceDate AS Date,
                        cs.invoiceNo AS InvoiceNo
                    FROM maintenance m
                    JOIN vehicle v ON v.vehicleId = m.vehicleId
                    JOIN employee_maintenance em ON em.maintenanceId = m.maintenanceId
                    JOIN employee e ON e.employeeId = em.employeeId
                    JOIN customer_invoice cs ON cs.customerInvoiceId = m.customerInvoiceId
                    JOIN service s ON s.serviceId = m.serviceId
                    GROUP BY e.firstName, e.lastName, v.plateNumber, m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate, cs.invoiceNo;";

            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet loadVehicleNo()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT vehicleId,plateNumber FROM vehicle WHERE deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet loadEmployeeName()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT employeeId,CONCAT(firstName, ' ', lastName) AS Name FROM employee WHERE deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet loadServices()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT a1.appointmentId, GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services " +
                "FROM appointment_service a1 JOIN service s ON a1.serviceId = s.serviceId GROUP BY a1.appointmentId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet loadInvoiceNo()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT customerInvoiceId,invoiceNo FROM customer_invoice";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public void updateMaintenance(List<int> maintenanceIds, string maintenanceStatus, string maintenanceDescription, DateTime maintenanceDate)
        {
            try
            {
                dbConnection con = new dbConnection();
                con.openConnection();

                int recordsUpdated = 0;

                foreach (int maintenanceId in maintenanceIds)
                {
                    // Fetch current values from the database
                    string selectQuery = @"
                        SELECT m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate
                        FROM maintenance m
                        JOIN employee_maintenance em ON m.maintenanceId = em.maintenanceId
                        WHERE m.maintenanceId = @maintenanceId";

                    string currentStatus = "";
                    string currentDescription = "";
                    DateTime currentMaintenanceDate = DateTime.MinValue;

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con.getConnection()))
                    {
                        selectCmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentStatus = reader["maintenanceStatus"].ToString();
                                currentDescription = reader["maintenanceDescription"].ToString();
                                currentMaintenanceDate = Convert.ToDateTime(reader["maintenanceDate"]);
                            }
                        }
                    }

                    // Skip update if values haven't changed
                    if (currentStatus == maintenanceStatus &&
                        currentDescription == maintenanceDescription &&
                        currentMaintenanceDate == maintenanceDate)
                    {
                        continue;
                    }

                    // Update maintenance table (Status and Description)
                    string updateMaintenanceQuery = @"
                        UPDATE maintenance 
                        SET maintenanceStatus = @maintenanceStatus, 
                            maintenanceDescription = @maintenanceDescription
                        WHERE maintenanceId = @maintenanceId";

                    using (MySqlCommand maintenanceCmd = new MySqlCommand(updateMaintenanceQuery, con.getConnection()))
                    {
                        maintenanceCmd.Parameters.AddWithValue("@maintenanceStatus", maintenanceStatus);
                        maintenanceCmd.Parameters.AddWithValue("@maintenanceDescription", maintenanceDescription);
                        maintenanceCmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                        maintenanceCmd.ExecuteNonQuery();
                    }

                    string updateEmployeeMaintenanceQuery = @"
                        UPDATE employee_maintenance 
                        SET maintenanceDate = @maintenanceDate
                        WHERE maintenanceId = @maintenanceId";

                    using (MySqlCommand employeeMaintenanceCmd = new MySqlCommand(updateEmployeeMaintenanceQuery, con.getConnection()))
                    {
                        employeeMaintenanceCmd.Parameters.AddWithValue("@maintenanceDate", maintenanceDate);
                        employeeMaintenanceCmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                        employeeMaintenanceCmd.ExecuteNonQuery();
                    }
                    recordsUpdated++;
                }
                if (recordsUpdated > 0)
                {
                    MessageBox.Show($"Number of maintenance records updated: {recordsUpdated}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Only Status, Description and Date can be changed. Update skipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void deleteMaintenance(string concatenatedMaintenanceIds)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    // Split the concatenated string into a list of maintenance IDs
                    List<int> maintenanceIds = concatenatedMaintenanceIds
                        .Split(',')
                        .Select(id => int.TryParse(id.Trim(), out int parsedId) ? parsedId : (int?)null)
                        .Where(id => id.HasValue)
                        .Select(id => id.Value)
                        .ToList();

                    if (maintenanceIds.Count == 0)
                    {
                        MessageBox.Show("No valid maintenance records selected for deletion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dbConnection con = new dbConnection();
                    con.openConnection();

                    foreach (int maintenanceId in maintenanceIds)
                    {
                        string deleteEmployeeMaintenanceQuery = "DELETE FROM employee_maintenance WHERE maintenanceId = @maintenanceId";
                        using (MySqlCommand cmd = new MySqlCommand(deleteEmployeeMaintenanceQuery, con.getConnection()))
                        {
                            cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                            cmd.ExecuteNonQuery();
                        }
                        string deleteMaintenanceQuery = "DELETE FROM maintenance WHERE maintenanceId = @maintenanceId";
                        using (MySqlCommand cmd = new MySqlCommand(deleteMaintenanceQuery, con.getConnection()))
                        {
                            cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.closeConnection();
                    MessageBox.Show("Selected maintenance records have been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public DataSet searchByEmployee(string employeeName)
        {
            try
            {
                dbConnection con = new dbConnection();
                con.openConnection();

                string query = @"
                    SELECT 
                        GROUP_CONCAT(DISTINCT m.maintenanceId ORDER BY m.maintenanceId ASC SEPARATOR ', ') AS MaintenanceIDs,
                        CONCAT(e.firstName, ' ', e.lastName) AS Employee,
                        v.plateNumber AS PlateNo,
                        GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services,
                        m.maintenanceStatus AS Status,
                        m.maintenanceDescription AS Description,
                        em.maintenanceDate AS Date,
                        cs.invoiceNo AS InvoiceNo
                    FROM maintenance m
                    JOIN vehicle v ON v.vehicleId = m.vehicleId
                    JOIN employee_maintenance em ON em.maintenanceId = m.maintenanceId
                    JOIN employee e ON e.employeeId = em.employeeId
                    JOIN customer_invoice cs ON cs.customerInvoiceId = m.customerInvoiceId
                    JOIN service s ON s.serviceId = m.serviceId
                    WHERE CONCAT(LOWER(e.firstName), ' ', LOWER(e.lastName)) LIKE LOWER(@employeeName)
                    GROUP BY e.firstName, e.lastName, v.plateNumber, m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate, cs.invoiceNo;";

                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                
                com.Parameters.AddWithValue("@employeeName", "%" + employeeName + "%"); // Search for partial matches

                //data adapter class
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataSet searchByPlateNumber(string plateNumber)
        {
            try
            {
                dbConnection con = new dbConnection();
                con.openConnection();

                string query = @"
                    SELECT 
                        GROUP_CONCAT(DISTINCT m.maintenanceId ORDER BY m.maintenanceId ASC SEPARATOR ', ') AS MaintenanceIDs,
                        CONCAT(e.firstName, ' ', e.lastName) AS Employee,
                        v.plateNumber AS PlateNo,
                        GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services,
                        m.maintenanceStatus AS Status,
                        m.maintenanceDescription AS Description,
                        em.maintenanceDate AS Date,
                        cs.invoiceNo AS InvoiceNo
                    FROM maintenance m
                    JOIN vehicle v ON v.vehicleId = m.vehicleId
                    JOIN employee_maintenance em ON em.maintenanceId = m.maintenanceId
                    JOIN employee e ON e.employeeId = em.employeeId
                    JOIN customer_invoice cs ON cs.customerInvoiceId = m.customerInvoiceId
                    JOIN service s ON s.serviceId = m.serviceId
                    WHERE LOWER(v.plateNumber) LIKE LOWER(@plateNumber)
                    GROUP BY e.firstName, e.lastName, v.plateNumber, m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate, cs.invoiceNo;";

                MySqlCommand com = new MySqlCommand(query, con.getConnection());               
                com.Parameters.AddWithValue("@plateNumber", "%" + plateNumber.Trim() + "%"); // Trim input for clean search

                MySqlDataAdapter da = new MySqlDataAdapter(com);                      
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;                      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataSet searchByMaintenanceStatus(string maintenanceStatus)
        {
            try
            {
                dbConnection con = new dbConnection();
                con.openConnection();

                string query = @"
                    SELECT 
                        GROUP_CONCAT(DISTINCT m.maintenanceId ORDER BY m.maintenanceId ASC SEPARATOR ', ') AS MaintenanceIDs,
                        CONCAT(e.firstName, ' ', e.lastName) AS Employee,
                        v.plateNumber AS PlateNo,
                        GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services,
                        m.maintenanceStatus AS Status,
                        m.maintenanceDescription AS Description,
                        em.maintenanceDate AS Date,
                        cs.invoiceNo AS InvoiceNo
                    FROM maintenance m
                    JOIN vehicle v ON v.vehicleId = m.vehicleId
                    JOIN employee_maintenance em ON em.maintenanceId = m.maintenanceId
                    JOIN employee e ON e.employeeId = em.employeeId
                    JOIN customer_invoice cs ON cs.customerInvoiceId = m.customerInvoiceId
                    JOIN service s ON s.serviceId = m.serviceId
                    WHERE LOWER(m.maintenanceStatus) LIKE LOWER(@maintenanceStatus)
                    GROUP BY e.firstName, e.lastName, v.plateNumber, m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate, cs.invoiceNo;";

                MySqlCommand com = new MySqlCommand(query, con.getConnection());               
                com.Parameters.AddWithValue("@maintenanceStatus", "%" + maintenanceStatus.Trim() + "%"); // Trim input for clean search

                MySqlDataAdapter da = new MySqlDataAdapter(com);                   
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public DataSet searchByInvoiceNo(string customerInvoiceNo)
        {
            try
            {
                dbConnection con = new dbConnection();
                con.openConnection();

                string query = @"
                    SELECT 
                        GROUP_CONCAT(DISTINCT m.maintenanceId ORDER BY m.maintenanceId ASC SEPARATOR ', ') AS MaintenanceIDs,
                        CONCAT(e.firstName, ' ', e.lastName) AS Employee,
                        v.plateNumber AS PlateNo,
                        GROUP_CONCAT(DISTINCT s.serviceName SEPARATOR ', ') AS Services,
                        m.maintenanceStatus AS Status,
                        m.maintenanceDescription AS Description,
                        em.maintenanceDate AS Date,
                        cs.invoiceNo AS InvoiceNo
                    FROM maintenance m
                    JOIN vehicle v ON v.vehicleId = m.vehicleId
                    JOIN employee_maintenance em ON em.maintenanceId = m.maintenanceId
                    JOIN employee e ON e.employeeId = em.employeeId
                    JOIN customer_invoice cs ON cs.customerInvoiceId = m.customerInvoiceId
                    JOIN service s ON s.serviceId = m.serviceId
                    WHERE LOWER(cs.invoiceNo) LIKE LOWER(@customerInvoiceNo)
                    GROUP BY e.firstName, e.lastName, v.plateNumber, m.maintenanceStatus, m.maintenanceDescription, em.maintenanceDate, cs.invoiceNo;";

                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@customerInvoiceNo", "%" + customerInvoiceNo.Trim() + "%"); // Trim input for clean search

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
