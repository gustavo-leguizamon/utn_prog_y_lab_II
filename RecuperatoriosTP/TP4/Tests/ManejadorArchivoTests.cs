using Archivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Pruebas sobre manejador de archivos
    /// 
    /// CLASE 11 - Pruebas unitarias
    /// 
    /// </summary>
    [TestClass]
    public class ManejadorArchivoTests
    {
        [TestMethod]
        [DataRow("hola.json")]
        [DataRow("asd.xml.json")]
        [DataRow(" as a s as .json")]
        public void ObtenerArchivo_CuandoPasoArchivoConExtensionJson_DeberiaDevolverUnaInstanciaDelObjetoArchivoJson(string ruta)
        {
            //Arrange
            IArchivo<string> result;

            //Act
            result = ManejadorArchivo.ObtenerArchivo<string>(ruta);

            //Asert
            Assert.IsTrue(result is ArchivoJson<string>);
        }

        [TestMethod]
        [DataRow("hola.xml")]
        [DataRow("asd.xml.xml")]
        [DataRow(" as a s as .xml")]
        public void ObtenerArchivo_CuandoPasoArchivoConExtensionXml_DeberiaDevolverUnaInstanciaDelObjetoArchivoXml(string ruta)
        {
            //Arrange
            IArchivo<string> result;

            //Act
            result = ManejadorArchivo.ObtenerArchivo<string>(ruta);

            //Asert
            Assert.IsTrue(result is ArchivoXml<string>);
        }

        [TestMethod]
        [DataRow("hola.doc")]
        [DataRow("asd.xml.txt")]
        [DataRow(" as a s as")]
        [ExpectedException(typeof(ArchivoException))]
        public void ObtenerArchivo_CuandoPasoArchivoConExtensionDistintaDeJsonYXml_DeberiaLanzarExcepcionDeArchivo(string ruta)
        {
            //Arrange
            IArchivo<string> result;

            //Act
            result = ManejadorArchivo.ObtenerArchivo<string>(ruta);
        }
    }
}
