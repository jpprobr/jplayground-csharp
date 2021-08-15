using System;
using System.Collections.Generic;

namespace Exemplo060.DynamicTypes
{
    /*
        Tipos dinâmicos são uteis p/ se comunicar com componentes externos
        ex.: COM Interop, IronPython, resultados JSON, HTML DOM, reflection do C#, etc.
    */

    class Program
    {
        static void Main(string[] args)
        {

            var entities = new List<dynamic> {
                 new
                 {
                    ColumnA = 1,
                    ColumnB = "Foo"
                 },
                 new
                 {
                    ColumnA= 2,
                    ColumnB= "Bar"
                 }
             };

            DisplayInExcel(entities);
        }


        static void DisplayInExcel(IEnumerable<dynamic> entities)
        {
            /*
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            dynamic workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Header A";
            workSheet.Cells[1, "B"] = "Header B";
            var row = 1;

            foreach (var entity in entities)
            {
                row++;
                workSheet.Cells[row, "A"] = entity.ColumnA;
                workSheet.Cells[row, "B"] = entity.ColumnB;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            */
        }
    }
}
