namespace ASPNetMongoDB.Controllers;

using ASPNetMongoDB.Database;
using ASPNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    #region Private Fields

    //Deklarerar en privat fält av typen MongoDBContext
    private readonly MongoDBContext _productDBContext;

    #endregion Private Fields

    #region Public Constructors

    //Konstruktorn instansierar en ny MongoDBContext och sätter det som vårt privata fält
    public ProductsController() => _productDBContext = new MongoDBContext();

    #endregion Public Constructors

    #region Public Methods

    //HttpGet metod för att skapa en ny katt
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //HttpPost metod för att skapa en ny katt, tar emot ett Cat-objekt från vyn
    [HttpPost]
    public IActionResult Create(Product product
        )
    {
        //Använder vår MongoDBContext för att skapa en ny katt i databasen
        _productDBContext.CreateProduct(product);
        //Redirect till index-sidan efter att katten skapats
        return RedirectToAction("Index");
    }

    //HttpPost metod för att radera en befintlig katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Delete(string id)
    {
        //Använder vår MongoDBContext för att radera en katt i databasen
        _productDBContext.DeleteProduct(id);
        //Redirect till index-sidan efter att katten raderats
        return RedirectToAction("Index");
    }

    //HttpGet metod för att hämta detaljer för en katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Details(string id)
    {
        //Använder vår MongoDBContext för att hämta en katt med det angivna id:t
        var cat = _productDBContext.GetProduct(id);
        return View(cat);
    }

    //HttpGet metod för att redigera en befintlig katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Edit(string id)
    {
        //Använder vår MongoDBContext för att hämta en katt med det angivna id:t
        var product = _productDBContext.GetProduct(id);
        return View(product);
    }

    //HttpPost metod för att uppdatera en befintlig katt, tar emot ett Cat-objekt från vyn
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        //Använder vår MongoDBContext för att uppdatera en katt i databasen
        _productDBContext.UpdateProduct(product.Id, product);
        //Redirect till index-sidan efter att katten uppdaterats
        return RedirectToAction("Index");
    }

    // HttpGet-metod som hämtar alla katter från databasen och returnerar dem till vyn.
    [HttpGet]
    public IActionResult Index()
    {
        //Använder vår MongoDBContext för att hämta alla katter
        var product = _productDBContext.GetAllProducts();
        return View(product);
    }

    #endregion Public Methods
}