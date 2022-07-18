using Archivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// Pruebas sobre archivos .xml
    /// 
    /// CLASE 11 - Pruebas unitarias
    /// 
    /// </summary>
    [TestClass]
    public class ArchivoXmlTests
    {
        [TestMethod]
        [DataRow("hola.xml")]
        [DataRow("asd.xml.xml")]
        [DataRow(" as a s as .xml")]
        public void ValidarExtension_CuandoPasoArchivoConExtensionPuntoXml_DeberiaPasarCorrectamente(string ruta)
        {
            //Arrange
            Archivo archivoXml = new ArchivoXml<string>();
            bool result;

            //Act
            result = archivoXml.ValidarExtension(ruta);

            //Asert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("hola.json")]
        [DataRow("asd.xml.doc")]
        [DataRow(" as a s as")]
        [ExpectedException(typeof(ArchivoException))]
        public void ValidarExtension_CuandoPasoArchivoConExtensionDistintaDePuntoXml_DeberiaLanzarExcepcionDeArchivo(string ruta)
        {
            //Arrange
            Archivo archivoXml = new ArchivoXml<string>();
            bool result;

            //Act
            result = archivoXml.ValidarExtension(ruta);
        }
    }
}
