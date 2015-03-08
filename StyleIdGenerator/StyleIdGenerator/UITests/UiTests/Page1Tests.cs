using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UiTests.ExtensionsMethods;

namespace UiTests
{
    public partial class CrossPlatformTests
    {
        [Test]
        public void MainTextLabel_ShouldBeSelectable()
        {
            var lblMainText = _app.Query(StyleIds.Page1.lblMainText);

            Assert.IsNotNull(lblMainText);
            Assert.IsTrue(lblMainText.Any());
        }

        [Test]
        public void LabelWithSpace_ShouldBeSelectable()
        {
            var lblWithSpace = _app.Query(StyleIds.Page1.lblWithSpace);

            Assert.IsNotNull(lblWithSpace);
            Assert.IsTrue(lblWithSpace.Any());
        }

        [Test]
        public void LabelAllCaps_ShouldBeSelectable()
        {
            var lblAllCaps = _app.Query(StyleIds.Page1.LBLALLCAPS);

            Assert.IsNotNull(lblAllCaps);
            Assert.IsTrue(lblAllCaps.Any());
        }

        static IEnumerable<object> GetMatchingXamlFiles(string path)
        {
            //String search code from here https://msdn.microsoft.com/en-us/library/bb882639.aspx
            IEnumerable<System.IO.FileInfo> fileList = new List<FileInfo>();

            // Create the regular expression to find all things "Visual".
            var searchTerm =
            new System.Text.RegularExpressions.Regex("StyleId *= *\"([^\"]*?)\"");
            var replaceTerm =
            new System.Text.RegularExpressions.Regex("StyleId *= *");

            // Search the contents of each .htm file.
            // Remove the where clause to find even more matchedValues!
            // This query produces a list of files where a match
            // was found, and a list of the matchedValues in that file.
            // Note: Explicit typing of "Match" in select clause.
            // This is required because MatchCollection is not a
            // generic IEnumerable collection.
            var queryMatchingFiles =
                    from file in fileList
                    where file.Extension == ".xaml"
                    let fileText = System.IO.File.ReadAllText(file.FullName)
                    let matches = searchTerm.Matches(fileText)
                    where matches.Count > 0
                    select new MatchingFile
                    {
                        name = file.FullName,
                        nameWithoutExtension = file.Name.Replace(".xaml", ""),
                        matchedValues = from System.Text.RegularExpressions.Match match in matches
                                        select replaceTerm.Replace(match.Value, "").Replace("\"", "")
                    };

            return queryMatchingFiles;
        }


    }

    internal class MatchingFile
    {
        public string name { get; set; }
        public string nameWithoutExtension { get; set; }
        public IEnumerable<string> matchedValues { get; set; }
    }
}
