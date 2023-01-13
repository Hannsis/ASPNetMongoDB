// Detta är en klass som används för att hantera databasoperationer i MongoDB.
// Det finns flera olika metoder i denna klass för att hantera CRUD-operationer (skapa, läsa, uppdatera, radera) för katter.
// De metoder som finns är: CreateProduct, DeleteAllProducts, DeleteAllProductsByPrice, DeleteProduct, GetAllCats, GetAllCatsByAntal, GetCat och UpdateCat.

namespace ASPNetMongoDB.Database;

using ASPNetMongoDB.Models;
using System.Collections.Generic;

/// <summary>
/// Klassen ansvarar för att hantera databasoperationer i MongoDB.
/// </summary>
public class MongoDBContext
{
    #region Private Fields

    // Denna fält håller MongoDBHandler<Product> objektet, för att kommunicera med databasen.
    private readonly MongoDBHandler<Product> _productHandler;

    #endregion Private Fields

    #region Public Constructors

    public MongoDBContext() => _productHandler = new MongoDBHandler<Product>("Products", "Products");

    #endregion Public Constructors

    #region Public Methods

    //CRUD methods
    /// <summary>
    /// Skapar ett nytt produkt-objekt och sparar i databasen
    /// </summary>
    /// <param name="product">Katt-objektet som ska sparas</param>
    public void CreateProduct(Product product)
    {
        _productHandler.Create(product);
    }

    /// <summary>
    /// Raderar alla katter från databasen
    /// </summary>
    public void DeleteAllProducts()
    {
        _productHandler.DeleteAll();
    }

    /// <summary>
    /// Raderar alla katter med angiven färg från databasen
    /// </summary>
    /// <param name="color">Färgen på kattarna som ska raderas</param>
    public void DeleteAllProductsByPrice(int pris)
    {
        _productHandler.DeleteAll("", pris.ToString());
    }

    /// <summary>
    /// Raderar alla katter med angiven färg från databasen
    /// </summary>
    /// <param name="color">Färgen på kattarna som ska raderas</param>
    public void DeleteAllProductsByAntal(int antal)
    {
        _productHandler.DeleteAll("", antal.ToString());
    }

    /// <summary>
    /// Raderar en produkt med angiven id från databasen
    /// </summary>
    /// <param name="id">Id på katten som ska raderas</param>
    public void DeleteProduct(string id)
    {
        _productHandler.Delete(id);
    }

    /// <summary>
    /// Hämtar alla prods från databasen
    /// </summary>
    /// <returns>En lista med alla p i databasen</returns>
    public List<Product> GetAllProducts()
    {
        return _productHandler.GetAll();
    }

    /// <summary>
    /// Hämtar alla pro med angiven antal från databasen
    /// </summary>
    /// <param name="color">Färgen på kattarna som ska hämtas</param>
    /// <returns>En lista med alla katter med angiven färg i databasen</returns>
    public List<Product> GetAllCatsByAntal(int antal)
    {
        return _productHandler.GetAll("", antal.ToString());
    }

    /// <summary>
    /// Hämtar en katt med angiven id från databasen
    /// </summary>
    /// <param name="id">Id på katten som ska hämtas</param>
    /// <returns>Katt-objektet med angiven id</returns>
    public Product GetProduct(string id)
    {
        return _productHandler.Get(id);
    }

    /// <summary>
    /// Uppdaterar en katt med angiven id och uppdateringsdata
    /// </summary>
    /// <param name="id">Id på katten som ska uppdateras</param>
    /// <param name="product">Katt-objektet med nya data</param>
    public void UpdateProduct(string id, Product product)
    {
        _productHandler.Update(id, product);
    }

    #endregion Public Methods
}