using Archivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// Pruebas sobre archivos .json
    /// 
    /// CLASE 11 - Pruebas unitarias
    /// 
    /// </summary>
    [TestClass]
    public class ArchivoJsonTests
    {
        [TestMethod]
        [DataRow("hola.json")]
        [DataRow("asd.xml.json")]
        [DataRow(" as a s as .json")]
        public void ValidarExtension_CuandoPasoArchivoConExtensionPuntoJson_DeberiaPasarCorrectamente(string ruta)
        {
            //Arrange
            Archivo archivoJson = new ArchivoJson<string>();
            bool result;

            //Act
            result = archivoJson.ValidarExtension(ruta);

            //Asert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("hola.xml")]
        [DataRow("asd.xml.doc")]
        [DataRow(" as a s as")]
        [ExpectedException(typeof(ArchivoException))]
        public void ValidarExtension_CuandoPasoArchivoConExtensionDistintaDePuntoJson_DeberiaLanzarExcepcionDeArchivo(string ruta)
        {
            //Arrange
            Archivo archivoJson = new ArchivoJson<string>();
            bool result;

            //Act
            result = archivoJson.ValidarExtension(ruta);
        }
    }
}
