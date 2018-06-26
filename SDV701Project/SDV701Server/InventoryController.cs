using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace SDV701Server
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Handles all webrequests from the clients.
    /// </summary>
    public class InventoryController : ApiController
    {
        public bool getConnectionTest()
        {
            return true;
        }

        public Dictionary<int, string> GetManufacturersNames()
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT code, name FROM Manufacturer", null);
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach(DataRow row in table.Rows)
            {
                result.Add(Convert.ToInt32(row[0]), (string)row[1]);
            }
            return result;
        }

        public ComputerManufacturer GetManufacturer(int code)
        {
            DataTable table;
            // Get list of models
            table = DatabaseConnection.GetDataTable("SELECT * FROM Computer WHERE Computer.manufacturer = @code", new Dictionary<string, object>() { { "code", code } });
            List<ComputerModel> modelList = new List<ComputerModel>();
            foreach(DataRow row in table.Rows)
            {
                modelList.Add
                (
                    new ComputerModel()
                    {
                        name = (string)row["modelName"],
                        manufacturer = getManufacturerName(Convert.ToInt32(row["manufacturer"])),
                        type = (string)row["modelType"],
                        price = Convert.ToDecimal(row["price"]),
                        quantity = Convert.ToInt16(row["quantity"]),
                        modifiedDate = Convert.ToDateTime(row["modifiedDate"]),
                        operatingSystem = (string)row["operatingSystem"],
                        processorFamily = (string)row["processorFamily"],
                        graphicsFamily = (string)row["graphicsFamily"],
                        storage = Convert.ToInt32(row["storage"]),
                        memory = Convert.ToByte(row["memory"]),
                        powerSupply = row["powerSupply"] == DBNull.Value ? (short)0 : Convert.ToInt16(row["powerSupply"]),
                        towerForm = row["towerForm"] == DBNull.Value ? "" : (string)row["towerForm"],
                        screenSize = row["screenSize"] == DBNull.Value ? (byte)0 : Convert.ToByte(row["screenSize"]),
                        batteryLife = row["batteryLife"] == DBNull.Value ? (byte)0 : Convert.ToByte(row["batteryLife"]),
                        webcamera = row["webcamera"] == DBNull.Value ? false: Convert.ToBoolean(row["webcamera"]),
                        fullsizeKeyboard = row["fullsizeKeyboard"] == DBNull.Value ? false : Convert.ToBoolean(row["fullsizeKeyboard"])
                    }
                );
            }
            // Get manufacturer
            table = DatabaseConnection.GetDataTable("SELECT * FROM Manufacturer WHERE Manufacturer.code = @code", new Dictionary<string, object>() { { "code", code } });
            if (table.Rows.Count > 0)
                return new ComputerManufacturer()
                {
                    code = Convert.ToInt32(table.Rows[0]["code"]),
                    name = (string)table.Rows[0]["name"],
                    country = (string)table.Rows[0]["country"],
                    models = modelList
                };
            else
                return null;
        }

        public ComputerModel GetComputerModel(string name)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT * FROM Computer WHERE Computer.modelName = @name", new Dictionary<string, object>() { { "name", name } });
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                return new ComputerModel()
                {
                    name = (string)row["modelName"],
                    manufacturer = getManufacturerName(Convert.ToInt32(row["manufacturer"])),
                    type = (string)row["modelType"],
                    price = Convert.ToDecimal(row["price"]),
                    quantity = Convert.ToInt16(row["quantity"]),
                    modifiedDate = Convert.ToDateTime(row["modifiedDate"]),
                    operatingSystem = (string)row["operatingSystem"],
                    processorFamily = (string)row["processorFamily"],
                    graphicsFamily = (string)row["graphicsFamily"],
                    storage = Convert.ToInt32(row["storage"]),
                    memory = Convert.ToByte(row["memory"]),
                    powerSupply = row["powerSupply"] == DBNull.Value ? (short)0 : Convert.ToInt16(row["powerSupply"]),
                    towerForm = row["towerForm"] == DBNull.Value ? "" : (string)row["towerForm"],
                    screenSize = row["screenSize"] == DBNull.Value ? (byte)0 : Convert.ToByte(row["screenSize"]),
                    batteryLife = row["batteryLife"] == DBNull.Value ? (byte)0 : Convert.ToByte(row["batteryLife"]),
                    webcamera = row["webcamera"] == DBNull.Value ? false : Convert.ToBoolean(row["webcamera"]),
                    fullsizeKeyboard = row["fullsizeKeyboard"] == DBNull.Value ? false : Convert.ToBoolean(row["fullsizeKeyboard"])
                };
            }
            else
                return null;
        }

        public Boolean GetComputerModelExists(string name)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT modelName FROM Computer WHERE Computer.modelName = @name", new Dictionary<string, object>() { { "name", name } });
            return table.Rows.Count > 0;
        }

        private string getManufacturerName(int code)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT name FROM Manufacturer WHERE Manufacturer.code = @code", new Dictionary<string, object>() { { "code", code } });
            if (table.Rows.Count > 0)
                return (string)table.Rows[0]["name"];
            else
                return "Unknown";
        }

        internal static int getManufacturerCode(string name)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT code FROM Manufacturer WHERE Manufacturer.name = @name", new Dictionary<string, object>() { { "name", name } });
            if (table.Rows.Count > 0)
                return Convert.ToInt32(table.Rows[0]["code"]);
            else
                return -1;
        }

        public int GetComputerModelStockQuantity(string name)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT quantity FROM Computer WHERE Computer.modelName = @name", new Dictionary<string, object>() { { "name", name } });
            if (table.Rows.Count > 0)
                return Convert.ToInt32(table.Rows[0]["quantity"]);
            else
                return -1;
        }

        private string putComputerModelStockQuantity(string name, int quantity)
        {
            try
            {
                int result = DatabaseConnection.Execute
                    (
                        "UPDATE Computer SET quantity = @quantity WHERE Computer.modelName = @modelName;",
                        new Dictionary<string, object>() { { "modelName", name},{ "quantity", quantity} }
                    );

                if (result == 1)
                    return "SUCCESS";
                else
                    return "COUNT ERROR";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public ModelDetailPrexistingFieldData GetModelDetailPrexistingFieldData()
        {
            ModelDetailPrexistingFieldData result = new ModelDetailPrexistingFieldData();            
           
            result.OperatingSystems = getOperatingSystems();
            result.ProcessorFamilies = getProcessorFamilies(); ;
            result.GraphicsFamilies = getGraphicsFamilies();
            result.TowerForms = getTowerForms();
            
            return result;
        }

        private List<string> getOperatingSystems()
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT DISTINCT operatingSystem FROM Computer", null);
            List<string> result = new List<String>();
            foreach (DataRow row in table.Rows)
            {
                result.Add((string)row[0]);
            }
            return result;
        }

        private List<string> getProcessorFamilies()
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT DISTINCT processorFamily FROM Computer", null);
            List<string> result = new List<String>();
            foreach (DataRow row in table.Rows)
            {
                result.Add((string)row[0]);
            }
            return result;
        }

        private List<string> getGraphicsFamilies()
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT DISTINCT graphicsFamily FROM Computer", null);
            List<string> result = new List<String>();
            foreach (DataRow row in table.Rows)
            {
                result.Add((string)row[0]);
            }
            return result;
        }

        private List<string> getTowerForms()
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT DISTINCT towerForm FROM Computer", null);
            List<string> result = new List<String>();
            foreach (DataRow row in table.Rows)
            {
                if(row[0] != DBNull.Value)
                    result.Add((string)row[0]);
            }
            return result;
        }

        public DateTime GetModifiedDate(string modelName)
        {
            DataTable table = DatabaseConnection.GetDataTable("SELECT modifiedDate FROM Computer WHERE Computer.modelName = @modelName LIMIT 1", new Dictionary<string, object>() { { "modelName", modelName} });
            if (table.Rows.Count > 0)
                return Convert.ToDateTime(table.Rows[0][0]);
            else
                return new DateTime();
        }

        public string PostComputerModel(ComputerModel computerModel)
        {
            if (!GetComputerModelExists(computerModel.name))
            {
                try
                {
                    int result = DatabaseConnection.Execute
                        (
                            "INSERT INTO Computer(modelName, manufacturer, modelType, price, quantity, modifiedDate, operatingSystem, processorFamily, graphicsFamily, storage, memory, powerSupply, towerForm, screenSize, batteryLife, webcamera, fullsizeKeyboard) VALUES(@modelName, @manufacturer, @modelType, @price, @quantity, DATETIME('now'), @operatingSystem, @processorFamily, @graphicsFamily, @storage, @memory, @powerSupply, @towerForm, @screenSize, @batteryLife, @webcamera, @fullsizeKeyboard);",
                            computerModel.toParameterList()
                        );

                    if (result == 1)
                        return "SUCCESS";
                    else
                        return "COUNT ERROR";
                }
                catch (Exception ex)
                {
                    return ex.GetBaseException().Message;
                }
            }
            else
                return "KEY ERROR";
        }

        public string PutComputerModel(ComputerModel computerModel)
        {
            try
            {
                int result = DatabaseConnection.Execute
                    (
                        "UPDATE Computer SET price = @price, quantity = @quantity, modifiedDate = DATETIME('now'), operatingSystem = @operatingSystem, processorFamily = @processorFamily, graphicsFamily = @graphicsFamily, storage = @storage, memory = @memory, powerSupply = @powerSupply, towerForm = @towerForm, screenSize = @screenSize, batteryLife = @batteryLife, webcamera = @webCamera, fullsizeKeyboard = @fullsizeKeyboard WHERE Computer.modelName = @modelName;",
                        computerModel.toParameterList()
                    );

                if (result == 1)
                    return "SUCCESS";
                else
                    return "COUNT ERROR";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteComputerModel(string modelName)
        {
            try
            {
                int result = DatabaseConnection.Execute
                    (
                        "DELETE FROM Computer WHERE Computer.modelName = @modelName;",
                        new Dictionary<string, object>() { { "modelName", modelName} }
                    );

                if (result == 1)
                    return "SUCCESS";
                else
                    return "COUNT ERROR";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {
            List<PurchaseOrder> result = new List<PurchaseOrder>();
            DataTable table = DatabaseConnection.GetDataTable("SELECT * FROM PurchaseOrder", null);

            foreach (DataRow row in table.Rows)
            {
                result.Add
                (
                    new PurchaseOrder()
                    {
                        orderNumber = Convert.ToInt32(row["orderNumber"]),
                        date = Convert.ToDateTime(row["orderDate"]),
                        product = GetComputerModel(Convert.ToString(row["product"])),
                        quantity = Convert.ToInt16(row["quantity"]),
                        customerName = Convert.ToString(row["customerName"]),
                        customerStreetAddress = Convert.ToString(row["customerAddress"]),
                        customerCity = Convert.ToString(row["customerCity"]),
                        customerPostCode = Convert.ToString(row["customerPostCode"]),
                        productPrice = Convert.ToDecimal(row["productPrice"])
                    }
                );
            }
            return result;
        }

        public string PostPurchaseOrder(PurchaseOrder order)
        {
            int currentQuantity = GetComputerModelStockQuantity(order.product.name);
            if (order.quantity <= currentQuantity)
            {
                try
                {
                    int result = DatabaseConnection.Execute
                        (
                            "INSERT INTO PurchaseOrder (orderDate, product, customerName, customerAddress, customerCity, customerPostCode, productPrice, quantity) VALUES(DATETIME('now'), @product, @customerName, @customerStreetAddress, @customerCity, @customerPostCode, @productPrice, @quantity);",
                            order.toParameterList()
                        );
                    if (result == 1)
                    {
                        putComputerModelStockQuantity(order.product.name, currentQuantity - order.quantity);
                        return "SUCCESS";
                    }
                    else
                        return "COUNT ERROR";
                }
                catch (Exception ex)
                {
                    return ex.GetBaseException().Message;
                }
            }
            else
                return "STOCK ERROR";
        }

        public string DeletePurchaseOrder(int orderNumber)
        {
            try
            {
                int result = DatabaseConnection.Execute
                    (
                        "DELETE FROM PurchaseOrder WHERE PurchaseOrder.orderNumber = @orderNumber;",
                        new Dictionary<string, object>() { { "orderNumber", orderNumber } }
                    );

                if (result == 1)
                    return "SUCCESS";
                else
                    return "COUNT ERROR";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

    }
}
