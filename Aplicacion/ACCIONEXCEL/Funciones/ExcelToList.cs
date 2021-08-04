using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Persistencia;
/*RICHARD ROMAN 29-04-2021*/
/*EN ESTA CLASE PASAREMOS LOS DOCUMENTOS DEL TIPO XLSX  A LISTA DE ENTIDADES PARA PODER GUARDAR 
SUS DATOS EN LA BASE DE DATOS PARA REALIZAR ESTE TRABAJO ES NECESARIO INSTALAR LA DEPENDENCIA EPPLUS 
QUE NOS PERMITE MANEJAR ESTE TIPO DE ARCHIVOS */
namespace Aplicacion.ACCIONEXCEL {
    public class ExcelToList : IExcel {
        /*CADA UNA DE ESTAS FUNCIONES ESTA ESPECIFICADA EN LA INTERFACE IExcel PARA PODER HACER LA REFERENCIA
        A TRAVEZ DE LA IMPLEMENTACION DE LAS MISMAS Y RECIBEN COMO PARAMETRO UN ARCHIVO ESPECIFICADO CON EL NOMBRE
        IFORMFILE.
        DEBEMOS ESPECIFICAR UNA FUNCION PARA CADA TABLA EN LA QUE DESEAMOS INSERTAR LOS DATOS, LAS FUNCIONES
        RETORNARAN UNA LISTA DE ENTIDADES QUE SON RESULTADO DE LA CONVERSION DEL DOCUMENTO A TIPOS DE DATOS 
        ACEPTADOS POR EL LENGUAJE
        */
        public async Task<List<CLIENTES>> ImportarExcelCLIENTES (IFormFile file) {
            /*PARA LOGRAR EL OBJETIVO DECLARAMOS UNA VARIABLE DE TIPO LISTA DE ENTIDADES CON LA ENTIDAD QUE NECESITAMOS
            INSERTAR EN LA BASE DE DATOS LUEGO RECIBIMOS EL ARCHIVO Y LO GUARDAMOS EN EL STREAM PARA PODER MANIPULAR SU CONTENIDO,
            DESPUES LO IGUALAMOS A LA CLASE DE LA LIBRERIA INSTALADA ANTERIORMENTE Y LA RECORREMOS LINEA POR LINEA
            OBVIANDO LA PRIMERA LINEA POR QUE GENERALMENTE SUELE SER LA CABECERA DE LAS GRILLAS DE LOS DOCUMENTOS 
            EXCELS.
            LOS VALORES QUE NO TIENEN TERNARIOS ES POR QUE SON OBLIGATORIAS
            CABE RESALTAR QUE EL EXCEL TIENE QUE TENER EXACTAMENTE LAS COLUMNAS QUE SE ESPECIFICAN SI 
            SI NO TIENEN ESOS DATOS SE AGREGA UNA COLUMNA VACIA PERO DEBE TENER EXACTAMENTE EL MISMO 
            NUMERO DE COLUMNAS PARA QUE SE LOGRE LA IMPORTACION CORRECTA
            EN LAS TABLAS QUE ESTAN DISPONIBLES PARA INTEGRACION HAY UN CAMPO DE NOMBRE DE ARCHIVOS QUE NOS SERVIRA 
            PARA HACER LA REVERSION POR LOTES EN EL FUTURO
            */
            var list = new List<CLIENTES> ();
            using (var stream = new MemoryStream ()) {
                await file.CopyToAsync (stream);
                using (var package = new ExcelPackage (stream)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++) {
                        list.Add (new CLIENTES {
                            CLIENTE_Id = Guid.NewGuid (),
                                NOMBRE = worksheet.Cells[row, 1].Value != null ? worksheet.Cells[row, 1].Value.ToString ().Trim () : " ",
                                APELLIDO = worksheet.Cells[row, 2].Value.ToString ().Trim (),
                                CI = worksheet.Cells[row, 3].Value != null ? worksheet.Cells[row, 3].Value.ToString ().Trim () : " ",
                                RUC = worksheet.Cells[row, 4].Value != null ? worksheet.Cells[row, 4].Value.ToString ().Trim () : " ",
                                FECGRA = DateTime.Now
                        });
                    }
                }
            }
            return list;
        }

        public async Task<List<POSIBLESCLIENTES>> ImportarExcelPOSIBLESCLIENTES (IFormFile file) {
            var list = new List<POSIBLESCLIENTES> ();
            using (var stream = new MemoryStream ()) {
                await file.CopyToAsync (stream);
                using (var package = new ExcelPackage (stream)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++) {
                        list.Add (new POSIBLESCLIENTES {
                            POSIBLECLIENTE_Id = Guid.NewGuid (),
                                NOMBRE = worksheet.Cells[row, 1].Value != null? worksheet.Cells[row, 1].Value.ToString ().Trim (): " ",
                                APELLIDO = worksheet.Cells[row, 2].Value.ToString ().Trim (),
                                CI = worksheet.Cells[row, 3].Value != null ? worksheet.Cells[row, 3].Value.ToString ().Trim () : " ",
                                RUC = worksheet.Cells[row, 4].Value != null ? worksheet.Cells[row, 4].Value.ToString ().Trim () : " ",
                                FECGRA = DateTime.Now
                        });
                    }
                }
            }
            return list;
        }
    }
}