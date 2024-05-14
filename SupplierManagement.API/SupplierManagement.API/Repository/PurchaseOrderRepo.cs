using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.DBContext;
using SupplierManagement.Data.Models;
using System;
using System.Data;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SupplierManagement.API.Repository
{
    public class PurchaseOrderRepo: IPurchaseOrder
    {
       
        private readonly IConfiguration configuration;
        public PurchaseOrderRepo( IConfiguration configuration)
        {
            
            this.configuration = configuration;
        }

        public async Task<bool> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {           
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var purchasedProductList = JsonSerializer.Serialize(purchaseOrder.Products);                
                var spName = "InsertOrUpdatePurchaseOrder";
                await connection.OpenAsync();
                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", purchaseOrder.PONumber);
                    cmd.Parameters.AddWithValue("@DeliveryDate", purchaseOrder.DeliveryDate);
                    cmd.Parameters.AddWithValue("@SupplierId", purchaseOrder.SupplierId);                  
                    cmd.Parameters.AddWithValue("@ProductList", purchasedProductList);
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;

                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders(string userId)
        {
            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {               
                var spName = "GetPurchaseOrders";
                await connection.OpenAsync();

                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        PurchaseOrder purchaseOrder = new PurchaseOrder
                        {
                            
                            Id = (Guid)reader["Id"],
                            PONumber = reader["PONumber"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            SupplierId = (Guid)reader["SupplierId"]
                        };

                        // Add the PurchaseOrder to the list
                        purchaseOrders.Add(purchaseOrder);
                    }                    
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return purchaseOrders;
        }

        public async Task<PurchaseOrder> GetPurchaseOrder(Guid purchaseOrderId)
        {

            PurchaseOrder purchaseOrder = null;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var spName = "GetPurchaseOrder";
                await connection.OpenAsync();

                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderId);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        if (purchaseOrder == null)
                        {

                            purchaseOrder = new PurchaseOrder
                            {
                                Id = (Guid)reader["Id"],
                                PONumber = reader["PONumber"].ToString(),
                                DeliveryDate = (DateTime)reader["DeliveryDate"],
                                IsDeleted = (bool)reader["IsDeleted"],
                                SupplierId = (Guid)reader["SupplierId"],
                                Products = new List<ProductList>()
                            };
                        }


                        purchaseOrder.Products.Add(new ProductList
                        {
                            Id = (Guid)reader["Id"],
                            Quantity = (int)reader["Quantity"],
                            ProductId = (Guid)reader["ProductId"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return purchaseOrder;
        }

        public async Task<bool> UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var purchasedProductList = JsonSerializer.Serialize(purchaseOrder.Products);

                var spName = "InsertOrUpdatePurchaseOrder";
                await connection.OpenAsync();

                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", purchaseOrder.PONumber);
                    cmd.Parameters.AddWithValue("@DeliveryDate", purchaseOrder.DeliveryDate);
                    cmd.Parameters.AddWithValue("@SupplierId", purchaseOrder.SupplierId);
                    cmd.Parameters.AddWithValue("@ProductList", purchasedProductList);
                    cmd.Parameters.AddWithValue("@ExistingPurchaseOrderId", purchaseOrder.Id);
                    await cmd.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;

                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }


        public async Task<bool> DeletePurchaseOrder(Guid purchaseOrderId)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {              
                var spName = "DeletePurchaseOrder";
                await connection.OpenAsync();

                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderId);
                    await cmd.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;

                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }

    }
}
