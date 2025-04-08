namespace Performing.Interop.With.Office.Apps
{
    public class Report<TData>
    {
        public string Generate(List<TData> items, ReportType reportType)
        {
            GeneratorBase<TData> generator = CreateGenerator(reportType);

            string report = generator.Generate(items);

            return report;
        }

        GeneratorBase<TData> CreateGenerator(ReportType reportType)
        {
            Type dataType = typeof(TData);

            string generatorNamespace = "Section_05_06.";
            string generatorTypeName = $"{reportType}Generator`1";
            string typeParameterName = $"[[{dataType.FullName}]]";

            string fullyQualifiedTypeName =
                generatorNamespace +
                generatorTypeName +
                typeParameterName;

            Type generatorType = Type.GetType(fullyQualifiedTypeName);

            object generator = Activator.CreateInstance(generatorType);

            return (GeneratorBase<TData>)generator;
        }
    }
}
