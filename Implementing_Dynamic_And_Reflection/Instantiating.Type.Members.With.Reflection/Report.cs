using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instantiating.Type.Members.With.Reflection
{
    public class Report<TData>
    {
        public string Generate(List<TData> items, ReportType reportType)
        {
            GeneratorBase<TData> generator = CreateGenerator(reportType);
            string report = generator.Generate(items);
            return report;
        }

        private GeneratorBase<TData> CreateGenerator(ReportType reportType)
        {
            System.Type generatorType;
            switch (reportType)
            {
                case ReportType.Html:
                    generatorType = typeof(HtmlGenerator<>);
                    break;
                case ReportType.Markdown:
                    generatorType = typeof(MarkdownGenerator<>);
                    break;
                default:
                    throw new ArgumentException(
                    $"Unexpected ReportType: '{reportType}'");
            }
            System.Type dataType = typeof(TData);
            System.Type genericType = generatorType.MakeGenericType(dataType);
            object generator = Activator.CreateInstance(genericType);
            return (GeneratorBase<TData>)generator;
        }

        //private GeneratorBase<TData> CreateGenerator(ReportType reportType)
        //{
        //    System.Type dataType = typeof(TData);
        //    string generatorNamespace = "Section_05_03.";
        //    string generatorTypeName = $"{reportType}Generator`1";
        //    string typeParameterName = $"[[{dataType.FullName}]]";
        //    string fullyQualifiedTypeName =
        //    generatorNamespace +
        //    generatorTypeName +
        //    typeParameterName;
        //    System.Type generatorType = System.Type.GetType(fullyQualifiedTypeName);
        //    object generator = Activator.CreateInstance(generatorType);
        //    return (GeneratorBase<TData>)generator;
        //}
    }
}
